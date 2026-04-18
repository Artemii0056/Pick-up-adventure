using _ProjectFiles.Interaction.Scripts.Data;
using UnityEngine;

namespace _ProjectFiles.ValveDoor.Configs
{
    [CreateAssetMenu(fileName = nameof(ValveConfig), menuName = "StaticData/Interactable" + nameof(ValveConfig))]
    public class ValveConfig : ScriptableObject
    {
        [field: SerializeField] public InteractableConfig InteractableConfig { get; private set; }
    }
}