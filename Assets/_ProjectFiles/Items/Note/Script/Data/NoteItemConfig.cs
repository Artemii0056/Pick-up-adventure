using _ProjectFiles.Items.Scripts;
using UnityEngine;

namespace _ProjectFiles.Items.Note.Script.Data
{
    [CreateAssetMenu(fileName = nameof(NoteItemConfig), menuName = "StaticData/Interactable/" + nameof(NoteItemConfig))]
    public class NoteItemConfig : BaseItemConfig
    {
        [field: SerializeField] public NoteContent Content { get; private set; }
        [field: SerializeField] public string OpenAnimationParam { get; private set; } = "Circle";

    }
}