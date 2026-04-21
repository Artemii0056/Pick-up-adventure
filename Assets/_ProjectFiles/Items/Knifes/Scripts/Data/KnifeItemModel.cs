using _ProjectFiles.Items.Scripts.Data;

namespace _ProjectFiles.Items.Knifes.Scripts.Data
{
    public class KnifeItemModel : ItemModel
    {
        public KnifeItemModel(int id, KnifeItemConfig config) : base(id, config)
        {
            Damage = config.Damage;
        }

        public int Damage { get; }
    }
}