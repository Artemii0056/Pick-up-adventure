using _ProjectFiles.Chest.Scripts.View;
using UnityEngine;

namespace _ProjectFiles.Chest.Scripts.Data
{
    [CreateAssetMenu(fileName = nameof(ChestConfig), menuName = "StaticData/Chest")]
    public class ChestConfig : ScriptableObject
    {
        [field: SerializeField] public ChestView Prefab { get; private set; }
        [field: SerializeField] public ChestKeyType KeyType { get; private set; }

        [field: SerializeField] public string ActionName { get; private set; } = "Открыть";
        [field: SerializeField] public string OpenAnimationParam { get; private set; } = "IsOpen";
    }
}