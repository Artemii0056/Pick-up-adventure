namespace _ProjectFiles.GlobalId.Scripts
{
    public class GlobalIdService : IGlobalIdService
    {
        private int _current;

        public GlobalIdService() => 
            _current = 0;

        public int GetNext() => 
            _current++;
    }
}