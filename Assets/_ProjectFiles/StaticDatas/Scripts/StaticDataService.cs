using System.Collections.Generic;
using System.Linq;
using _ProjectFiles.Chest.Configs;
using _ProjectFiles.Keys.Config;
using _ProjectFiles.Player.Scripts.Movements;
using _ProjectFiles.Player.Scripts.Rotation._ProjectFiles.Player.Scripts.Movements.Configs;
using _ProjectFiles.ResourceLoader.Scripts;
using _ProjectFiles.ValveDoor.Configs;

namespace _ProjectFiles.StaticDatas.Scripts
{
    public class StaticDataService : IStaticDataService
    {
        private readonly IResourceLoader _resourceLoader;

        private List<ChestConfig> _chestConfigs;
        private List<KeyConfig> _keyConfigs;
        private List<ValveConfig> _valveConfigs;

        public PlayerRotationConfig PlayerRotationConfig { get; private set; }
        public PlayerMovementConfig PlayerMovementConfig{ get; private set; }

        public StaticDataService(IResourceLoader resourceLoader)
        {
            _resourceLoader = resourceLoader;
            
            LoadChestConfigs();
            LoadKeyConfigs();
            LoadValveConfigs();
            
            LoadRotationConfig();
            LoadMovementConfig();
        }

        private void LoadChestConfigs() =>
            _chestConfigs = _resourceLoader.LoadAll<ChestConfig>(Constants.ChestConfigPath).ToList();

        private void LoadKeyConfigs() =>
            _keyConfigs = _resourceLoader.LoadAll<KeyConfig>(Constants.KeyConfigPath).ToList();

        private void LoadValveConfigs() =>
            _valveConfigs = _resourceLoader.LoadAll<ValveConfig>(Constants.ValveConfigPath).ToList();

        private void LoadRotationConfig() => 
            PlayerRotationConfig = _resourceLoader.Load<PlayerRotationConfig>("PlayerRotationConfig");

        private void LoadMovementConfig() => 
            PlayerMovementConfig = _resourceLoader.Load<PlayerMovementConfig>("PlayerMovementConfig");
    }
}