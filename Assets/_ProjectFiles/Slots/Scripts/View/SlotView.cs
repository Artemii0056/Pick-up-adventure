using _ProjectFiles.Interaction.Scripts.View;
using _ProjectFiles.Player.Scripts.Resolvers;
using _ProjectFiles.Slots.Scripts.Data;
using UnityEngine;

namespace _ProjectFiles.Slots.Scripts.View
{
    public class SlotView : InteractableView
    {
        [field: SerializeField] public SlotRuleType SlotRuleType { get; private set; }
        [field: SerializeField] public Transform ItemAnchor { get; private set; }

        public ItemView CurrentItemView { get; private set; }

        public bool IsEmpty => CurrentItemView == null;

        public void SetItemView(ItemView itemView)
        {
            CurrentItemView = itemView;
        }

        public ItemView RemoveItemView()
        {
            var itemView = CurrentItemView;
            CurrentItemView = null;
            return itemView;
        }
    }
}