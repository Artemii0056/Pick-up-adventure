using _ProjectFiles.DialogueSystem.Scripts.Data;
using _ProjectFiles.DialogueSystem.Scripts.Logic.Quest;
using _ProjectFiles.NPC.Scripts.Data;

namespace _ProjectFiles.NPC.Scripts.Logic
{
    public class NpcDialogueResolver : INpcDialogueResolver
    {
        private readonly INpcQuestService _questService;

        public NpcDialogueResolver(INpcQuestService questService) => 
            _questService = questService;

        public DialogueConfig Resolve(NpcModel npcModel)
        {
            var config = npcModel.Config;

            if (config.HasQuest)
            {
                var questConfig = config.QuestConfig;

                if (!_questService.HasActiveQuest)
                    return questConfig.DialogueSet.StartDialogue;

                return questConfig.DialogueSet.CompletedDialogue;
            }

            return ResolveDefaultDialogue(config);
        }

        private DialogueConfig ResolveDefaultDialogue(NpcConfig config)
        {
            if (config.RegularDialogues == null || config.RegularDialogues.Length == 0)
                return null;

            foreach (var entry in config.RegularDialogues)
            {
                if (entry != null && entry.Id == config.DefaultDialogueId)
                    return entry.Dialogue;
            }

            return config.RegularDialogues[0].Dialogue;
        }
    }
}