using TMPro;
using UnityEngine;

namespace _ProjectFiles.UI
{
    public class PickUpCanvas : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textMeshProUGUI;
        [SerializeField] private Transform _itemContainer;

        public void SetInfo(string text, GameObject prefab) 
        {
            SetText(text);
           SetItemView(prefab);
        }

        private void SetText(string text) => 
            _textMeshProUGUI.text = text;

        private void SetItemView(GameObject itemView) => 
            Instantiate(itemView, _itemContainer);
    }
}