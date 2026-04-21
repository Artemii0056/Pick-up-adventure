using System;
using _ProjectFiles.Items;
using _ProjectFiles.Items.Scripts;
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