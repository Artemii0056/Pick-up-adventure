using System;
using System.Collections.Generic;
using _ProjectFiles.GlobalId.Scripts;
using _ProjectFiles.Items;
using _ProjectFiles.Items.Scripts.Logic;
using _ProjectFiles.Keys.Scripts.Data;
using _ProjectFiles.Knifes.Scripts.Data;
using _ProjectFiles.Note.Script.Data;
using _ProjectFiles.Player.Scripts.Resolvers;
using _ProjectFiles.Slots.Scripts.Data;
using _ProjectFiles.Slots.Scripts.View;
using _ProjectFiles.StaticDatas.Scripts;
using UnityEngine;
using VContainer;

namespace _ProjectFiles.Bootstrap
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private SceneData _data;
        
        private ISlotModelFactory _slotModelFactory;
        private IGlobalIdService _globalIdService;
        private IFirstPickUpItemState _firstPickUpItemState;
        private IValveRotationService _valveRotationService;
        private  IItemStorage _itemStorage;

        [Inject]
        public void Init(
            ISlotModelFactory slotModelFactory, 
            IGlobalIdService globalIdService,
            IFirstPickUpItemState firstPickUpItemState,
            IValveRotationService valveRotationService, 
            IItemStorage itemStorage)
        {
            _slotModelFactory = slotModelFactory;
            _globalIdService = globalIdService;
            _firstPickUpItemState = firstPickUpItemState;
            _valveRotationService = valveRotationService;
            _itemStorage = itemStorage;

        }

        private void Start()
        {
            Load(_data);

        }

        public void Load(SceneData data)
        {
            foreach (var slot in data.Slots)
            {
                int slotId = _globalIdService.GetNext();

                SlotView slotView = Instantiate(
                    slot.SlotPrefab,
                    slot.Position.position,
                    slot.Position.rotation);

                slotView.SetId(slotId);

                if (slot.ItemConfig == null)
                {
                    _slotModelFactory.Create(SlotRuleType.Universal, slotId);
                    continue;
                }

                int itemId = _globalIdService.GetNext();

                ItemModel itemModel = Create(itemId, slot.ItemConfig);
                _slotModelFactory.Create(slotId, itemModel);

                ItemView itemView = Instantiate(
                    slot.ItemConfig.Prefab,
                    slotView.ItemAnchor.position,
                    slotView.ItemAnchor.rotation,
                    slotView.ItemAnchor);

                itemView.SetId(itemId);
                slotView.SetItemView(itemView);
            }
        }
        
        public ItemModel Create(int id, BaseItemConfig config)
        {
            ItemModel model = config switch
            {
                KeyItemConfig keyConfig => new KeyItemModel(id, keyConfig.Type, keyConfig.ChestKeyType),
                NoteItemConfig noteConfig => new NoteItemModel(id, noteConfig.Type, noteConfig.Content.Text),
                KnifeItemConfig knifeConfig => new KnifeItemModel(id, knifeConfig.Type, knifeConfig.Damage),
                _ => throw new ArgumentOutOfRangeException(nameof(config), config, "Unknown item config type")
            };

            _itemStorage.AddState(model);
            return model;
        }
        

        private void Update() //TODO На тест
        {
            if (_firstPickUpItemState.IsActive)
            {
                _firstPickUpItemState.Tick();
            }
            
            _valveRotationService.Tick();
        }
    }
}