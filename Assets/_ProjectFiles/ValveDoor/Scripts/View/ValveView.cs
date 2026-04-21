using _ProjectFiles.Interaction.Scripts.View;
using _ProjectFiles.ValveDoor.Scripts.Data;
using _ProjectFiles.ValveDoor.Scripts.Logic;
using UnityEngine;

namespace _ProjectFiles.ValveDoor.Scripts.View
{
    public class ValveView : InteractableView
    {
        [SerializeField] private ValveVisual _visual;

        public void Initialize(ValveConfig config, Transform doorTransform)
        {
            _visual.Initialize(config, doorTransform);
        }

        public void Render(float progress)
        {
            _visual.Render(progress);
        }
    }
}