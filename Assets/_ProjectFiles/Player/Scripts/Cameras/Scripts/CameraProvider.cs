using UnityEngine;

namespace _ProjectFiles.Player.Scripts.Cameras.Scripts
{
    public class CameraProvider : ICameraProvider
    {
        public CameraProvider(Camera camera) => 
            Camera = camera;

        public Camera Camera { get; }
    }
}