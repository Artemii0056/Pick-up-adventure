using _ProjectFiles.GlobalId.Scripts;
using _ProjectFiles.Keys.Scripts.Data;
using _ProjectFiles.Note.Script.Data;
using _ProjectFiles.Slots.Scripts.Data;
using UnityEngine;
using VContainer;

namespace _ProjectFiles.Bootstrap
{
    public class Bootstrapper : MonoBehaviour
    {
        private IKeyModelFactory _keyModelFactory;
        private ISlotModelFactory _slotModelFactory;
        private IGlobalIdService _globalIdService;
        private INoteModelFactory _noteModelFactory;
        
        [SerializeField] private KeySlotStarter _keySlotStarter;
        [SerializeField] private NoteSlotStarter _noteSlotStarter;
        
        [Inject]
        public void Init(IKeyModelFactory keyModelFactory, ISlotModelFactory slotModelFactory, IGlobalIdService globalIdService, INoteModelFactory noteModelFactory)
        {
            _keyModelFactory = keyModelFactory;
            _slotModelFactory = slotModelFactory;
            _globalIdService = globalIdService;
            _noteModelFactory = noteModelFactory;
        }   
        
        private void Start()
        {
            KeySlotInitializer keySlotInitializer = new KeySlotInitializer(_keyModelFactory, _slotModelFactory, _globalIdService);
            keySlotInitializer.Initialize(_keySlotStarter);
            
            NoteSlotInitializer noteSlotInitializer  = new NoteSlotInitializer(_slotModelFactory, _globalIdService, _noteModelFactory);
            noteSlotInitializer.Initialize(_noteSlotStarter);
        }
    }
}