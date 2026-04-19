using _ProjectFiles.GlobalId.Scripts;
using _ProjectFiles.Keys.Scripts.Data;
using _ProjectFiles.Note.Script.Data;
using _ProjectFiles.Player.Scripts.Resolvers;
using _ProjectFiles.Slots.Scripts.Data;
using UnityEngine;

namespace _ProjectFiles
{
    public class NoteSlotInitializer
    {
        private readonly INoteModelFactory _noteModelFactory;
        private readonly ISlotModelFactory _slotModelFactory;
        private readonly IGlobalIdService _globalIdService;

        public NoteSlotInitializer(
            ISlotModelFactory slotModelFactory,
            IGlobalIdService globalIdService, 
            INoteModelFactory noteModelFactory)
        {
            _slotModelFactory = slotModelFactory;
            _globalIdService = globalIdService;
            _noteModelFactory = noteModelFactory;
        }

        public void Initialize(NoteSlotStarter starter)
        {
            SlotModel slotModel =
                _slotModelFactory.Create(starter.SlotView.SlotRuleType, starter.SlotView.Id);

            int itemId = _globalIdService.GetNext();

            NoteModel model =
                _noteModelFactory.CreateNoteModel(itemId, starter.ItemType);

            slotModel.Place(model);

            ItemView itemView =
                Object.Instantiate(starter.ItemPrefab, starter.SlotView.ItemAnchor);

            itemView.SetId(itemId);
            itemView.transform.localPosition = Vector3.zero;
            itemView.transform.localRotation = Quaternion.identity;

            starter.SlotView.SetItemView(itemView);
        }
    }
}