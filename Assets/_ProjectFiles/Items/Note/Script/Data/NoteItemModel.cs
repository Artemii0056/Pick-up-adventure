using _ProjectFiles.Items.Scripts.Data;

namespace _ProjectFiles.Items.Note.Script.Data
{
    public class NoteItemModel : ItemModel
    {
        public NoteItemModel(int id, NoteItemConfig config) : base(id, config)
        {
            Content = config.Content.Text;
        }

        public string Content { get; }
    }
}