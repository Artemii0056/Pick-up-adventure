using _ProjectFiles;
using UnityEngine;

namespace DefaultNamespace
{
    public class Item : MonoBehaviour //TODO Обязательно разделить это(логику работы) на вьюшку и модель!!!
    {
        [field: SerializeField] public ItemType ItemType { get; private set; }
    }
}