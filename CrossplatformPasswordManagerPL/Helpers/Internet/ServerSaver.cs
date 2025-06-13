using Autofac;
using CrossplatformPasswordManagerPL.Helpers;
using CrossplatformPasswordManagerPL.Helpers.UI;
using Database.Contracts.BLL;
using Helpers.Common.Mapper;
using Models.Common;
using Ninject.Common;
using PlatformSpecific.Contracts.PSL.Internet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Helpers.Common.Internet
{
    public class ServerSaver : IServerSaver, IDisposable
    {
        private readonly static int PingCountSec = 5000;

        private bool _isInetActive = true;
        private bool _isServerActive = true;

        private readonly IInternetAdapterChecker _internetAdapterCheckerPlatformSpecific;
        private readonly IGroupDbLogic _groupDbLogic;
        private readonly IGroupServerLogic _groupServerLogic;

        private CancellationTokenSource _cts;

        public ServerSaver(IInternetAdapterChecker internetAdapterCheckerPlatformSpecific, IGroupDbLogic groupDbLogic, IGroupServerLogic groupServerLogic)
        {
            _internetAdapterCheckerPlatformSpecific = internetAdapterCheckerPlatformSpecific;
            _groupDbLogic = groupDbLogic;
            _groupServerLogic = groupServerLogic;
        }

        public async Task Run()
        {
            _cts = new CancellationTokenSource();

            await TrySaveDataToServer(TimeSpan.FromSeconds(20), _cts.Token);
        }

        public void Dispose()
        {
            _cts.Cancel();
        }

        private async Task TrySaveDataToServer(TimeSpan interval, CancellationToken cancellationToken)
        {
            using (var scope = ServiceModule.Container?.BeginLifetimeScope())
            {
                var toasts = scope?.Resolve<IToastControlContainer>();
                while (!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        using (Ping ping = new Ping())
                        {
                            if (!_internetAdapterCheckerPlatformSpecific.IsInternetAdapterAvailable())
                            {
                                if (_isInetActive)
                                {
                                    toasts?.Show(TimeSpan.FromSeconds(3), "Подключение к интернету потеряно");
                                }
                                _isInetActive = false;
                                throw new Exception("Not internet connection");
                            }
                            PingReply reply = await ping.SendPingAsync("8.8.8.8", PingCountSec);
                            if (reply.Status != IPStatus.Success)
                            {
                                if (_isServerActive)
                                {
                                    toasts?.Show(TimeSpan.FromSeconds(3), "Подключение к серверу потеряно");
                                }
                                _isServerActive = false;
                                throw new Exception("Not server connection");
                            }
                        }
                        if(!_isInetActive)
                        {
                            toasts?.Show(TimeSpan.FromSeconds(3), "Подключение к интернету восстановлено");
                        }
                        _isInetActive = true;
                        if (!_isServerActive)
                        {
                            toasts?.Show(TimeSpan.FromSeconds(3), "Подключение к серверу восстановлено");
                        }
                        _isServerActive = true;
                        var actualData = await _groupDbLogic.GetAll();
                        if (actualData != null)
                        {
                            await _groupServerLogic.Write(actualData);
                        }
                        Debug.WriteLine($"Data send to server - OK");
                    }
                    catch (TaskCanceledException)
                    {
                        break;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"Data send to server - error: {ex.Message}");
                    }
                    await Task.Delay(interval, cancellationToken);
                }
            }
        }

    }
}
