using _ProjectFiles.Bootstrap;
using _ProjectFiles.GlobalId.Scripts;
using _ProjectFiles.Player.Scripts.Resolvers;
using _ProjectFiles.World.Scripts.Factory;

namespace _ProjectFiles.World.Scripts
{
    public class WorldItemSpawner : IWorldItemSpawner
    {
        private readonly IGlobalIdService _globalIdService;
        private readonly IWorldItemFactory _worldItemFactory;

        public WorldItemSpawner(
            IGlobalIdService globalIdService,
            IWorldItemFactory worldItemFactory)
        {
            _globalIdService = globalIdService;
            _worldItemFactory = worldItemFactory;
        }

        public void Spawn(ItemSceneData itemSceneData)
        {
            if (itemSceneData.ItemConfig == null)
                return;

            int itemId = _globalIdService.GetNext();

            _worldItemFactory.Create(itemId, itemSceneData.ItemConfig);

            ItemView itemView = UnityEngine.Object.Instantiate(
                itemSceneData.ItemConfig.Prefab,
                itemSceneData.Position.position,
                itemSceneData.Position.rotation);

            itemView.Initialize(itemSceneData.ItemConfig);
            itemView.SetId(itemId);
        }
    }
}