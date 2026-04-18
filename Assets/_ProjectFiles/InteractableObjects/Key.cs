using _ProjectFiles.RaycastResolvers.Scripts;
using UnityEngine;

namespace _ProjectFiles.InteractableObjects
{
    public class Key : InteractableEntity
    {
        [field: SerializeField] public ChestKeyType ChestKeyType { get; private set; }
    }
}