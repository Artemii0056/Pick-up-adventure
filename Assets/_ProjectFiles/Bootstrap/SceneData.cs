using UnityEngine;

namespace _ProjectFiles.Bootstrap
{
    public class SceneData : MonoBehaviour
    {
        [SerializeField] private SlotSpawnData[] _slots;
        [SerializeField] private ChestSceneData _chest;
        [SerializeField] private ItemSceneData[] _questItems;

        public SlotSpawnData[] Slots => _slots;
        public ChestSceneData Chest => _chest;
        public ItemSceneData[] QuestItems => _questItems;
    }
}