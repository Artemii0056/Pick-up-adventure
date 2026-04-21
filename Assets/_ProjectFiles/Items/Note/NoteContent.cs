using UnityEngine;

namespace _ProjectFiles.Items.Note
{
    [CreateAssetMenu(fileName = nameof(NoteContent), menuName = "StaticData/Interactable/" + nameof(NoteContent))]
    public class NoteContent : ScriptableObject
    {
        [field: SerializeField] public string Text { get; private set; }
    }
}