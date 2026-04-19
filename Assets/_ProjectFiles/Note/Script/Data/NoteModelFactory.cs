using _ProjectFiles.Items.Scripts.Data;
using _ProjectFiles.Items.Scripts.Logic;

namespace _ProjectFiles.Note.Script.Data
{
    public class NoteModelFactory : INoteModelFactory
    {
        private readonly IItemStorage _itemStorage;

        public NoteModelFactory(IItemStorage itemStorage) => 
            _itemStorage = itemStorage;

        public NoteModel CreateNoteModel(int id, ItemType type)
        {
            NoteModel noteModel = new NoteModel(id, type);
            
            _itemStorage.AddState(noteModel);
            
            return noteModel;
        }
    }
}