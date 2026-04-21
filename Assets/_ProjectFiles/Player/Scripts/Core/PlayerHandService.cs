using System;
using _ProjectFiles.Items.Scripts.Data;
using _ProjectFiles.Items.Scripts.Logic;
using _ProjectFiles.Player.Scripts.Resolvers;
using UnityEditor;
using UnityEngine;
using Object = System.Object;

namespace _ProjectFiles.Player.Scripts.Core
{
    public class PlayerHandService : IHandService
    {
        private readonly PlayerHandModel _playerHandModel;

        public PlayerHandService() => 
            _playerHandModel = new PlayerHandModel();

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
            
            UnityEngine.Object.Destroy(CurrentItemView.gameObject);
        }
    }
}