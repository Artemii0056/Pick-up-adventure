namespace _ProjectFiles.ValveDoor.Scripts.Data
{
    public class ValveModel
    {
        public float Progress { get; private set; }

        public void SetProgress(float value)
        {
            Progress = UnityEngine.Mathf.Clamp01(value);
        }
    }
}