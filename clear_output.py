import os
import shutil

root_folder = "output"
bin_dir = "bin"
obj_dir = "obj"

if os.path.exists(root_folder):
    shutil.rmtree(root_folder)

for root, dirs, files in os.walk("."):
    for dir in dirs:
        if dir == bin_dir or dir == obj_dir:
            d = os.path.join(root, dir)
            print(d)
            shutil.rmtree(d)