using System;
using _ProjectFiles.Items.Scripts.Logic;
using _ProjectFiles.Player.Scripts.Resolvers;

namespace _ProjectFiles.Player.Scripts.Core
{
    public class PlayerHandService : IHandService
    {
        private readonly PlayerHandModel _playerHandModel;
        private IItemStorage _itemStorage;

        public PlayerHandService(PlayerHandModel playerHandModel, IItemStorage itemStorage)
        {
            _playerHandModel = playerHandModel;
            _itemStorage = itemStorage;
        }

        public ItemView CurrentItemView { get; private set; }

        public bool HasItem => _playerHandModel.HasItem;
        public ItemModel CurrentItem => _playerHandModel.ItemModel;

        public void Put(ItemModel item, ItemView view)
        {
            if (_playerHandModel.HasItem)
                throw new InvalidOperationException("Hand already contains an item.");
            
            CurrentItemView = view;

            _playerHandModel.Set(item);
        }

        public void Clear()
        {
            _playerHandModel.Clear();
        }
    }
}