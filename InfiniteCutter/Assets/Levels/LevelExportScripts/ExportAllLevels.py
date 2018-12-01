import os
import json

PATH_TO_TILED = '"c:/Program Files/Tiled/tiled"'
path_source_directory = "R:/Documents/Github/Infinite-cutter/InfiniteCutter/Assets/Levels/Source/"
path_to_export = "R:/Documents/Github/Infinite-cutter/InfiniteCutter/Assets/Levels/Export/"


# Exporting part
for dirName, subdirList, fileList in os.walk(path_source_directory):
    for filename in fileList:
        file_split = filename.split(".")
        # Export only tmx files
        if (len(file_split) > 2 or file_split[1] != 'tmx'):
            continue
        
        file_without_end = file_split[0];
        print(filename)
        command = PATH_TO_TILED + " --export-map json " + path_source_directory + filename + " " + path_to_export + file_without_end + ".json"
        print(command)

        os.system(command)

FIELDS_TO_KEEP = ['height', 'layers']

# Striping part
for dirName, subdirList, fileList in os.walk(path_to_export):
    for filename in fileList:
        file_split = filename.split(".")
        #Strip only JSON
        if (len(file_split) > 2 or file_split[1] != 'json'):
            continue

        file_path = path_to_export + filename
        data_output = {};
        with open(file_path, 'r') as data_file:
            data = json.load(data_file)
            print(data)
            for element in data:
                print(element, data[element])
                if (element  in FIELDS_TO_KEEP):
                    data_output[element] = data[element]
                
                #if 'nextobjectid' in element:
                #    del element['nextobjectid']

        with open(file_path, 'w') as data_file:
            data = json.dump(data_output, data_file)