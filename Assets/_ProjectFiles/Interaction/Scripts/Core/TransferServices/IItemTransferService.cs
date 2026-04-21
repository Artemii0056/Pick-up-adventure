using _ProjectFiles.Player.Scripts.Resolvers;
using _ProjectFiles.Slots.Scripts.View;
using UnityEngine;

namespace _ProjectFiles.Interaction.Scripts.Core.TransferServices
{
    public interface IItemTransferService
    {
        bool TryTakeItem(ItemView itemView);
        bool TryPlaceToSlot(SlotView slotView);
        void MoveToInspect(ItemView itemView, Transform inspectAnchor);
    }
}