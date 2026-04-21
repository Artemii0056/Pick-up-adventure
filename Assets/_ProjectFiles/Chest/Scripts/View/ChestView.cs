using _ProjectFiles.Chest.Scripts.Data;
using _ProjectFiles.Interaction.Scripts.View;
using UnityEngine;

namespace _ProjectFiles.Chest.Scripts.View
{
    public class ChestView : InteractableView
    {
        [SerializeField] private Animator _animator;

        public ChestConfig Config { get; private set; }

        public void Initialize(ChestConfig config)
        {
            Config = config;
        }

        public void Open()
        {
            if (Config != null && _animator != null)
            {
                _animator.SetBool(Config.OpenAnimationParam, true);
            }
        }
    }
}