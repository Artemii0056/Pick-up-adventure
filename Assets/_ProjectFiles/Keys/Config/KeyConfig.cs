using UnityEngine;

namespace _ProjectFiles.InteractableObjects.Scripts
{
    [CreateAssetMenu(fileName = nameof(KeyConfig), menuName = "StaticData/Interactable" + nameof(KeyConfig))]
    public class KeyConfig : ScriptableObject
    {
        [field: SerializeField] public InteractableConfig InteractableConfig { get; private set; }
    }
}