using _ProjectFiles.Interaction.Scripts.View;
using _ProjectFiles.Items.Scripts;

namespace _ProjectFiles.Player.Scripts.Resolvers
{
    public class ItemView : InteractableView
    {
        public BaseItemConfig Config { get; private set; }

        public void Initialize(BaseItemConfig config)
        {
            Config = config;
        }
    }
}