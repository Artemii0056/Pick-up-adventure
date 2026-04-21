using _ProjectFiles.Interaction.Scripts.View;
using _ProjectFiles.NPC.Scripts.Data;
using UnityEngine;

namespace _ProjectFiles.NPC.Scripts.View
{
    public class NpcView : InteractableView
    {
        [SerializeField] private NpcConfig _config;

        public NpcConfig Config => _config;
    }
}