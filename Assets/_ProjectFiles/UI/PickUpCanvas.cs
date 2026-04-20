using TMPro;
using UnityEngine;

namespace _ProjectFiles.UI
{
    public class PickUpCanvas : MonoBehaviour
    {
        [field: SerializeField] public Transform PreviewRoot { get; private set; }
        [SerializeField] private TextMeshProUGUI _textMeshProUGUI;

        private GameObject _currentPreviewInstance;

        public GameObject SetInfo(string text, GameObject prefab)
        {
            SetText(text);
            return SetItemView(prefab);
        }

        public void ClearPreview()
        {
            if (_currentPreviewInstance != null)
                Destroy(_currentPreviewInstance);

            _currentPreviewInstance = null;
        }

        private void SetText(string text) =>
            _textMeshProUGUI.text = text;

        private GameObject SetItemView(GameObject itemView)
        {
            ClearPreview();

            if (itemView == null)
                return null;

            _currentPreviewInstance = Instantiate(itemView, PreviewRoot);
            _currentPreviewInstance.transform.localPosition = Vector3.zero;
            _currentPreviewInstance.transform.localRotation = Quaternion.identity;
            _currentPreviewInstance.transform.localScale = Vector3.one;

            SetLayerRecursively(_currentPreviewInstance, LayerMask.NameToLayer("InspectItem"));

            return _currentPreviewInstance;
        }

        private void SetLayerRecursively(GameObject obj, int layer)
        {
            obj.layer = layer;

            foreach (Transform child in obj.transform)
                SetLayerRecursively(child.gameObject, layer);
        }
    }
}