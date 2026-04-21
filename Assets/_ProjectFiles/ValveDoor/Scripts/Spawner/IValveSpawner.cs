using _ProjectFiles.ValveDoor.Scripts.Data;

namespace _ProjectFiles.ValveDoor.Scripts.Spawner
{
    public interface IValveSpawner
    {
        void Spawn(ValveSceneData valveSceneData);
    }
}