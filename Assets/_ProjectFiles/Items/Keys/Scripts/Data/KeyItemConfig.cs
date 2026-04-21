using _ProjectFiles.Chest.Scripts.Data;
using _ProjectFiles.Items.Scripts;
using UnityEngine;

namespace _ProjectFiles.Items.Keys.Scripts.Data
{
    [CreateAssetMenu(fileName = nameof(KeyItemConfig), menuName = "StaticData/Interactable/" + nameof(KeyItemConfig))]
    public class KeyItemConfig : BaseItemConfig 
    {
        [field: SerializeField] public ChestKeyType ChestKeyType { get; private set; }
    }
}