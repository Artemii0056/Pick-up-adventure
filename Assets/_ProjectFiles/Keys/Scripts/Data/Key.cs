using _ProjectFiles.Chest.Scripts.Data;
using _ProjectFiles.Items.Scripts.Data;
using UnityEngine;

namespace _ProjectFiles.Keys.Scripts.Data
{
    public class Key : Item
    {
        [field: SerializeField] public ChestKeyType ChestKeyType { get; private set; }
    }
}