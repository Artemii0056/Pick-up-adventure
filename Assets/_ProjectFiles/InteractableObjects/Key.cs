using DefaultNamespace;
using UnityEngine;

namespace _ProjectFiles.InteractableObjects
{
    public class Key : Item
    {
        [field: SerializeField] public ChestKeyType ChestKeyType { get; private set; }
    }
}