using UnityEngine;

namespace _ProjectFiles.Player.Scripts.Movements
{
    public interface IPlayerMover
    {
        void Tick();
        void Init(Transform playerTransform, CharacterController characterController);
    }
}