using _ProjectFiles.Interaction.Scripts.Core;
using _ProjectFiles.Interaction.Scripts.Data;
using _ProjectFiles.Player.Scripts.Resolvers;
using _ProjectFiles.ValveDoor.Scripts.View;

namespace _ProjectFiles.ValveDoor.Scripts.Logic
{
    public class ValveInteractionFeature : IInteractionFeature
    {
        public InteractableItemType Type => InteractableItemType.Valve;

        public InteractData GetInteractData(Player.Scripts.Core.Player player, ItemView itemView)
        {
            return new InteractData
            {
                CanInteract = true,
                ActionName = "Крутить",
            };
        }

        public void Interact(Player.Scripts.Core.Player player, ItemView itemView)
        {
            ValveView valveView = (ValveView)itemView;
            
            valveView.RotateStep();
        }
    }
}