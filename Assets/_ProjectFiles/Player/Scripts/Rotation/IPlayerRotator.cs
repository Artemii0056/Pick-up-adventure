using UnityEngine;

namespace _ProjectFiles.Player.Scripts.Rotation
{
    public interface IPlayerRotator
    {
        void Init(Transform cameraRoot, Transform player);
        void Tick();
    }
}