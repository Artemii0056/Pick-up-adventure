using _ProjectFiles.ValveDoor.Scripts.Data;
using _ProjectFiles.ValveDoor.Scripts.View;
using UnityEngine;

namespace _ProjectFiles.ValveDoor.Scripts.Logic
{
    public interface IValveRotationService
    {
        void StartRotate(ValveView valveView);
        void StopRotate();
        void Tick();
    }

   
}