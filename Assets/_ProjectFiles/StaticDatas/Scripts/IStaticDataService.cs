using _ProjectFiles.Player.Scripts.Movements;
using _ProjectFiles.Player.Scripts.Rotation._ProjectFiles.Player.Scripts.Movements.Configs;

namespace _ProjectFiles.StaticDatas.Scripts
{
    public interface IStaticDataService
    {
        PlayerRotationConfig PlayerRotationConfig { get; }
        PlayerMovementConfig PlayerMovementConfig { get; }
    }
}