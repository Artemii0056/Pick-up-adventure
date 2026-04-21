using System;
using _ProjectFiles.Items;
using _ProjectFiles.Items.Scripts;
using _ProjectFiles.Slots.Scripts.View;
using UnityEngine;

namespace _ProjectFiles.Bootstrap
{
    [Serializable]
    public class SlotSpawnData
    {
        public SlotView SlotPrefab;
        public Transform Position;
        public BaseItemConfig ItemConfig;
    }
}