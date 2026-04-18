using _ProjectFiles.Interaction.Scripts.Core;
using _ProjectFiles.Interaction.Scripts.Data;
using _ProjectFiles.Player.Scripts.Resolvers;

namespace _ProjectFiles.NPC.Scripts.Logic
{
    public class NpcInteractionFeature : IInteractionFeature
    {
        public InteractableItemType Type => InteractableItemType.NPC;
        
        public InteractData GetInteractData(Player.Scripts.Core.Player player, ItemView itemView)
        {
            throw new System.NotImplementedException();
        }

        public void Interact(Player.Scripts.Core.Player player, ItemView itemView)
        {
            throw new System.NotImplementedException();
        }
    }
}