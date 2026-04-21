using _ProjectFiles.Interaction.Scripts.Core.TransferServices;
using _ProjectFiles.Items.Note.Script.Data;
using _ProjectFiles.Items.Note.Script.View;
using _ProjectFiles.Items.Scripts.Data;
using _ProjectFiles.Items.Scripts.Inspection;
using _ProjectFiles.Player.Scripts.Input.InputReader.Scripts;
using _ProjectFiles.Player.Scripts.Resolvers;
using _ProjectFiles.StateMachine;
using _ProjectFiles.StateMachine.States;
using _ProjectFiles.UI;
using VContainer;

namespace _ProjectFiles.Items.Scripts.Logic
{
    public class FirstPickUpFlow : IFirstPickUpItemFlow
    {
        private readonly IPlayerInputReader _inputReader;
        private readonly IStoragePickedUpItems _storagePickedUpItems;
        private readonly IItemTransferService _transferService;
        private readonly IItemStorage _itemStorage;
        private readonly IStateMachine _stateMachine;
        private readonly InspectItemRotationHandler _inspectItemRotationHandler;

        private PickUpCanvas _pickUpCanvas;

        public FirstPickUpFlow(
            IPlayerInputReader inputReader,
            IStoragePickedUpItems storagePickedUpItems,
            IItemTransferService transferService,
            IItemStorage itemStorage,
            IStateMachine stateMachine,
            InspectItemRotationHandler inspectItemRotationHandler)
        {
            _inputReader = inputReader;
            _storagePickedUpItems = storagePickedUpItems;
            _transferService = transferService;
            _itemStorage = itemStorage;
            _stateMachine = stateMachine;
            _inspectItemRotationHandler = inspectItemRotationHandler;

            _inputReader.InteractStarted += OnInteractStarted;
        }

        [Inject]
        public void Construct(PickUpCanvas pickUpCanvas)
        {
            _pickUpCanvas = pickUpCanvas;
        }

        public bool IsActive { get; private set; }
        public ItemView CurrentItemView { get; private set; }

        public void Show(ItemView itemView)
        {
            ItemModel itemModel = _itemStorage.GetState(itemView.Id);

            if (itemModel == null)
                return;

            CurrentItemView = itemView;
            IsActive = true;

            _pickUpCanvas.gameObject.SetActive(true);
            _pickUpCanvas.SetInfo(itemModel.Config.Description);

            _transferService.MoveToInspect(itemView, _pickUpCanvas.InspectAnchor);
            _inspectItemRotationHandler.SetTarget(itemView.transform);
            
            if (itemView is NoteView noteView && itemModel.Config is NoteItemConfig noteConfig)
                noteView.Open(noteConfig);
        }

        public void Hide()
        {
            if (!IsActive)
                return;

            IsActive = false;
            _pickUpCanvas.gameObject.SetActive(false);
            _inspectItemRotationHandler.ClearTarget();
            CurrentItemView = null;

            _stateMachine.Enter<GamePlayState>();
        }

        private void OnInteractStarted()
        {
            if (!IsActive || CurrentItemView == null)
                return;

            ItemModel itemModel = _itemStorage.GetState(CurrentItemView.Id);

            if (itemModel == null)
                return;

            ItemView itemView = CurrentItemView;

            Hide();

            _transferService.TryTakeItem(itemView);
        }
    }
}