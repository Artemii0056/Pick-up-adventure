namespace _ProjectFiles.GlobalId.Scripts
{
    public class GlobalIdService : IGlobalIdService
    {
        private int _current = 1;

        public int GetNext() => 
            _current++;
    }
}