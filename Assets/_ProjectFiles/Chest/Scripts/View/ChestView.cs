using _ProjectFiles.Chest.Scripts.Data;
using _ProjectFiles.Player.Scripts.Resolvers;
using UnityEngine;

namespace _ProjectFiles.Chest.Scripts.View
{
    public class ChestView : ItemView
    {
       [field: SerializeField] public ChestKeyType KeyType { get; private set; }

        public bool IsOpen { get; private set; } = false;

        public void Open()
        {
            IsOpen = true;
        }
    }
}