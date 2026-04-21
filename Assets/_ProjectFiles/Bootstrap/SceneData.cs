using UnityEngine;

namespace _ProjectFiles.Bootstrap
{
    public class SceneData : MonoBehaviour
    {
        [SerializeField] private SlotSpawnData[] _slots;

        public SlotSpawnData[] Slots => _slots;
    }
}