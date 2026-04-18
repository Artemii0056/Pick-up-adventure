using _ProjectFiles.Slots.Scripts.Data;
using UnityEngine;

namespace _ProjectFiles.Slots.Config
{
    public class SlotConfig
    {
        [field: SerializeField] private int _id;
        [field: SerializeField] private SlotRuleType _ruleType;
        [field: SerializeField] private GameObject _slotPrefab;
    }
}