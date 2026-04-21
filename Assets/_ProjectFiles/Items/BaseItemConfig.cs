using _ProjectFiles.Items.Scripts.Data;
using _ProjectFiles.Player.Scripts.Resolvers;
using UnityEngine;

namespace _ProjectFiles.Items
{
    public class BaseItemConfig : ScriptableObject
    {
        [field: SerializeField] public ItemType Type { get; private set; } 
        
        [field: SerializeField] public ItemView Prefab { get; private set; } 
    }
}