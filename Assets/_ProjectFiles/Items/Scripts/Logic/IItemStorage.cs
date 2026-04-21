using System.Collections.Generic;
using _ProjectFiles.Items.Scripts.Data;

namespace _ProjectFiles.Items.Scripts.Logic
{
    public interface IItemStorage
    {
        void AddState(ItemModel item);
        ItemModel GetState(int id);
        IReadOnlyCollection<ItemModel> GetAll();
    }
}