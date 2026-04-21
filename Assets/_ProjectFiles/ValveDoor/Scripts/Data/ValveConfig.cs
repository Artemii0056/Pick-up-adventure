using _ProjectFiles.ValveDoor.Scripts.View;
using UnityEngine;

namespace _ProjectFiles.ValveDoor.Scripts.Data
{
    [CreateAssetMenu(fileName = nameof(ValveConfig), menuName = "StaticData/Interactable/" + nameof(ValveConfig))]
    public class ValveConfig : ScriptableObject
    {
        [field: SerializeField] public ValveView Prefab { get; private set; }

        [field: SerializeField, Min(0f)] public float OpenSpeed { get; private set; } = 1f;
        [field: SerializeField, Min(0f)] public float ReturnSpeed { get; private set; } = 1f;

        [field: SerializeField, Min(0f)] public float DoorMaxOffsetY { get; private set; } = 2f;
        [field: SerializeField, Min(0f)] public float ValveMaxAngle { get; private set; } = 360f;
        [field: SerializeField] public string ActionName { get; private set; } = "Крутить";
    }
}