namespace _ProjectFiles.ValveDoor.Scripts.Data
{
    public interface IValveStorage
    {
        void AddState(ValveModel model);
        ValveModel GetState(int id);
    }
}