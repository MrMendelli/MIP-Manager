import os

#from pathlib import Path
#for i in range(0, 16):
#    Path('./mip%i.dds' % (i + 1)).touch()

rootDir = os.getcwd()
mipDir = rootDir + os.sep + 'MIPS'
os.makedirs(mipDir, exist_ok=True)

for dirName, subdirList, fileList in os.walk(rootDir):
    if dirName == mipDir:
        continue

    for path in fileList:
        filename, extension = os.path.splitext(path)
        if extension == '.dds' or extension == '.png':
            parts = filename.split('_')
            print(parts)
            lastPart = parts[len(parts) - 1]
            if lastPart.find('mip') != -1:
                print("Moving mipmap %s" % path)
                os.rename(path, mipDir + os.sep + filename + extension)