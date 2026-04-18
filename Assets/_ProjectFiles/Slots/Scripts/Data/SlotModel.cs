using _ProjectFiles.Items.Scripts.Data;

namespace _ProjectFiles.Slots.Scripts.Data
{
    public class SlotModel 
    {
        public int Id { get; }
        public int? ItemId { get; private set; }
        public ItemType Type { get; }

        public SlotModel(int id, int? itemId = null)
        {
            Id = id;
            ItemId = itemId;
        }

        public bool IsEmpty => ItemId == null;

        public bool CanPlace(ItemModel item) => 
            IsEmpty && item != null;

        public void Place(ItemModel item)
        {
            ItemId = item.Id;
        }

        public void Clear()
        {
            ItemId = null;
        }
    }
}