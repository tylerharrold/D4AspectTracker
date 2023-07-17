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
#########################
def get_type(description):
    if("{" in description):
        # its either ranged, or value
        if("{#" in description):
            return "Value"
        else:
            return "Ranged"
    else:
        return "Static"

