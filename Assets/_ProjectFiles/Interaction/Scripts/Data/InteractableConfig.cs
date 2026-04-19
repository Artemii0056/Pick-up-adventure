using System;
using UnityEngine;

namespace _ProjectFiles.Interaction.Scripts.Data
{
    [Serializable]
    public class InteractableConfig 
    {
        [field: SerializeField] public InteractionInputType InteractionInputType { get; private set; }
        
        [field: SerializeField] public string Info { get; private set; }
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public string ActionLabel { get; private set; }
    }
}
