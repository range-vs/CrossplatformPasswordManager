import os
import shutil

bin_dir = "bin"
obj_dir = "obj"

for root, dirs, files in os.walk("."):
    for dir in dirs:
        if dir == bin_dir or dir == obj_dir:
            d = os.path.join(root, dir)
            print(d)
            shutil.rmtree(d)