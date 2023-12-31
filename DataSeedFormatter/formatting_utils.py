#########################
# Format Name
#   Aspect names on csv (annoyingly) are formatted with just the descriptive part of the full name (e.g. "Balanced" instead of "Balanced Aspect")
#   or only the prepositional portion (e.g. "of Retaliation" instead of "Aspect of Retaliation" )
#   this method will detect which of the two shortenings is used and properly format the string
#########################
def format_names(s):
    s.strip()
    if("of " in s):
        return "Aspect " + s
    else:
        return s + " Aspect"

#########################
# Get Type
#   aspect are (currently) one of 3 types: Ranged Rolls (Range), Static Values (Static), and Set Values (Value). Based on the aspect Effect description,
#   we can programmatically ascertain what this type is using the following criteria:
#       Ranged: apects with ranged rolls will have numbers of the format {x/y} present in their effect description
#       Value: aspects with a set roll will have {#} present in their effect description
#       Static: static aspect effects will simply have a description with no {} denoted values present
#       NOTE: the object model we use for d4aspects in the application uses an enum for type, so return values are matched to those values
#           this is poor practice, but im just trying to get this thing done lmfao
#########################
def get_type(description):
    if("{" in description):
        # its either ranged, or value
        if("{#" in description):
            return 1
        else:
            return 0
    else:
        return 2

#########################
# Get Range Roll Values
#   if the aspect is of the type Range, get the min/max possible roll for the aspect (noted in effect description as {x/y})
#   and return them as strings, if the aspect is not a range roll, return NULL values
#########################
def get_range_rolls(aspect_type , aspect_effect):
    if(aspect_type == "Ranged"):
        brace_start_index , brace_end_index = aspect_effect.find("{") , aspect_effect.find("}")
        substr = aspect_effect[brace_start_index + 1:brace_end_index]
        min_val_str , max_val_str = substr.split("/")
        return float(min_val_str) , float(max_val_str)
    else:
        return 0.0, 0.0

#########################
# Format AspectCategory
#   The object model for d4aspects in our application uses an enum to store category, so we need to convert from string to int
#       matching the enum, bad practice here, but i'm doing it for the sake of just wrapping this up before diablo 4 season 1 launches
#########################
def format_aspect_category(cat):
    match cat:
        case "Offensive":
            return 0
        case "Defensive":
            return 1
        case "Resource":
            return 2
        case "Utility":
            return 3
        case "Mobility":
            return 4
        case _:
            return 5


