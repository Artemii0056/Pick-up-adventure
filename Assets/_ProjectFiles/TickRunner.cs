using System.Collections.Generic;
using VContainer.Unity;

namespace _ProjectFiles
{
    public class TickRunner : ITickRunner
    {
        private List<ITickable> _tickables;

        public TickRunner()
        {
            _tickables = new List<ITickable>();
        }

        public void AddTickable(ITickable tickable)
        {
            _tickables.Add(tickable);
        }

        public void Tick()
        {
            foreach (var tickable in _tickables)
            {
                tickable.Tick();
            }
        }
    }

    public interface ITickRunner
    {
        void Tick();
    }
}