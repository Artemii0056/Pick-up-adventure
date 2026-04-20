using _ProjectFiles.Player.Scripts.Resolvers;
using UnityEngine;

namespace _ProjectFiles.Items.Scripts.Logic
{
    public interface IFirstPickUpItemState
    {
        void Show( ItemView itemView);
        bool IsActive { get; set; }
        ItemView CurrentItemView { get; set; }
        void Hide();
        void Tick();
    }
}