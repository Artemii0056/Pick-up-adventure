using _ProjectFiles.GlobalId.Scripts;
using _ProjectFiles.ValveDoor.Scripts.Data;
using _ProjectFiles.ValveDoor.Scripts.View;

namespace _ProjectFiles.ValveDoor.Scripts.Spawner
{
    public class ValveSpawner : IValveSpawner
    {
        private readonly IGlobalIdService _globalIdService;
        private readonly IValveStorage _valveStorage;

        public ValveSpawner(
            IGlobalIdService globalIdService,
            IValveStorage valveStorage)
        {
            _globalIdService = globalIdService;
            _valveStorage = valveStorage;
        }

        public void Spawn(ValveSceneData valveSceneData)
        {
            if (valveSceneData.Config == null)
                return;

            int valveId = _globalIdService.GetNext();

            ValveModel model = new ValveModel(valveId, valveSceneData.Config);
            _valveStorage.AddState(model);

            ValveView valveView = UnityEngine.Object.Instantiate(
                valveSceneData.Config.Prefab,
                valveSceneData.Transform.position,
                valveSceneData.Transform.rotation);

            valveView.SetId(valveId);
            valveView.Initialize(valveSceneData.Config, valveSceneData.DoorTransform);
            valveView.Render(0f);
        }
    }
}