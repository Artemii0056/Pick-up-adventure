using _ProjectFiles.Bootstrap;
using _ProjectFiles.GlobalId.Scripts;
using _ProjectFiles.NPC.Scripts.Data;
using _ProjectFiles.NPC.Scripts.View;

namespace _ProjectFiles.NPC.Scripts.Spawner
{
    public class NpcSpawner : INpcSpawner
    {
        private readonly IGlobalIdService _globalIdService;
        private readonly INpcStorage _npcStorage;

        public NpcSpawner(IGlobalIdService globalIdService, INpcStorage npcStorage)
        {
            _globalIdService = globalIdService;
            _npcStorage = npcStorage;
        }

        public void Spawn(NpcSceneData npcSceneData)
        {
            if (npcSceneData.Config == null)
                return;

            int npcId = _globalIdService.GetNext();

            NpcModel npcModel = new NpcModel(npcId, npcSceneData.Config);
            _npcStorage.AddState(npcModel);

            NpcView npcView = UnityEngine.Object.Instantiate(
                npcSceneData.Config.Prefab,
                npcSceneData.Transform.position,
                npcSceneData.Transform.rotation);

            npcView.SetId(npcId);
        }
    }
}