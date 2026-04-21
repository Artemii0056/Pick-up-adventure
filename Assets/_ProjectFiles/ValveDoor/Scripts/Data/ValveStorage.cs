using System.Collections.Generic;

namespace _ProjectFiles.ValveDoor.Scripts.Data
{
    public class ValveStorage : IValveStorage
    {
        private readonly Dictionary<int, ValveModel> _states = new();

        public void AddState(ValveModel model)
        {
            _states[model.Id] = model;
        }

        public ValveModel GetState(int id)
        {
            _states.TryGetValue(id, out ValveModel model);
            return model;
        }
    }
}