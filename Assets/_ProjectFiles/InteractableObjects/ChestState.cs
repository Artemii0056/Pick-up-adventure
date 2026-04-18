namespace _ProjectFiles.InteractableObjects
{
    public class ChestState
    {
        public bool IsOpened { get; private set; }

        public void Open()
        {
            IsOpened = true;
        }
    }
    
}