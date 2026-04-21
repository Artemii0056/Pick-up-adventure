using _ProjectFiles.Interaction.Scripts.View;
using _ProjectFiles.NPC.Scripts.Data;
using UnityEngine;

namespace _ProjectFiles.NPC.Scripts.View
{
    public class NpcView : InteractableView
    {
        public NpcConfig Config { get; private set; }

        public void Initialize(NpcConfig config)
        {
            Config = config;
        }
    }
}