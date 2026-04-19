using _ProjectFiles.Chest.Scripts.Data;
using _ProjectFiles.Player.Scripts.Resolvers;
using UnityEngine;

namespace _ProjectFiles.Keys.Scripts.View
{
    public class KeyView : ItemView
    {
        [field: SerializeField] public ChestKeyType ChestKeyType { get; private set; }
    }
}