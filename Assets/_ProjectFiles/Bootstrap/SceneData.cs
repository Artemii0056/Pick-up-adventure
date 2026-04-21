using System.Linq;
using _ProjectFiles.ValveDoor.Scripts.Data;
using UnityEngine;

namespace _ProjectFiles.Bootstrap
{
    public class SceneData : MonoBehaviour
    {
        [SerializeField] private SlotSpawnData[] _slots;
        [SerializeField] private ChestSceneData _chest;
        [SerializeField] private ItemSceneData[] _questItems;
        [SerializeField] private NpcSceneData[] _npcs;
        [SerializeField] public ValveSceneData[] _valve;

        public SlotSpawnData[] Slots => _slots.ToArray();
        public ChestSceneData Chest => _chest;
        public ItemSceneData[] QuestItems => _questItems.ToArray();
        public NpcSceneData[] Npcs => _npcs.ToArray();
        
        public ValveSceneData[] Valves => _valve.ToArray();
    }
}