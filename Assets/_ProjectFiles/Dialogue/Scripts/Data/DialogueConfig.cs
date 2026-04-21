using System.Collections.Generic;
using UnityEngine;

namespace _ProjectFiles.Dialogue.Scripts.Data
{
    [CreateAssetMenu(fileName = nameof(DialogueConfig), menuName = "StaticData/Dialogue/" + nameof(DialogueConfig))]
    public class DialogueConfig : ScriptableObject
    {
        public string DialogueId;
        public string StartNodeId;
         public List<DialogueNode> Nodes;

        public DialogueNode GetNode(string id)
        {
            return Nodes.Find(x => x.Id == id);
        }
    }
}