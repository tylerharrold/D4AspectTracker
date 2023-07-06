
namespace D4AspectTracker
{
    internal class Aspect
    {

        public string AspectName{ get; set;}
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public Dictionary<ItemSlot, float> ItemSlotModifiers { get; }


        public void SetItemSlotModifier(ItemSlot slot , float value)
        {
            ItemSlotModifiers[slot] = value;
        }

    }
}
