using _ProjectFiles.Items.Scripts.Data;

namespace _ProjectFiles.Note.Script.Data
{
    public class NoteItemModel : ItemModel
    {
        public NoteItemModel(int id, ItemType type, string content) : base(id, type)
        {
            Content = content;
        }
        
        public string Content { get; private set; }
    }
}