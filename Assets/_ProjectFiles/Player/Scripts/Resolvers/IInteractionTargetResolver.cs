using _ProjectFiles.Interaction.Scripts.View;
using UnityEngine;

namespace _ProjectFiles.Player.Scripts.Resolvers
{
    public interface IInteractionTargetResolver
    {
        bool TryResolveTarget(Camera camera, float distance, LayerMask layerMask, out InteractableView entity);
    }
}