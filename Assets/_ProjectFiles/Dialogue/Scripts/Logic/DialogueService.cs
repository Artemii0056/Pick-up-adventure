using System;
using _ProjectFiles.Dialogue.Scripts.Data;
using _ProjectFiles.Dialogue.Scripts.Logic.Quest;
using UnityEngine;
using VContainer;

namespace _ProjectFiles.Dialogue.Scripts.Logic
{
    public class DialogueService : IDialogueService
    {
        private DialogueConfig _currentConfig;
        private DialogueCanvas _dialogueCanvas;
        private INpcQuestService _questService;

        public event Action<DialogueNode> NodeChanged;
        public event Action DialogueClosed;

        public bool IsActive { get; private set; }
        public DialogueNode CurrentNode { get; private set; }

        [Inject]
        public void Construct(DialogueCanvas dialogueCanvas, INpcQuestService questService)
        {
            _dialogueCanvas = dialogueCanvas;
            _questService = questService;
        }

        public void StartDialogue(DialogueConfig config)
        {
            if (config == null)
                return;

            _currentConfig = config;
            IsActive = true;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            _dialogueCanvas.Show();
            MoveToNode(config.StartNodeId);
        }

        public void SelectChoice(int index)
        {
            if (!IsActive || CurrentNode == null)
                return;

            if (CurrentNode.Choices == null || index < 0 || index >= CurrentNode.Choices.Count)
                return;

            string nextNodeId = CurrentNode.Choices[index].NextNodeId;
            MoveToNode(nextNodeId);
        }

        public void Close()
        {
            IsActive = false;
            CurrentNode = null;
            _currentConfig = null;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            _dialogueCanvas.Hide();
            DialogueClosed?.Invoke();
        }

        public void Tick()
        {
        }

        private void MoveToNode(string nodeId)
        {
            if (_currentConfig == null)
                return;

            DialogueNode node = _currentConfig.GetNode(nodeId);

            if (node == null)
            {
                Debug.LogError($"Dialogue node not found: {nodeId}");
                return;
            }

            CurrentNode = node;

            ExecuteAction(node.Action);

            if (!IsActive || CurrentNode == null)
                return;

            _dialogueCanvas.SetNode(CurrentNode, SelectChoice, Close);
            _dialogueCanvas.UpdateQuest(_questService.GetQuestText(), _questService.HasActiveQuest);

            NodeChanged?.Invoke(CurrentNode);
        }

        private void ExecuteAction(DialogueNodeAction action)
        {
            switch (action)
            {
                case DialogueNodeAction.None:
                    break;

                case DialogueNodeAction.StartFetchQuest:
                    _questService.StartQuest();
                    break;

                case DialogueNodeAction.TryCompleteFetchQuest:
                    bool success = _questService.TryCompleteQuest();
                    MoveToNode(success ? "success_end" : "fail_end");
                    break;
            }
        }
    }
}