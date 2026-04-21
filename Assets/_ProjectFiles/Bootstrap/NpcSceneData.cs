using System;
using _ProjectFiles.NPC.Scripts.Data;
using UnityEngine;

namespace _ProjectFiles.Bootstrap
{
     [Serializable]
    public class NpcSceneData
    {
        [field: SerializeField] public Transform Transform { get; private set; }
        [field: SerializeField] public NpcConfig Config { get; private set; }
    }
}