using UnityEngine;

namespace _ProjectFiles.InteractableObjects.Scripts
{
    [CreateAssetMenu(fileName = nameof(ValveConfig), menuName = "StaticData/Interactable" + nameof(ValveConfig))]
    public class ValveConfig : ScriptableObject
    {
        [field: SerializeField] public InteractableConfig InteractableConfig { get; private set; }
    }
}