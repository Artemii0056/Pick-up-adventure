using TMPro;
using UnityEngine;

namespace _ProjectFiles.UI
{
    public class InfoKeyView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        [SerializeField] private char _keyChar;
        
        public void UpdateText(string text)
        {
            _text.text = $"{_keyChar.ToString()} - {text}";
        }
    }
}