using UnityEngine;

namespace _ProjectFiles.InteractableObjects.Scripts
{
    [CreateAssetMenu(fileName = nameof(ChestConfig), menuName = "StaticData/Interactable" + nameof(ChestConfig))]
    public class ChestConfig : ScriptableObject
    {
        [field: SerializeField] public InteractableConfig InteractableConfig { get; private set; }
    }
}