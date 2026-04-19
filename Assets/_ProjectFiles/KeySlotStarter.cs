using _ProjectFiles.Chest.Scripts.Data;
using UnityEngine;

namespace _ProjectFiles
{
    public class KeySlotStarter : ItemSlotStarter
    {
        [field: SerializeField] public ChestKeyType ChestKeyType { get; private set; }
    }
}