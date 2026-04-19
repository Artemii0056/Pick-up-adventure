using _ProjectFiles.Items.Scripts.Data;

namespace _ProjectFiles.Note.Script.Data
{
    public interface INoteModelFactory
    {
        NoteModel CreateKeyModel(int id, ItemType type);
    }
}