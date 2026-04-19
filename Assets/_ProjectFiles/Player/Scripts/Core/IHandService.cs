namespace _ProjectFiles.Player.Scripts.Core
{
    public interface IHandService
    {
        void Put(ItemModel item);
        void Clear();
        bool HasItem { get; }
        ItemModel CurrentItem { get;}
    }
}