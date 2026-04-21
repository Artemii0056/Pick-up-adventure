using _ProjectFiles.StateMachine.Data;

namespace _ProjectFiles.StateMachine.States
{
    public class DialogState: IPayloadState<DialogueData>
{
    private readonly IDialogueService _dialogueService;
    private readonly IGameStateMachine _stateMachine;

    public DialogState(
        IDialogueService dialogueService,
        IGameStateMachine stateMachine)
    {
        _dialogueService = dialogueService;
        _stateMachine = stateMachine;
    }

    public void Enter()
    {
    }

    public void Enter(DialogueData payload)
    {
        _dialogueService.Show(payload);
    }

    public void Exit()
    {
        _dialogueService.Hide();
    }

    public void Tick()
    {
        _dialogueService.Tick();
    }
}

    public interface IDialogueService
    {
        void Show(DialogueData payload);
        void Hide();
        void Tick();
    }

    public class DialogueData
    {
    }
}