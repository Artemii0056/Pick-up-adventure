using _ProjectFiles.Items.Scripts.Data;

namespace _ProjectFiles.Knifes.Scripts.Data
{
    public class KnifeItemModel : ItemModel
    {
        public KnifeItemModel(int id, ItemType type, int damage) : base(id, type)
        {
            Damage = damage;
        }

        public int Damage { get; }
    }
}