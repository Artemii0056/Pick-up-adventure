using _ProjectFiles.Bootstrap;
using _ProjectFiles.Chest.Scripts.Data;
using _ProjectFiles.Chest.Scripts.View;
using _ProjectFiles.GlobalId.Scripts;
using _ProjectFiles.Interaction.Scripts.Data;

namespace _ProjectFiles.Chest.Scripts.Spawner
{
    public class ChestSpawner : IChestSpawner
    {
        private readonly IGlobalIdService _globalIdService;
        private readonly IChestStorage _chestStorage;

        public ChestSpawner(IGlobalIdService globalIdService, IChestStorage chestStorage)
        {
            _globalIdService = globalIdService;
            _chestStorage = chestStorage;
        }

        public void Spawn(ChestSceneData chestSceneData)
        {
            if (chestSceneData.Config == null)
                return;

            int chestId = _globalIdService.GetNext();

            ChestModel model = new ChestModel(
                chestId,
                InteractableItemType.Chest,
                chestSceneData.Config.KeyType
            );

            _chestStorage.AddState(model);

            ChestView view = UnityEngine.Object.Instantiate(
                chestSceneData.Config.Prefab,
                chestSceneData.Transform.position,
                chestSceneData.Transform.rotation
            );

            view.Initialize(chestSceneData.Config);
            view.SetId(chestId);
        }
    }
}