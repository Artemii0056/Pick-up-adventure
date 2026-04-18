using UnityEngine;

namespace _ProjectFiles.Items.Scripts.Data
{
    public class Item : MonoBehaviour //TODO Обязательно разделить это(логику работы) на вьюшку и модель!!!
    {
        [field: SerializeField] public ItemType ItemType { get; private set; }
    }
}