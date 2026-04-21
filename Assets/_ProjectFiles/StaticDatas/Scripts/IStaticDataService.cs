using _ProjectFiles.Items;
using _ProjectFiles.Items.Scripts.Data;
using _ProjectFiles.Keys.Scripts.Data;
using _ProjectFiles.Knifes.Scripts.Data;
using _ProjectFiles.Note.Script.Data;
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