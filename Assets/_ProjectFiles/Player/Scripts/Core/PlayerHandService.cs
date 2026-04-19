using System;
using _ProjectFiles.Items.Scripts.Logic;

namespace _ProjectFiles.Player.Scripts.Core
{
    public class PlayerHandService : IHandService
    {
        private PlayerHandModel _playerHandModel;
        private IItemStorage _itemStorage;

        public PlayerHandService(PlayerHandModel playerHandModel, IItemStorage itemStorage)
        {
            _playerHandModel = playerHandModel;
            _itemStorage = itemStorage;
        }

        public bool HasItem => _playerHandModel.HasItem;
        public ItemModel CurrentItem => _playerHandModel.ItemModel;

        public void Put(ItemModel item)
        {
            if (_playerHandModel.HasItem)
                throw new InvalidOperationException("Hand already contains an item.");

            _playerHandModel.Set(item);
        }
        
        public void Clear()
        {
            _playerHandModel.Clear();
        }
    }
}