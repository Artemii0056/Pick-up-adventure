using System;
using _ProjectFiles.Chest.Scripts.View;
using UnityEngine;

namespace _ProjectFiles.Bootstrap
{
    [Serializable]
    public class ChestSceneData
    {
        [field: SerializeField] public ChestView ChestView { get; private set; }
    }
}