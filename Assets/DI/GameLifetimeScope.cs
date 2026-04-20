using _ProjectFiles.Bootstrap;
using _ProjectFiles.Chest.Scripts.Data;
using _ProjectFiles.Chest.Scripts.Logic;
using _ProjectFiles.GlobalId.Scripts;
using _ProjectFiles.Interaction.Scripts.Core;
using _ProjectFiles.Items.Scripts.Logic;
using _ProjectFiles.Keys.Scripts.Data;
using _ProjectFiles.Note.Script.Data;
using _ProjectFiles.NPC.Scripts.Logic;
using _ProjectFiles.Player.Scripts.Core;
using _ProjectFiles.Player.Scripts.Input.InputReader.Scripts;
using _ProjectFiles.Player.Scripts.Movements;
using _ProjectFiles.Player.Scripts.Raycast.Scripts;
using _ProjectFiles.Player.Scripts.Resolvers;
using _ProjectFiles.Player.Scripts.Rotation;
using _ProjectFiles.Player.Scripts.View;
using _ProjectFiles.ResourceLoader.Scripts;
using _ProjectFiles.Slots.Scripts.Data;
using _ProjectFiles.Slots.Scripts.Logic;
using _ProjectFiles.StaticDatas.Scripts;
using _ProjectFiles.UI;
using _ProjectFiles.ValveDoor.Scripts.Logic;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<Player>();
        builder.RegisterComponentInHierarchy<PlayerHandView>();
        builder.RegisterComponentInHierarchy<InfoKeyView>();
        builder.RegisterComponentInHierarchy<Bootstrapper>();
        
        
        
        builder.Register<SlotStorage>(Lifetime.Singleton).As<ISlotStorage>();
        builder.Register<RaycastService>(Lifetime.Singleton).As<IRaycastService>();
        builder.Register<InteractionTargetResolver>(Lifetime.Singleton).As<IInteractionTargetResolver>();
        builder.Register<PlayerHandService>(Lifetime.Singleton).As<IHandService>();
        builder.Register<PlayerInputReader>(Lifetime.Singleton).As<IPlayerInputReader>();
        
        builder.Register<ItemStorage>(Lifetime.Singleton).As<IItemStorage>();
        builder.Register<ChestStorage>(Lifetime.Singleton).As<IChestStorage>();
        
        builder.Register<ItemTransferService>(Lifetime.Singleton).As<IItemTransferService>();
        builder.Register<PlayerInteractionController>(Lifetime.Singleton).As<IPlayerInteractionController>();

        builder.Register<StaticDataService>(Lifetime.Singleton).As<IStaticDataService>();
        builder.Register<PlayerRotator>(Lifetime.Singleton).As<IPlayerRotator>();
        builder.Register<PlayerMover>(Lifetime.Singleton).As<IPlayerMover>();
        
        builder.Register<ResourceLoader>(Lifetime.Singleton).As<IResourceLoader>();
        
        builder.Register<GlobalIdService>(Lifetime.Singleton).As<IGlobalIdService>();
        builder.Register<StoragePickedUpItems>(Lifetime.Singleton).As<IStoragePickedUpItems>();
        
        

        RegisterInteractionFeatures(builder);
        RegisterInteractionFactories(builder);
    }

    private void RegisterInteractionFeatures(IContainerBuilder builder)
    {
        builder.Register<IInteractionFeature, ChestInteractionFeature>(Lifetime.Singleton);
        builder.Register<IInteractionFeature, ItemInteractionFeature>(Lifetime.Singleton);
        builder.Register<IInteractionFeature, NpcInteractionFeature>(Lifetime.Singleton);
        builder.Register<IInteractionFeature, SlotInteractionFeature>(Lifetime.Singleton);
        builder.Register<IInteractionFeature, ValveInteractionFeature>(Lifetime.Singleton);

        builder.Register<IInteractionFeatureService, InteractionFeatureService>(Lifetime.Singleton);
    }
    
    private void RegisterInteractionFactories(IContainerBuilder builder)
    {
        builder.Register<ISlotModelFactory, SlotModelFactory>(Lifetime.Singleton);
        builder.Register<IKeyModelFactory, KeyModelFactory>(Lifetime.Singleton);
        builder.Register<IChestModelFactory, ChestModelFactory>(Lifetime.Singleton);
        builder.Register<INoteModelFactory, NoteModelFactory>(Lifetime.Singleton);
 
    }
}
