using _ProjectFiles.Interaction.Scripts.Core.TransferServices;
using _ProjectFiles.Player.Scripts.Input.InputReader.Scripts;
using _ProjectFiles.Player.Scripts.Resolvers;
using _ProjectFiles.StateMachine;
using _ProjectFiles.StateMachine.States;
using _ProjectFiles.UI;
using UnityEngine;
using VContainer;
using Object = UnityEngine.Object;

namespace _ProjectFiles.Items.Scripts.Logic
{
    public class FirstPickUpFlow : IFirstPickUpItemFlow
    {
        private readonly IPlayerInputReader _inputReader;
        private readonly IStoragePickedUpItems _storagePickedUpItems;
        private readonly IItemTransferService _transferService;
        private readonly IItemStorage _itemStorage;
        private readonly IStateMachine _stateMachine;
        
        private PickUpCanvas _pickUpCanvas;
        private Transform _currentPreview;

        private readonly InspectItemRotationHandler _inspectItemRotationHandler;

        private GameObject _currentPreviewInstance;

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
            CurrentItemView = itemView;

            ItemModel itemModel = _itemStorage.GetState(itemView.Id);
            if (itemModel == null)
                return;

            IsActive = true;

            _pickUpCanvas.gameObject.SetActive(true);
            
            _currentPreviewInstance = _pickUpCanvas.SetInfo(
                itemModel.Config.Description,
                itemModel.Config.PreviewPrefab);

            _currentPreview = _currentPreviewInstance.transform;

            _inspectItemRotationHandler.SetTarget(_currentPreview);
        }

        public void Hide()
        {
            if (IsActive == false)
                return;
            
            IsActive = false;
            _pickUpCanvas.gameObject.SetActive(false);

            _inspectItemRotationHandler.ClearTarget(); //TODO Убрать? 

            // if (_currentPreviewInstance != null)
            //     Object.Destroy(_currentPreviewInstance);

            _currentPreviewInstance = null;
            _currentPreview = null;
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

            _storagePickedUpItems.AddState(itemModel.Type, itemModel.Id);
            _transferService.TryTakeItem(itemView);
        }
    }
}