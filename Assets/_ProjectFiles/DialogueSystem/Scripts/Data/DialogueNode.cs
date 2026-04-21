using System;
using System.Collections.Generic;
using UnityEngine;

namespace _ProjectFiles.DialogueSystem.Scripts.Data
{
    [Serializable]
    public class DialogueNode
    {
        public string Id;

        [field: SerializeField, TextArea(3, 8)]
        public string Text;

        public bool IsEnd;
        public DialogueNodeAction Action;

        public string SuccessNextNodeId;
        public string FailNextNodeId;

        public List<DialogueChoice> Choices;
    }
}