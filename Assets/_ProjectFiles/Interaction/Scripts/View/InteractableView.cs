using _ProjectFiles.Interaction.Scripts.Data;
using UnityEngine;

namespace _ProjectFiles.Interaction.Scripts.View
{
    public class InteractableView : MonoBehaviour
    {
        [field: SerializeField] public InteractableItemType InteractableItemType { get; private set; }
        [field: SerializeField] public InteractionInputType InteractionInputType { get; private set; }
        
        public int Id { get; private set; }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}