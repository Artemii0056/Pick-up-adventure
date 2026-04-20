using System;
using _ProjectFiles.GlobalId.Scripts;
using _ProjectFiles.Items.Scripts.Logic;
using _ProjectFiles.Keys.Scripts.Data;
using _ProjectFiles.Note.Script.Data;
using _ProjectFiles.Player.Scripts.Input.InputReader.Scripts;
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
        private IFirstPickUpItemState _firstPickUpItemState;
        
        [SerializeField] private KeySlotStarter _keySlotStarter;
        [SerializeField] private NoteSlotStarter _noteSlotStarter;

        [Inject]
        public void Init(IKeyModelFactory keyModelFactory, ISlotModelFactory slotModelFactory, IGlobalIdService globalIdService, INoteModelFactory noteModelFactory, IFirstPickUpItemState firstPickUpItemState)
        {
            _keyModelFactory = keyModelFactory;
            _slotModelFactory = slotModelFactory;
            _globalIdService = globalIdService;
            _noteModelFactory = noteModelFactory;
            _firstPickUpItemState = firstPickUpItemState;
        }   
        
        private void Start()
        {
            KeySlotInitializer keySlotInitializer = new KeySlotInitializer(_keyModelFactory, _slotModelFactory, _globalIdService);
            keySlotInitializer.Initialize(_keySlotStarter);
            
            NoteSlotInitializer noteSlotInitializer  = new NoteSlotInitializer(_slotModelFactory, _globalIdService, _noteModelFactory);
            noteSlotInitializer.Initialize(_noteSlotStarter);
        }

        private void Update() //TODO На тест
        {
            if (_firstPickUpItemState.IsActive)
            {
                _firstPickUpItemState.Tick();
            }
        }
    }
}