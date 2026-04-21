using _ProjectFiles.Dialogue.Scripts.Data;
using _ProjectFiles.Dialogue.Scripts.Logic;
using _ProjectFiles.StateMachine.Data;

namespace _ProjectFiles.StateMachine.States
{
    public class DialogState : IPayloadState<DialogueData>
    {
        private readonly IDialogueService _dialogueService;

        public DialogState(IDialogueService dialogueService)
        {
            _dialogueService = dialogueService;
        }

        public void Enter(DialogueData payload)
        {
            _dialogueService.StartDialogue(payload.DialogueConfig);
        }

        public void Exit()
        {
            _dialogueService.Close();
        }

        public void Tick()
        {
            _dialogueService.Tick();
        }
    }
}