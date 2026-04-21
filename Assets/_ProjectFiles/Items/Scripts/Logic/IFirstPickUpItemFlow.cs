using _ProjectFiles.Player.Scripts.Resolvers;
using UnityEngine;

namespace _ProjectFiles.Items.Scripts.Logic
{
    public interface IFirstPickUpItemFlow
    {
        void Show( ItemView itemView);
        bool IsActive { get;  }
        void Hide();
    }
}