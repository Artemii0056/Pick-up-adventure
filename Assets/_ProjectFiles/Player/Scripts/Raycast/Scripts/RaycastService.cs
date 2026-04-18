using UnityEngine;

namespace _ProjectFiles.Player.Scripts.Raycast.Scripts
{
    public class RaycastService : IRaycastService
    {
        public bool Raycast(Ray ray, float distance, LayerMask layerMask, out RaycastHit hit) => 
            Physics.Raycast(ray, out hit, distance, layerMask);
    }
}
