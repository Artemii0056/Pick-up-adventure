using _ProjectFiles;
using _ProjectFiles.Keys.Scripts.Data;
using _ProjectFiles.Player.Scripts.Resolvers;
using _ProjectFiles.Slots.Scripts.Data;
using UnityEngine;

public class KeySlotInitializer
{
    private readonly IKeyModelFactory _keyModelFactory;
    private readonly ISlotModelFactory _slotModelFactory;

    public KeySlotInitializer(
        IKeyModelFactory keyModelFactory,
        ISlotModelFactory slotModelFactory)
    {
        _keyModelFactory = keyModelFactory;
        _slotModelFactory = slotModelFactory;
    }

    public void Initialize(KeySlotStarter starter)
    {
        SlotModel slotModel = _slotModelFactory.Create(starter.SlotView.SlotRuleType, starter.SlotView.Id);

        KeyModel keyModel = _keyModelFactory.CreateKeyModel(
            starter.ItemId,
            starter.ItemType,
            starter.ChestKeyType);

        slotModel.Place(keyModel);

        ItemView itemView = Object.Instantiate(starter.ItemPrefab, starter.SlotView.ItemAnchor);
        itemView.transform.localPosition = Vector3.zero;
        itemView.transform.localRotation = Quaternion.identity;

        starter.SlotView.SetItemView(itemView);
    }
}