using System;
using _ProjectFiles.Items;
using UnityEngine;

namespace _ProjectFiles.Bootstrap
{
    [Serializable]
    public class ItemSceneData
    {
        public Transform Position;
        public BaseItemConfig ItemConfig;
    }
}