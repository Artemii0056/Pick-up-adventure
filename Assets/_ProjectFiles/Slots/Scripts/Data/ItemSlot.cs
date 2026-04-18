using UnityEngine;

namespace _ProjectFiles.Slots.Scripts.Data
{
    public class ItemSlot : MonoBehaviour
    {
        public int Id { get; private set; }

        public void Set(int id) => 
            Id = id;
    }
}