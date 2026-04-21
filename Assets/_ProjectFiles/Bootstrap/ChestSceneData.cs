using System;
using _ProjectFiles.Chest.Scripts.Data;
using UnityEngine;

namespace _ProjectFiles.Bootstrap
{
    [Serializable]
    public class ChestSceneData
    {
        [field: SerializeField] public ChestConfig Config { get; private set; }
        [field: SerializeField] public Transform Transform { get; private set; }
        [field: SerializeField] public ChestKeyType KeyType { get; private set; }
    }
}