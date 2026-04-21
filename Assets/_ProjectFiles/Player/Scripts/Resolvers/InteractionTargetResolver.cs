using _ProjectFiles.Interaction.Scripts.View;
using _ProjectFiles.Player.Scripts.Raycast.Scripts;
using UnityEngine;

namespace _ProjectFiles.Player.Scripts.Resolvers
{
    public class InteractionTargetResolver : IInteractionTargetResolver
    {
        private readonly IRaycastService _raycastService;

        public InteractionTargetResolver(IRaycastService raycastService)
        {
            _raycastService = raycastService;
        }

        public bool TryResolveTarget(Camera camera, float distance, LayerMask layerMask, out InteractableView entity)
        {
            entity = null;

            if (camera == null)
                return false;

            var ray = new Ray(camera.transform.position, camera.transform.forward);

            if (!_raycastService.Raycast(ray, distance, layerMask, out var hit))
                return false;

            if (!hit.collider.TryGetComponent(out InteractableView searchedEntity))
                return false;

            entity = searchedEntity;
            return true;
        }
    }
}