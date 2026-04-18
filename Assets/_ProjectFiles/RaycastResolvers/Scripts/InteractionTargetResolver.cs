using _ProjectFiles.Raycast.Scripts;
using UnityEngine;

namespace _ProjectFiles.RaycastResolvers.Scripts
{
    public class InteractionTargetResolver
    {
        private readonly IRaycastService _raycastService;

        public InteractionTargetResolver(IRaycastService raycastService)
        {
            _raycastService = raycastService;
        }

        public bool TryResolveTarget(Camera camera, float distance, LayerMask mask, out ItemView target) 
            //тут мне нужен объект, по которому навели. Он будет хранить свой тип и глобальный Id - условный InteractableEntityView
            //Склоняюсь к фабрикам и разным коллекциям по хранению объектов. Не хочется делать общий с дальнейшими кастами 
        {
            target = null;

            if (camera == null)
                return false;

            var ray = new Ray(camera.transform.position, camera.transform.forward);

            if (!_raycastService.Raycast(ray, distance, mask, out var hit))
                return false;

            if (!hit.collider.TryGetComponent(out ItemView entity))
                return false;

            target = entity;
            return true;
        }
    }
}