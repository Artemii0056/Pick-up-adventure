using System;
using _ProjectFiles.Bootstrap;
using _ProjectFiles.Chest.Scripts.Data;
using _ProjectFiles.GlobalId.Scripts;
using _ProjectFiles.Interaction.Scripts.Data;
using _ProjectFiles.Items;
using _ProjectFiles.Items.Keys.Scripts.Data;
using _ProjectFiles.Items.Knifes.Scripts.Data;
using _ProjectFiles.Items.Note.Script.Data;
using _ProjectFiles.Items.Scripts.Data;
using _ProjectFiles.Items.Scripts.Logic;
using _ProjectFiles.Player.Scripts.Resolvers;
using _ProjectFiles.Slots.Scripts.Data;
using _ProjectFiles.Slots.Scripts.View;

namespace _ProjectFiles.World
{
    public class WorldLoader : IWorldLoader
    {
        private readonly ISlotModelFactory _slotModelFactory;
        private readonly IGlobalIdService _globalIdService;
        private readonly IItemStorage _itemStorage;
        private readonly IChestStorage _chestStorage;

        public WorldLoader(
            ISlotModelFactory slotModelFactory,
            IGlobalIdService globalIdService,
            IItemStorage itemStorage, 
            IChestStorage chestStorage)
        {
            _slotModelFactory = slotModelFactory;
            _globalIdService = globalIdService;
            _itemStorage = itemStorage;
            _chestStorage = chestStorage;
        }

        public void Load(SceneData sceneData)
        {
            CreateChest(sceneData.Chest);
            
            foreach (var slot in sceneData.Slots)
            {
                int slotId = _globalIdService.GetNext();

                SlotView slotView = UnityEngine.Object.Instantiate(
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

                ItemModel itemModel = CreateItemModel(itemId, slot.ItemConfig);
                _slotModelFactory.Create(slotId, itemModel);

                ItemView itemView = UnityEngine.Object.Instantiate(
                    slot.ItemConfig.Prefab,
                    slotView.ItemAnchor.position,
                    slotView.ItemAnchor.rotation,
                    slotView.ItemAnchor);

                itemView.SetId(itemId);
                slotView.SetItemView(itemView);
                
            }
            
                foreach (var item in sceneData.QuestItems)
                    CreateWorldItem(item);
        }

        private void CreateWorldItem(ItemSceneData itemSceneData)
        {
            if (itemSceneData.ItemConfig == null)
                return;

            int itemId = _globalIdService.GetNext();

            CreateItemModel(itemId, itemSceneData.ItemConfig);

            ItemView itemView = UnityEngine.Object.Instantiate(
                itemSceneData.ItemConfig.Prefab,
                itemSceneData.Position.position,
                itemSceneData.Position.rotation);

            itemView.SetId(itemId);
        }

        private void CreateChest(ChestSceneData sceneDataChest)
        {
            int slotId = _globalIdService.GetNext();
            
            _chestStorage.AddState(new ChestModel(slotId, InteractableItemType.Chest));
        }

        private ItemModel CreateItemModel(int id, BaseItemConfig config)
        {
            ItemModel model = config switch
            {
                KeyItemConfig keyConfig => new KeyItemModel(id, keyConfig),
                NoteItemConfig noteConfig => new NoteItemModel(id, noteConfig),
                KnifeItemConfig knifeConfig => new KnifeItemModel(id, knifeConfig),
                _ => throw new ArgumentOutOfRangeException(nameof(config), config, "Unknown item config type")
            };

            _itemStorage.AddState(model);
            return model;
        }
    }
}