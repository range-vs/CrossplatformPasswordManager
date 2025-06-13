using PlatformSpecific.Contracts.PSL.Internet;
using System;
using System.Collections.Generic;
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

        private readonly IInternetAdapterChecker _internetAdapterCheckerPlatformSpecific;

        public ServerSaver(IInternetAdapterChecker internetAdapterCheckerPlatformSpecific)
        {
            _internetAdapterCheckerPlatformSpecific = internetAdapterCheckerPlatformSpecific;
        }

        public void Run()
        {
            using CancellationTokenSource cts = new CancellationTokenSource();

            var periodicTask = TrySaveDataToServer(TimeSpan.FromSeconds(20), cts.Token);
        }

        public void Dispose()
        {
            
        }

        private async Task TrySaveDataToServer(TimeSpan interval, CancellationToken cancellationToken)
        {
            var waitTask = async () => { 
                await Task.Delay(interval, cancellationToken); 
            };
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    using (Ping ping = new Ping())
                    {
                        if (!_internetAdapterCheckerPlatformSpecific.IsInternetAdapterAvailable())
                        {
                            // show custom popup!
                            await waitTask.Invoke();
                            continue;
                        }
                        PingReply reply = await ping.SendPingAsync("8.8.8.8", PingCountSec);
                        if(reply.Status != IPStatus.Success)
                        {
                            // show custom popup!
                            await waitTask.Invoke();
                            continue;
                        }
                    }
                    // TODO get data from disk!
                    // TODO save data to sarver!
                }
                catch (TaskCanceledException)
                {
                    break;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Data send to server - error: {ex.Message}");
                }
                Debug.WriteLine($"Data send to server - OK");
                await waitTask.Invoke();
            }
        }

    }
}
