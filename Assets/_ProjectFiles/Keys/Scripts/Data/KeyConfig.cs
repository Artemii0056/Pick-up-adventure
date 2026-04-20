using _ProjectFiles.Interaction.Scripts.Data;
using _ProjectFiles.Keys.Scripts.View;
using UnityEngine;

namespace _ProjectFiles.Keys.Scripts.Data
{
    [CreateAssetMenu(fileName = nameof(KeyConfig), menuName = "StaticData/Interactable/" + nameof(KeyConfig))]
    public class KeyConfig : ScriptableObject
    {
        [field: SerializeField] public KeyView KeyView { get; private set; }
    }
}