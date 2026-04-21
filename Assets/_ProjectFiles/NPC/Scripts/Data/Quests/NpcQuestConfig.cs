using _ProjectFiles.Items;
using UnityEngine;

namespace _ProjectFiles.NPC.Scripts.Data.Quests
{
    [CreateAssetMenu(fileName = nameof(NpcQuestConfig), menuName = "StaticData/NPC/" + nameof(NpcQuestConfig))]
    public class NpcQuestConfig : ScriptableObject
    {
        [field: SerializeField] public string QuestId { get; private set; }
        [field: SerializeField] public BaseItemConfig[] AvailableQuestItems { get; private set; }
        [field: SerializeField] public NpcQuestDialogueSet DialogueSet { get; private set; }
    }
}