using _ProjectFiles.Chest.Scripts.Data;
using _ProjectFiles.Items.Scripts.Data;
using _ProjectFiles.Player.Scripts.Resolvers;
using _ProjectFiles.Slots.Scripts.View;
using UnityEngine;

namespace _ProjectFiles
{
    public class KeySlotStarter : MonoBehaviour
    {
        [field: SerializeField] public SlotView SlotView { get; private set; }
        [field: SerializeField] public int ItemId { get; private set; }
        [field: SerializeField] public ItemType ItemType { get; private set; }
        [field: SerializeField] public ChestKeyType ChestKeyType { get; private set; }
        [field: SerializeField] public ItemView ItemPrefab { get; private set; }
    }
}