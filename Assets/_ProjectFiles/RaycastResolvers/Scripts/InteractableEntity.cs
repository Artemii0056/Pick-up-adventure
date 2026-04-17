using _ProjectFiles.InteractableObjects.Scripts;
using UnityEngine;

namespace _ProjectFiles.RaycastResolvers.Scripts
{
    public class InteractableEntity : MonoBehaviour
    {
       [field: SerializeField] public InteractableType InteractableType { get; private set; }
    }
}