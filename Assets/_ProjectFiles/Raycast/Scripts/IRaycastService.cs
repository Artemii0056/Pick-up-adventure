using UnityEngine;

namespace _ProjectFiles.Raycast.Scripts
{
    public interface IRaycastService
    {
        bool Raycast(Ray ray, float distance, LayerMask layerMask, out RaycastHit hit);
    }
}