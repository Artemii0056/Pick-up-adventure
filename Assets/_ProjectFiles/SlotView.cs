using _ProjectFiles.RaycastResolvers.Scripts;
using DefaultNamespace;
using UnityEngine;

namespace _ProjectFiles
{
    public class SlotView : ItemView
    {
        [field: SerializeField] public SlotRuleType SlotRuleType { get; private set; }
        public bool IsEmpty => Item == null;
        public Item Item { get; private set; }

        public void SetItem(Item item)
        {
            Item = item;
            //Тут надо найти конфиг
        }

        public Item RemoveItem()
        {
            Item item = Item;
            Item = null;
            
            return item;
        }
    }
}