namespace _ProjectFiles.Note.Script.Data
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