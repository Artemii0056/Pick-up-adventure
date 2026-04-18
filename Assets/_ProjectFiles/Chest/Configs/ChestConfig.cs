using _ProjectFiles.Interaction.Scripts.Data;
using UnityEngine;

namespace _ProjectFiles.Chest.Configs
{
    [CreateAssetMenu(fileName = nameof(ChestConfig), menuName = "StaticData/Interactable" + nameof(ChestConfig))]
    public class ChestConfig : ScriptableObject
    {
        [field: SerializeField] public InteractableConfig InteractableConfig { get; private set; }
    }
}