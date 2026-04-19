using UnityEngine;

namespace _ProjectFiles.Player.Scripts.Core
{
    public interface IPlayerInteractionController
    {
        void SetLayer(LayerMask interactionLayerMask);
        void Tick();
        void Start();
        void Dispose();
    }
}