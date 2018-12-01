import os

PATH_TO_TILED = '"c:/Program Files/Tiled/tiled"'
path_source_directory = "R:/Documents/Github/Infinite-cutter/InfiniteCutter/Assets/Levels/Source/"
path_to_export = "R:/Documents/Github/Infinite-cutter/InfiniteCutter/Assets/Levels/Export/"

for dirName, subdirList, fileList in os.walk(path_source_directory):
    for filename in fileList:
        file_split = filename.split(".")
        if (len(file_split) > 2 or file_split[1] != 'tmx'):
            continue
        
        file_without_end = file_split[0];
        print(filename)
        command = PATH_TO_TILED + " --export-map json " + path_source_directory + filename + " " + path_to_export + file_without_end + ".json"
        print(command)

        os.system(command)