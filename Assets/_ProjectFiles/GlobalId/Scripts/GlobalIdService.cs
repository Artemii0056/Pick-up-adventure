namespace _ProjectFiles.GlobalId.Scripts
{
    public class GlobalIdService : IGlobalIdService
    {
        private int _current;

        public GlobalIdService(int current) => 
            _current = current;

        public int GetNext() => 
            _current++;
    }
}