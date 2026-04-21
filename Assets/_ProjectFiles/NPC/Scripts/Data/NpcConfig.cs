using _ProjectFiles.NPC.Scripts.Data.Quests;
using _ProjectFiles.NPC.Scripts.View;
using UnityEngine;

namespace _ProjectFiles.NPC.Scripts.Data
{
    [CreateAssetMenu(fileName = nameof(NpcConfig), menuName = "StaticData/NPC/" + nameof(NpcConfig))]
    public class NpcConfig : ScriptableObject
    {
        [field: SerializeField] public NpcView Prefab { get; private set; }

        [Header("Regular dialogues")]
        [field: SerializeField] public NpcDialogueSet[] RegularDialogues { get; private set; }
        [field: SerializeField] public string DefaultDialogueId { get; private set; }

        [Header("Quest")]
        [field: SerializeField] public NpcQuestConfig QuestConfig { get; private set; }

        public bool HasQuest => QuestConfig != null;
    }
}