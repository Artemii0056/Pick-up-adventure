using _ProjectFiles.Interaction.Scripts.View;
using _ProjectFiles.Items.Scripts.Data;
using UnityEngine;

namespace _ProjectFiles.Player.Scripts.Resolvers
{
    public class ItemView : InteractableView
    {
        [field: SerializeField] public ItemType ItemType { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
        [field: SerializeField] public GameObject Prefab { get; private set; }
    }
}