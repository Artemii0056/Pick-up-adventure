using _ProjectFiles.Chest.Scripts.Data;
using _ProjectFiles.Items.Scripts.Data;
using _ProjectFiles.Items.Scripts.Logic;

namespace _ProjectFiles.Keys.Scripts.Data
{
    public class KeyModelFactory : IKeyModelFactory
    {
        private readonly IItemStorage _itemStorage;

        public KeyModelFactory(IItemStorage itemStorage) => 
            _itemStorage = itemStorage;

        public KeyModel CreateKeyModel(int key, ItemType type, ChestKeyType chestKeyType)
        {
            KeyModel keyModel = new KeyModel(key, type, chestKeyType);
            
            _itemStorage.AddState(keyModel);
            
            return keyModel;
        }
    }
}