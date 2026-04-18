using _ProjectFiles.Interaction.Scripts.Data;
using UnityEngine;

namespace _ProjectFiles.Keys.Config
{
    [CreateAssetMenu(fileName = nameof(KeyConfig), menuName = "StaticData/Interactable" + nameof(KeyConfig))]
    public class KeyConfig : ScriptableObject
    {
        [field: SerializeField] public InteractableConfig InteractableConfig { get; private set; }
    }
}