namespace _ProjectFiles
{
    public class ChestModel
    {
        public int Id { get; }
        public bool IsOpened { get; private set; }

        public ChestModel(int id)
        {
            Id = id;
        }

        public void Open()
        {
            IsOpened = true;
        }
    }
}