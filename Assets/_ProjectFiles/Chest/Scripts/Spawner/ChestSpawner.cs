using _ProjectFiles.Bootstrap;
using _ProjectFiles.Chest.Scripts.Data;
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
            int chestId = _globalIdService.GetNext();
            _chestStorage.AddState(new ChestModel(chestId, InteractableItemType.Chest));
        }
    }
}