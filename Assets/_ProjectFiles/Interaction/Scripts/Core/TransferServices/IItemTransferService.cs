using _ProjectFiles.Player.Scripts.Resolvers;
using _ProjectFiles.Slots.Scripts.View;

namespace _ProjectFiles.Interaction.Scripts.Core.TransferServices
{
    public interface IItemTransferService
    {
        bool TryTakeItem(ItemView itemView);
        bool TryPlaceToSlot(SlotView slotView);
    }
}