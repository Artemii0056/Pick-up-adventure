using _ProjectFiles.Interaction.Scripts.View;
using UnityEngine;

namespace _ProjectFiles.ValveDoor.Scripts.View
{
    public class ValveView : InteractableView
    {
        public void RotateStep()
        {
           Debug.Log("Rotating Valve");
        }

        public void Render(float activeModelProgress)
        {
            
        }
    }
}