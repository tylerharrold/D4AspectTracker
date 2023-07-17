import formatting_utils as utils

# aliasing for aspect list elements
NAME = 0
EFFECT = 1
TYPE = 2
CATEGORY = 3
MIN_RANGE = 4
MAX_RANGE = 5
STATIC_DESC = 6

# empty list for all our data
aspect_data = []


# read in seed data file
csvData = open("V:\D4AspectTrackerResources\SeedData\d4AspectsSeed.tsv" , "r")

# iterate through each row in the seed data file and store it in a list (as a list)
for line in csvData.readlines():
    split_line = line.split("\t");
    aspect_data.append(split_line)

# we can discard aspect_data[0] as it only contains the header row
aspect_data.pop(0)

#### format data appropriately  ###

# format aspect names
for aspects in aspect_data:
    aspects[NAME] = utils.format_names(aspects[NAME])

# ascertain aspect type based on text description
for aspects in aspect_data:
    aspects[TYPE] = utils.get_type(aspects[EFFECT])

# set range roll values (if applicable) and static_desc (if applicable)



















