using _ProjectFiles.Chest.Scripts.Data;
using _ProjectFiles.Items.Scripts.Data;

namespace _ProjectFiles.Keys.Scripts.Data
{
    public interface IKeyModelFactory
    {
        KeyModel CreateKeyModel(int key, ItemType type, ChestKeyType chestKeyType);
    }
}