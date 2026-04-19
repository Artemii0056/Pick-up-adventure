using _ProjectFiles.Chest.Scripts.Data;
using _ProjectFiles.Items.Scripts.Data;
using Palmmedia.ReportGenerator.Core.Reporting.Builders;

namespace _ProjectFiles
{
    public class ChestModel : ItemModel
    {
        public ChestModel(int id, ItemType type, bool isOpened) : base(id, type)
        {
            Id = id;
            IsOpened = isOpened;
        }

        public int Id { get; }
        public bool IsOpened { get; private set; }
        public ChestKeyType ReqiereKeyType { get; private set; }

        public void Open()
        {
            IsOpened = true;
        }
    }
}