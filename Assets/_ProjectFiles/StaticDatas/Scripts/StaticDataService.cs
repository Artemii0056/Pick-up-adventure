using System.Collections.Generic;
using System.Linq;
using _ProjectFiles.Chest.Scripts.Data;
using _ProjectFiles.Keys.Scripts.Data;
using _ProjectFiles.Keys.Scripts.View;
using _ProjectFiles.Player.Scripts.Movements;
using _ProjectFiles.Player.Scripts.Rotation._ProjectFiles.Player.Scripts.Movements.Configs;
using _ProjectFiles.ResourceLoader.Scripts;
using Unity.VisualScripting;
using UnityEngine;

namespace _ProjectFiles.StaticDatas.Scripts
{
    public class StaticDataService : IStaticDataService
    {
        private readonly IResourceLoader _resourceLoader;
        private List<KeyConfig> _keyConfigs;

        public PlayerRotationConfig PlayerRotationConfig { get; private set; }
        public PlayerMovementConfig PlayerMovementConfig{ get; private set; }
        
        public StaticDataService(IResourceLoader resourceLoader)
        {
            _resourceLoader = resourceLoader;
            LoadAll();
        }
        
        public void LoadAll()
        {
            LoadRotationConfig();
            LoadMovementConfig();
            LoadKeysPrefab();
        }

        public KeyConfig GetKeyByType(ChestKeyType type)
        {
            foreach (var config in _keyConfigs)
            {
                if (config.KeyView.ChestKeyType == type)
                    return config;
            }
            
            throw new KeyNotFoundException($"Chest key type {type} not found");
        }

        private void LoadKeysPrefab() => 
            _keyConfigs = _resourceLoader.LoadAll<KeyConfig>("KeysConfigs").ToList();

        private void LoadRotationConfig() => 
            PlayerRotationConfig = _resourceLoader.Load<PlayerRotationConfig>("PlayerRotationConfig"); //TODO В Константу

        private void LoadMovementConfig() => 
            PlayerMovementConfig = _resourceLoader.Load<PlayerMovementConfig>("PlayerMovementConfig");
    }
}