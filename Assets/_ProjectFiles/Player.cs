using _ProjectFiles.Raycast.Scripts;
using _ProjectFiles.RaycastResolvers.Scripts;
using UnityEngine;

namespace _ProjectFiles
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private bool _debug;

        private InteractionTargetResolver _interactionTargetResolver;

        private IRaycastService _raycastService;

        private void Awake()
        {
            _raycastService = new RaycastService();
            _interactionTargetResolver = new InteractionTargetResolver(_raycastService);
        }

        public void Init()
        {
        }

        private void Update()
        {
            DrawDebug();

            if (_interactionTargetResolver.TryResolveTarget(Camera.main, 5f, _layerMask, out InteractableEntity entity))
            {
                Debug.Log(entity.InteractableType.ToString());
            }
        }

        private void DrawDebug()
        {
#if UNITY_EDITOR
            if (!_debug)
                return;

            var camera = Camera.main;
            Debug.DrawRay(
                camera.transform.position,
                camera.transform.forward * 5f,
                Color.green
            );
#endif
        }
    }
}