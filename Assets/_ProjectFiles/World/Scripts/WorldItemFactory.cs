using System;
using _ProjectFiles.Items;
using _ProjectFiles.Items.Keys.Scripts.Data;
using _ProjectFiles.Items.Knifes.Scripts.Data;
using _ProjectFiles.Items.Note.Script.Data;
using _ProjectFiles.Items.Scripts;
using _ProjectFiles.Items.Scripts.Data;
using _ProjectFiles.Items.Scripts.Logic;
using _ProjectFiles.World.Scripts.Factory;

namespace _ProjectFiles.World.Scripts
{
    public class WorldItemFactory : IWorldItemFactory
    {
        private readonly IItemStorage _itemStorage;

        public WorldItemFactory(IItemStorage itemStorage)
        {
            _itemStorage = itemStorage;
        }

        public ItemModel Create(int id, BaseItemConfig config)
        {
            ItemModel model = config switch
            {
                KeyItemConfig keyConfig => new KeyItemModel(id, keyConfig),
                NoteItemConfig noteConfig => new NoteItemModel(id, noteConfig),
                KnifeItemConfig knifeConfig => new KnifeItemModel(id, knifeConfig),
                _ => throw new ArgumentOutOfRangeException(nameof(config), config, "Unknown item config type")
            };

            _itemStorage.AddState(model);
            return model;
        }
    }
}