using _ProjectFiles.Interaction.Scripts.Data;
using UnityEngine;

namespace _ProjectFiles.Player.Scripts.Resolvers
{
    public class ItemView : MonoBehaviour 
    {
       [field: SerializeField] public int Id { get; private set; }
       [field: SerializeField] public InteractableItemType InteractableItemType { get; private set; } //Тут точно этот тип

       public void Init(int id, InteractableItemType interactableItemType)
       {
           Id = id;
           InteractableItemType = interactableItemType;
       }
    }
}