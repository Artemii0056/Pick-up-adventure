using TMPro;
using UnityEngine;

namespace _ProjectFiles.UI
{
    public class PickUpCanvas : MonoBehaviour
    {
        [SerializeField] private TMP_Text _descriptionText;
        [field: SerializeField] public Transform InspectAnchor { get; private set; }

        public void SetInfo(string description)
        {
            _descriptionText.text = description;
        }
    }
}