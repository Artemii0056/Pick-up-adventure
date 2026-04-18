using UnityEngine;

namespace _ProjectFiles.Cameras.Scripts
{
    public interface ICameraProvider
    {
        Camera Camera { get; }
    }
}