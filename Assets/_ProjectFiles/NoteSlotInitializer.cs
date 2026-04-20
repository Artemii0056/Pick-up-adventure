using _ProjectFiles.GlobalId.Scripts;
using _ProjectFiles.Note.Script.Data;
using _ProjectFiles.Slots.Scripts.Data;

namespace _ProjectFiles
{
    public class NoteSlotInitializer : BaseSlotInitializer<NoteSlotStarter, NoteModel>
    {
        private readonly INoteModelFactory _noteModelFactory;

        public NoteSlotInitializer(
            ISlotModelFactory slotModelFactory,
            IGlobalIdService globalIdService,
            INoteModelFactory noteModelFactory)
            : base(slotModelFactory, globalIdService)
        {
            _noteModelFactory = noteModelFactory;
            _noteModelFactory = noteModelFactory;
        }

        protected override NoteModel CreateItemModel(NoteSlotStarter starter, int itemId)
        {
            return _noteModelFactory.CreateNoteModel(itemId, starter.ItemType);
        }
    }
}