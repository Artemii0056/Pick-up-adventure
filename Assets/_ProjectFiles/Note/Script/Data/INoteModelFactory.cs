using _ProjectFiles.Items.Scripts.Data;

namespace _ProjectFiles.Note.Script.Data
{
    public interface INoteModelFactory
    {
        NoteModel CreateNoteModel(int id, ItemType type);
    }
}