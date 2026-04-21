using System;
using _ProjectFiles.DialogueSystem.Scripts.Data;
using _ProjectFiles.DialogueSystem.Scripts.Logic.Quest;
using UnityEngine;
using VContainer;

namespace _ProjectFiles.DialogueSystem.Scripts.Logic
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
            _dialogueCanvas.UpdateQuest(_questService.GetQuestText(), _questService.HasActiveQuest);

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

            if (TryExecuteActionAndRedirect(node))
                return;

            _dialogueCanvas.SetNode(CurrentNode, SelectChoice, Close);
            _dialogueCanvas.UpdateQuest(_questService.GetQuestText(), _questService.HasActiveQuest);
            NodeChanged?.Invoke(CurrentNode);
        }

        private bool TryExecuteActionAndRedirect(DialogueNode node)
        {
            switch (node.Action)
            {
                case DialogueNodeAction.None:
                    return false;

                case DialogueNodeAction.StartFetchQuest:
                    _questService.StartQuest();
                    _dialogueCanvas.UpdateQuest(_questService.GetQuestText(), _questService.HasActiveQuest);
                    return false;

                case DialogueNodeAction.TryCompleteFetchQuest:
                    bool success = _questService.TryCompleteQuest();
                    _dialogueCanvas.UpdateQuest(_questService.GetQuestText(), _questService.HasActiveQuest);

                    string nextNodeId = success ? node.SuccessNextNodeId : node.FailNextNodeId;

                    if (string.IsNullOrWhiteSpace(nextNodeId))
                    {
                        Debug.LogError($"Next node is not configured for action on node {node.Id}");
                        return false;
                    }

                    MoveToNode(nextNodeId);
                    return true;

                default:
                    return false;
            }
        }
    }
}