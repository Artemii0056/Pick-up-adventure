using System;
using _ProjectFiles.Items;
using _ProjectFiles.Items.Scripts.Data;
using _ProjectFiles.Keys.Scripts.Data;
using _ProjectFiles.Knifes.Scripts.Data;
using _ProjectFiles.Note.Script.Data;
using _ProjectFiles.Player.Scripts.Movements;
using _ProjectFiles.Player.Scripts.Rotation._ProjectFiles.Player.Scripts.Movements.Configs;
using _ProjectFiles.ResourceLoader.Scripts;

namespace _ProjectFiles.StaticDatas.Scripts
{
    public class StaticDataService : IStaticDataService
    {
        private readonly IResourceLoader _resourceLoader;
        public  KeyItemConfig KeyItemConfig{ get; private set; }
        public  NoteItemConfig NoteItemConfig{ get; private set; }
        public  KnifeItemConfig KnifeItemConfig{ get; private set; } //TODO Пока не особо расширяемая система, подумать над расширением
        
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

            LoadNotePrefab();
            LoadKnifePrefab();
            LoadKeyPrefab();
        }
        
        public BaseItemConfig GetItemConfig(ItemType itemType)
        {
            return itemType switch
            {
                ItemType.Key => KeyItemConfig,
                ItemType.Note => NoteItemConfig,
                ItemType.SomeObject => KnifeItemConfig,
                _ => throw new ArgumentOutOfRangeException(nameof(itemType), itemType, "Unknown item type")
            };
        }
        
        private void LoadKnifePrefab() => 
            KnifeItemConfig = _resourceLoader.Load<KnifeItemConfig>("KnifeItemConfig"); //TODO В константы
        
        private void LoadKeyPrefab() => 
            KeyItemConfig = _resourceLoader.Load<KeyItemConfig>("KeyItemConfig");

        private void LoadNotePrefab() => 
            NoteItemConfig = _resourceLoader.Load<NoteItemConfig>("NoteItemConfig");

        private void LoadRotationConfig() => 
            PlayerRotationConfig = _resourceLoader.Load<PlayerRotationConfig>(Constants.PlayerRotationConfigPath); 

        private void LoadMovementConfig() => 
            PlayerMovementConfig = _resourceLoader.Load<PlayerMovementConfig>(Constants.PlayerMovementConfigPath);
    }
}