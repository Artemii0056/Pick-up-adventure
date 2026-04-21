using UnityEngine;

namespace _ProjectFiles.Bootstrap
{
    public class SceneData : MonoBehaviour
    {
        [SerializeField] private SlotSpawnData[] _slots;
        [SerializeField] private ChestSceneData _chest;

        public SlotSpawnData[] Slots => _slots;
        public ChestSceneData Chest => _chest;
    }
}