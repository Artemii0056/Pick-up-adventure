using _ProjectFiles.RaycastResolvers.Scripts;
using UnityEngine;

namespace _ProjectFiles
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