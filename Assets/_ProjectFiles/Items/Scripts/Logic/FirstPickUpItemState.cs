using _ProjectFiles.Interaction.Scripts.Core;
using _ProjectFiles.Interaction.Scripts.Core.TransferServices;
using _ProjectFiles.Player.Scripts.Input.InputReader.Scripts;
using _ProjectFiles.Player.Scripts.Resolvers;
using _ProjectFiles.UI;
using UnityEngine;
using VContainer;

namespace _ProjectFiles.Items.Scripts.Logic
{
    public class FirstPickUpItemState : IFirstPickUpItemState
    {
        private readonly IPlayerInputReader _inputReader;
        private PickUpCanvas _pickUpCanvas;
        private Transform _currentPreview;
        private readonly IStoragePickedUpItems _storagePickedUpItems;
        private readonly IItemTransferService _transferService;
        private readonly IItemStorage _itemStorage;
        
        private GameObject _currentPreviewInstance;

        public FirstPickUpItemState(IPlayerInputReader inputReader,
            IStoragePickedUpItems storagePickedUpItems,
            IItemTransferService transferService, 
            IItemStorage itemStorage)
        {
            _inputReader = inputReader;
            _storagePickedUpItems = storagePickedUpItems;
            _transferService = transferService;
            _itemStorage = itemStorage;
            _inputReader.InteractStarted += OnInteractStarted;
        }

        [Inject]
        public void Construct(PickUpCanvas pickUpCanvas)
        {
            _pickUpCanvas = pickUpCanvas;
        }

        public bool IsActive { get; set; }
        public ItemView CurrentItemView { get; set; }

        public void Show(ItemView itemView)
        {
            CurrentItemView = itemView;
            IsActive = true;

            _pickUpCanvas.gameObject.SetActive(true);
            _currentPreviewInstance = _pickUpCanvas.SetInfo(itemView.Description, itemView.Prefab);
        }

        public void Hide()
        {
            IsActive = false;
            _pickUpCanvas.gameObject.SetActive(false);
            Object.Destroy(_currentPreviewInstance.gameObject);
            _currentPreviewInstance = null;
            CurrentItemView = null;
        }

        public void Tick()
        {
            if (!IsActive)
                return;

            if (_currentPreview == null)
                return;

            Vector2 look = _inputReader.LookValue;

            if (look == Vector2.zero)
                return;

            float rotateSpeed = 2.5f;

            _currentPreview.Rotate(Vector3.up, -look.x * rotateSpeed, Space.World);
            _currentPreview.Rotate(Vector3.right, look.y * rotateSpeed, Space.Self);
        }

        public void OnInteractStarted()
        {
            var itemView = CurrentItemView;
            
            if (!IsActive || CurrentItemView == null)
                return;

            ItemModel itemModel = _itemStorage.GetState(CurrentItemView.Id);

            if (itemModel == null)
                return;

            Hide();
            _storagePickedUpItems.AddState(itemModel.Type, itemModel.Id);
            _transferService.TryTakeItem(itemView);
            
        }
    }
}