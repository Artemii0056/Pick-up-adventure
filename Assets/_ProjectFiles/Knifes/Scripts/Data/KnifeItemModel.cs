namespace _ProjectFiles.Knifes.Scripts.Data
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