
using UnityEngine;

namespace _ProjectFiles.Player.Scripts.LookRotation
{
    public interface ILookRotationHandler
    {
        void Handle(Vector2 lookDelta);
    }
}