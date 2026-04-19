using System;
using System.Collections.Generic;
using _ProjectFiles.Interaction.Scripts.Core;
using _ProjectFiles.Interaction.Scripts.Data;
using _ProjectFiles.Interaction.Scripts.View;
using _ProjectFiles.Player.Scripts.Core;
using _ProjectFiles.Slots.Scripts.Data;
using _ProjectFiles.Slots.Scripts.View;

namespace _ProjectFiles.Slots.Scripts.Logic
{
    public class SlotInteractionFeature : IInteractionFeature
    {
        private readonly ISlotStorage _slotStorage;

        public SlotInteractionFeature(ISlotStorage slotStorage)
        {
            _slotStorage = slotStorage;
        }

        public InteractableItemType Type => InteractableItemType.Slot;

        public bool TryGetInteractData(IHandService handService, InteractableView interactableView, out InteractData data)
        {
            data = default;

            if (interactableView is not SlotView slotView)
                return false;

            // if (handService.HasItem == false) //это странно
            //     return false;

            SlotModel slotModel = _slotStorage.GetState(slotView.Id);

            if (slotModel == null)
                return false;

            if (!slotModel.CanPlace(handService.CurrentItem))
                return false;

            data = new InteractData
            {
                CanInteract = true,
                ActionName = "Положить"
            };

            return true;
        }

        public void Interact(IHandService handService, InteractableView interactableView)
        {
            if (interactableView is not SlotView slotView)
                return;

            if (!handService.HasItem)
                return;

            SlotModel slotModel = _slotStorage.GetState(slotView.Id);

            if (slotModel == null)
                return;

            if (!slotModel.CanPlace(handService.CurrentItem))
                return;

            slotModel.Place(handService.CurrentItem);
            handService.Clear();

            // Тут потом:
            // 1. визуально вернуть предмет в slotView.ItemAnchor
            // 2. обновить slotView.CurrentItemView
        }
    }

    public class SlotStorage : ISlotStorage //TODO Обязательно сделать один дженериковый класс!
    {
        private readonly Dictionary<int, SlotModel> _slots = new();

        public void AddState(SlotModel item)
        {
            if (_slots.ContainsKey(item.Id))
                throw new InvalidOperationException($"Item with id {item.Id} already exists.");
            
            _slots.Add(item.Id, item);
        }

        public SlotModel GetState(int id)
        {
            if (_slots.ContainsKey(id) == false)
                throw new KeyNotFoundException(); 
            
            return _slots[id];
        }
    }

    public interface ISlotStorage
    {
        void AddState(SlotModel item);
        SlotModel GetState(int id);
    }
}