using _ProjectFiles.Items;
using _ProjectFiles.Items.Scripts.Data;

namespace _ProjectFiles.World.Scripts.Factory
{
    public interface IWorldItemFactory
    {
        ItemModel Create(int id, BaseItemConfig config);
    }
}