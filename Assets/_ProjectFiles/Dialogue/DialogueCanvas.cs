using System;
using System.Collections.Generic;
using _ProjectFiles.Dialogue.Scripts.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _ProjectFiles.Dialogue
{
    public class DialogueCanvas : MonoBehaviour
    {
        [SerializeField] private GameObject _root;
        [SerializeField] private TextMeshProUGUI _replicaText;
        [SerializeField] private Transform _choicesRoot;
        [SerializeField] private Button _choiceButtonPrefab;
        [SerializeField] private Button _closeButton;

        [SerializeField] private GameObject _questRoot;
        [SerializeField] private TextMeshProUGUI _questText;

        private readonly List<Button> _spawnedButtons = new();

        private Action<int> _onChoiceSelected;
        private Action _onClose;

        private void Awake()
        {
            _root.SetActive(false);
            _closeButton.gameObject.SetActive(false);

            if (_questRoot != null)
                _questRoot.SetActive(false);
        }

        public void Show()
        {
            _root.SetActive(true);
        }

        public void Hide()
        {
            _root.SetActive(false);
            ClearChoices();
            _closeButton.gameObject.SetActive(false);

            if (_questRoot != null)
                _questRoot.SetActive(false);
        }

        public void SetNode(DialogueNode node, Action<int> onChoiceSelected, Action onClose)
        {
            _onChoiceSelected = onChoiceSelected;
            _onClose = onClose;

            _replicaText.text = node.Text;

            ClearChoices();

            if (node.Choices != null && node.Choices.Count > 0)
            {
                for (int i = 0; i < node.Choices.Count; i++)
                {
                    int index = i;
                    Button button = Instantiate(_choiceButtonPrefab, _choicesRoot);
                    TextMeshProUGUI text = button.GetComponentInChildren<TextMeshProUGUI>();
                    text.text = node.Choices[i].Text;
                    button.onClick.AddListener(() => _onChoiceSelected?.Invoke(index));
                    _spawnedButtons.Add(button);
                }
            }

            _closeButton.gameObject.SetActive(node.IsEnd);
            _closeButton.onClick.RemoveAllListeners();
            _closeButton.onClick.AddListener(() => _onClose?.Invoke());
        }

        public void UpdateQuest(string text, bool show)
        {
            if (_questRoot == null || _questText == null)
                return;

            _questRoot.SetActive(show);

            if (show)
                _questText.text = text;
        }

        private void ClearChoices()
        {
            foreach (Button button in _spawnedButtons)
                Destroy(button.gameObject);

            _spawnedButtons.Clear();
        }
    }
}