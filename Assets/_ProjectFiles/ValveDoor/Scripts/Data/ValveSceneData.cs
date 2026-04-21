using System;
using UnityEngine;

namespace _ProjectFiles.ValveDoor.Scripts.Data
{
     [Serializable]
    public class ValveSceneData
    {
        [field: SerializeField] public ValveConfig Config { get; private set; }
        [field: SerializeField] public Transform Transform { get; private set; }
        [field: SerializeField] public Transform DoorTransform { get; private set; }
    }
}