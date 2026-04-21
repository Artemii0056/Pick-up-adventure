using _ProjectFiles.Items.Scripts.Data;
using _ProjectFiles.Player.Scripts.Resolvers;

namespace _ProjectFiles.Player.Scripts.Core
{
    public interface IHandService
    {
        void Put(ItemModel item, ItemView view);
        void Clear();
        bool HasItem { get; }
        ItemModel CurrentItem { get;}
        ItemView CurrentItemView { get; }
    }
}