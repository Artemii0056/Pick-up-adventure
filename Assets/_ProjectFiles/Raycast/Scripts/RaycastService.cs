using UnityEngine;

namespace _ProjectFiles.Raycast.Scripts
{
    public class RaycastService : IRaycastService
    {
        public bool Raycast(Ray ray, float distance, LayerMask layerMask, out RaycastHit hit) => 
            Physics.Raycast(ray, out hit, distance, layerMask);

        public bool Raycast(Vector3 origin, Vector3 direction, float distance, LayerMask layerMask, out RaycastHit hit) => 
            Physics.Raycast(origin, direction, out hit, distance, layerMask);
    }
}
