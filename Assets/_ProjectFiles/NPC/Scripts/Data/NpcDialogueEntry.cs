using System;
using _ProjectFiles.DialogueSystem.Scripts.Data;
using UnityEngine;

namespace _ProjectFiles.NPC.Scripts.Data
{
    [Serializable]
    public class NpcDialogueEntry
    {
        [field: SerializeField] public string Id { get; private set; }
        [field: SerializeField] public DialogueConfig Dialogue { get; private set; }
    }
}