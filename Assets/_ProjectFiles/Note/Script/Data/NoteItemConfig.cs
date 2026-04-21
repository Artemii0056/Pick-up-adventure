using _ProjectFiles.Items;
using _ProjectFiles.Keys.Scripts.Data;
using UnityEngine;

namespace _ProjectFiles.Note.Script.Data
{
    [CreateAssetMenu(fileName = nameof(NoteItemConfig), menuName = "StaticData/Interactable/" + nameof(NoteItemConfig))]
    public class NoteItemConfig : BaseItemConfig
    {
        [field: SerializeField] public NoteContent Content { get; private set; }
    }
}