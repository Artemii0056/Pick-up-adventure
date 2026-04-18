using _ProjectFiles.Interaction.Scripts.Data;
using UnityEngine;

namespace _ProjectFiles.Interaction.Scripts.View
{
    public class InteractableView : MonoBehaviour
    {
        [field: SerializeField] public int Id { get; private set; }
        [field: SerializeField] public InteractableItemType InteractableItemType { get; private set; }

        public void Init(int id, InteractableItemType interactableItemType)
        {
            Id = id;
            InteractableItemType = interactableItemType;
        }
    }
}