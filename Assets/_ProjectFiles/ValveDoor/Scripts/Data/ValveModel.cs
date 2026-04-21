using _ProjectFiles.Interaction.Scripts.Data;
using UnityEngine;

namespace _ProjectFiles.ValveDoor.Scripts.Data
{
    public class ValveModel
    {
        public ValveModel(int id, ValveConfig config)
        {
            Id = id;
            Type = InteractableItemType.Valve;
            Config = config;
        }
        
        public int Id { get; }
        public InteractableItemType Type { get; }
        public ValveConfig Config { get; }
        public float Progress { get; private set; }

        public void SetProgress(float value)
        {
            Progress = Mathf.Clamp01(value);
        }
    }
}