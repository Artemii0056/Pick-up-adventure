using _ProjectFiles.Bootstrap;
using _ProjectFiles.Chest.Scripts.Spawner;
using _ProjectFiles.NPC.Scripts.Spawner;
using _ProjectFiles.Slots.Scripts.Spawner;
using _ProjectFiles.ValveDoor.Scripts.Spawner;
using _ProjectFiles.World.Scripts.Factory;

namespace _ProjectFiles.World.Scripts
{
    public class WorldLoader : IWorldLoader
    {
        private readonly IChestSpawner _chestSpawner;
        private readonly ISlotSpawner _slotSpawner;
        private readonly IWorldItemSpawner _worldItemSpawner;
        private readonly INpcSpawner _npcSpawner;
        private readonly IValveSpawner _valveSpawner;

        public WorldLoader(
            IChestSpawner chestSpawner,
            ISlotSpawner slotSpawner,
            IWorldItemSpawner worldItemSpawner,
            INpcSpawner npcSpawner,
            IValveSpawner valveSpawner)
        {
            _chestSpawner = chestSpawner;
            _slotSpawner = slotSpawner;
            _worldItemSpawner = worldItemSpawner;
            _npcSpawner = npcSpawner;
            _valveSpawner = valveSpawner;
        }

        public void Load(SceneData sceneData)
        {
            _chestSpawner.Spawn(sceneData.Chest);

            foreach (var slot in sceneData.Slots)
                _slotSpawner.Spawn(slot);

            foreach (var item in sceneData.QuestItems)
                _worldItemSpawner.Spawn(item);

            foreach (var npc in sceneData.Npcs)
                _npcSpawner.Spawn(npc);

            foreach (var valve in sceneData.Valves)
                _valveSpawner.Spawn(valve);
        }
    }
}