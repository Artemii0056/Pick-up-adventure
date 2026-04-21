using _ProjectFiles.Items.Note.Script.Data;
using _ProjectFiles.Player.Scripts.Resolvers;
using UnityEngine;

namespace _ProjectFiles.Items.Note.Script.View
{
    public class NoteView : ItemView
    {
        [SerializeField] private Animator _animator;

        public void Open(NoteItemConfig config)
        {
            if (_animator == null || config == null)
                return;

            _animator.SetTrigger(config.OpenAnimationParam);
        }
    }
}