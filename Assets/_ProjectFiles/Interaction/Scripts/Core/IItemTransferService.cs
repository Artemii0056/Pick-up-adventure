using _ProjectFiles.Player.Scripts.Core;
using _ProjectFiles.Player.Scripts.Resolvers;
using _ProjectFiles.Slots.Scripts.View;

namespace _ProjectFiles.Interaction.Scripts.Core
{
    public interface IItemTransferService
    {
        bool TryTakeItem(IHandService handService, ItemView itemView);
        bool TryPlaceToSlot(IHandService handService, SlotView slotView);
    }
}