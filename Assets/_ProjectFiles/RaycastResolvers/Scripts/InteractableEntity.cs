using _ProjectFiles.InteractableObjects.Scripts;
using UnityEngine;

namespace _ProjectFiles.RaycastResolvers.Scripts
{
    public class InteractableEntity : MonoBehaviour 
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