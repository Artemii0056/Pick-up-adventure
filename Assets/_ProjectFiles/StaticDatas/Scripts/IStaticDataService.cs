using _ProjectFiles.Items;
using _ProjectFiles.Items.Keys.Scripts.Data;
using _ProjectFiles.Items.Knifes.Scripts.Data;
using _ProjectFiles.Items.Note.Script.Data;
using _ProjectFiles.Items.Scripts;
using _ProjectFiles.Items.Scripts.Data;
using _ProjectFiles.Player.Scripts.Movements;
using _ProjectFiles.Player.Scripts.Rotation._ProjectFiles.Player.Scripts.Movements.Configs;

namespace _ProjectFiles.StaticDatas.Scripts
{
    public interface IStaticDataService
    {
        PlayerRotationConfig PlayerRotationConfig { get; }
        PlayerMovementConfig PlayerMovementConfig { get; }
        KeyItemConfig KeyItemConfig { get; }
        NoteItemConfig NoteItemConfig { get; }
        KnifeItemConfig KnifeItemConfig { get; }
        void LoadAll();
        BaseItemConfig GetItemConfig(ItemType itemType);
    }
}