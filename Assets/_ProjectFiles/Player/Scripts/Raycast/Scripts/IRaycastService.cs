using UnityEngine;

namespace _ProjectFiles.Player.Scripts.Raycast.Scripts
{
    public interface IRaycastService
    {
        bool Raycast(Ray ray, float distance, LayerMask layerMask, out RaycastHit hit);
    }
}