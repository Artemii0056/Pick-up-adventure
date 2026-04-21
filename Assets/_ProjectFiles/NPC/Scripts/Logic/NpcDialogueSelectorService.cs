using System.Collections.Generic;
using _ProjectFiles.DialogueSystem;
using _ProjectFiles.DialogueSystem.Scripts.Data;
using _ProjectFiles.DialogueSystem.Scripts.Logic;
using _ProjectFiles.DialogueSystem.Scripts.Logic.Quest;
using _ProjectFiles.NPC.Scripts.Data;
using _ProjectFiles.NPC.Scripts.Data.Quests;
using UnityEngine;

namespace _ProjectFiles.NPC.Scripts.Logic
{
    public class NpcDialogueSelectorService : INpcDialogueSelectorService
    {
        private readonly INpcStorage _npcStorage;
        private readonly INpcQuestService _questService;
        private readonly IDialogueService _dialogueService;
        private readonly DialogueCanvas _dialogueCanvas;

        public NpcDialogueSelectorService(
            INpcStorage npcStorage,
            INpcQuestService questService,
            IDialogueService dialogueService,
            DialogueCanvas dialogueCanvas)
        {
            _npcStorage = npcStorage;
            _questService = questService;
            _dialogueService = dialogueService;
            _dialogueCanvas = dialogueCanvas;
        }

        public void StartDialogue(int npcId)
        {
            if (!_npcStorage.TryGetState(npcId, out NpcModel npcModel))
            {
                return;
            }

            List<DialogueSelectorOption> options = BuildOptions(npcModel.Config);

            if (options.Count == 0)
            {
                return;
            }

            if (options.Count == 1)
            {
                _dialogueService.StartDialogue(options[0].Dialogue);
                return;
            }

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            _dialogueCanvas.ShowSelector(
                "Что хочешь обсудить?",
                options,
                index => _dialogueService.StartDialogue(options[index].Dialogue),
                CloseSelector);
        }

        private List<DialogueSelectorOption> BuildOptions(NpcConfig config)
        {
            List<DialogueSelectorOption> options = new();

            AddRegularOptions(options, config);
            AddQuestOption(options, config);

            return options;
        }

        private void AddRegularOptions(List<DialogueSelectorOption> options, NpcConfig config)
        {
            if (config.RegularDialogues == null || config.RegularDialogues.Length == 0)
                return;

            foreach (var entry in config.RegularDialogues)
            {
                if (entry == null || entry.Dialogue == null)
                    continue;

                options.Add(new DialogueSelectorOption(entry.Title, entry.Dialogue));
            }
        }

        private void AddQuestOption(List<DialogueSelectorOption> options, NpcConfig config)
        {
            if (!config.HasQuest || config.QuestConfig == null)
                return;

            DialogueConfig questDialogue = ResolveQuestDialogue(config.QuestConfig);

            if (questDialogue == null)
                return;

            options.Add(new DialogueSelectorOption(config.QuestConfig.Title, questDialogue));
        }

        private DialogueConfig ResolveQuestDialogue(NpcQuestConfig questConfig)
        {
            if (!_questService.HasActiveQuest)
                return questConfig.DialogueSet.StartDialogue;

            return questConfig.DialogueSet.CompletedDialogue;
        }

        private void CloseSelector()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            _dialogueCanvas.Hide();
        }
    }
}