using _ProjectFiles.Bootstrap;
using _ProjectFiles.GlobalId.Scripts;
using _ProjectFiles.Items.Scripts.Data;
using _ProjectFiles.Player.Scripts.Resolvers;
using _ProjectFiles.Slots.Scripts.Data;
using _ProjectFiles.Slots.Scripts.View;
using _ProjectFiles.World.Scripts.Factory;

namespace _ProjectFiles.Slots.Scripts.Spawner
{
    public class SlotSpawner : ISlotSpawner
    {
        private readonly ISlotModelFactory _slotModelFactory;
        private readonly IGlobalIdService _globalIdService;
        private readonly IWorldItemFactory _itemFactory;

        public SlotSpawner(
            ISlotModelFactory slotModelFactory,
            IGlobalIdService globalIdService,
            IWorldItemFactory itemFactory)
        {
            _slotModelFactory = slotModelFactory;
            _globalIdService = globalIdService;
            _itemFactory = itemFactory;
        }

        public void Spawn(SlotSpawnData slotSceneData)
        {
            int slotId = _globalIdService.GetNext();

            SlotView slotView = UnityEngine.Object.Instantiate(
                slotSceneData.SlotPrefab,
                slotSceneData.Position.position,
                slotSceneData.Position.rotation);

            slotView.SetId(slotId);

            if (slotSceneData.ItemConfig == null)
            {
                _slotModelFactory.Create(SlotRuleType.Universal, slotId);
                return;
            }

            int itemId = _globalIdService.GetNext();

            ItemModel itemModel = _itemFactory.Create(itemId, slotSceneData.ItemConfig);
            _slotModelFactory.Create(slotId, itemModel);

            ItemView itemView = UnityEngine.Object.Instantiate(
                slotSceneData.ItemConfig.Prefab,
                slotView.ItemAnchor.position,
                slotView.ItemAnchor.rotation,
                slotView.ItemAnchor);

            itemView.SetId(itemId);
            slotView.SetItemView(itemView);
        }
    }
}