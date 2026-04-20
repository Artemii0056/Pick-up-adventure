using _ProjectFiles.Player.Scripts.Movements;
using _ProjectFiles.Player.Scripts.Rotation._ProjectFiles.Player.Scripts.Movements.Configs;
using _ProjectFiles.ResourceLoader.Scripts;

namespace _ProjectFiles.StaticDatas.Scripts
{
    public class StaticDataService : IStaticDataService
    {
        private readonly IResourceLoader _resourceLoader;

        public PlayerRotationConfig PlayerRotationConfig { get; private set; }
        public PlayerMovementConfig PlayerMovementConfig{ get; private set; }
        
        public StaticDataService(IResourceLoader resourceLoader)
        {
            _resourceLoader = resourceLoader;
            
           
        }
        
        public void LoadAll()
        {
            LoadRotationConfig();
            LoadMovementConfig();
        }

        private void LoadRotationConfig() => 
            PlayerRotationConfig = _resourceLoader.Load<PlayerRotationConfig>("PlayerRotationConfig");

        private void LoadMovementConfig() => 
            PlayerMovementConfig = _resourceLoader.Load<PlayerMovementConfig>("PlayerMovementConfig");
    }
}