using _ProjectFiles.Bootstrap;
using _ProjectFiles.Chest.Scripts.Data;
using _ProjectFiles.Chest.Scripts.Logic;
using _ProjectFiles.Chest.Scripts.Spawner;
using _ProjectFiles.DialogueSystem;
using _ProjectFiles.DialogueSystem.Scripts.Logic;
using _ProjectFiles.DialogueSystem.Scripts.Logic.Quest;
using _ProjectFiles.GlobalId.Scripts;
using _ProjectFiles.Interaction.Scripts.Core;
using _ProjectFiles.Interaction.Scripts.Core.HoldFeatureServices;
using _ProjectFiles.Interaction.Scripts.Core.TapFeatureServices;
using _ProjectFiles.Interaction.Scripts.Core.TransferServices;
using _ProjectFiles.Items.Scripts.Inspection;
using _ProjectFiles.Items.Scripts.Logic;
using _ProjectFiles.NPC.Scripts.Data;
using _ProjectFiles.NPC.Scripts.Logic;
using _ProjectFiles.NPC.Scripts.Spawner;
using _ProjectFiles.NPC.Scripts.View;
using _ProjectFiles.Player.Scripts.Core;
using _ProjectFiles.Player.Scripts.Input.InputReader.Scripts;
using _ProjectFiles.Player.Scripts.LookRotation;
using _ProjectFiles.Player.Scripts.Movements;
using _ProjectFiles.Player.Scripts.Raycast.Scripts;
using _ProjectFiles.Player.Scripts.Resolvers;
using _ProjectFiles.Player.Scripts.Rotation;
using _ProjectFiles.Player.Scripts.View;
using _ProjectFiles.ResourceLoader.Scripts;
using _ProjectFiles.Slots.Scripts.Data;
using _ProjectFiles.Slots.Scripts.Logic;
using _ProjectFiles.Slots.Scripts.Spawner;
using _ProjectFiles.StateMachine;
using _ProjectFiles.StateMachine.Data;
using _ProjectFiles.StateMachine.States;
using _ProjectFiles.StaticDatas.Scripts;
using _ProjectFiles.UI;
using _ProjectFiles.ValveDoor.Scripts.Data;
using _ProjectFiles.ValveDoor.Scripts.Logic;
using _ProjectFiles.ValveDoor.Scripts.Spawner;
using _ProjectFiles.World.Scripts;
using _ProjectFiles.World.Scripts.Factory;
using VContainer;
using VContainer.Unity;

namespace DI
{
    public class GameLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<Player>();
            builder.RegisterComponentInHierarchy<PlayerHandView>();
            builder.RegisterComponentInHierarchy<InfoKeyView>();
            builder.RegisterComponentInHierarchy<Bootstrapper>();
            builder.RegisterComponentInHierarchy<PickUpCanvas>();
            builder.RegisterComponentInHierarchy<PlayerTransformRoot>();
            builder.RegisterComponentInHierarchy<DialogueCanvas>();
        
        
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
        
            builder.Register<FirstPickUpFlow>(Lifetime.Singleton).As<IFirstPickUpItemFlow>();
            builder.Register<WorldLoader>(Lifetime.Singleton).As<IWorldLoader>();
        
            builder.Register<ActiveLookRotation>(Lifetime.Singleton).As<IActiveLookRotation>();
        
            builder.Register<PlayerLookRotationHandler>(Lifetime.Singleton);
            builder.Register<InspectItemRotationHandler>(Lifetime.Singleton);
        
            builder.Register<NpcQuestService>(Lifetime.Singleton).As<INpcQuestService>();
            builder.Register<DialogueService>(Lifetime.Singleton).As<IDialogueService>();
        
            builder.Register<NpcStorage>(Lifetime.Singleton).As<INpcStorage>();
            builder.Register<NpcDialogueResolver>(Lifetime.Singleton).As<INpcDialogueResolver>();
            builder.Register<NpcInteractionService>(Lifetime.Singleton).As<INpcInteractionService>();
            builder.Register<NpcDialogueSelectorService>(Lifetime.Singleton).As<INpcDialogueSelectorService>();
        
            builder.Register<ValveStorage>(Lifetime.Singleton).As<IValveStorage>();
        
            builder.Register<WorldItemFactory>(Lifetime.Singleton).As<IWorldItemFactory>();

            builder.Register<SlotSpawner>(Lifetime.Singleton).As<ISlotSpawner>();
            builder.Register<WorldItemSpawner>(Lifetime.Singleton).As<IWorldItemSpawner>();
            builder.Register<NpcSpawner>(Lifetime.Singleton).As<INpcSpawner>();
            builder.Register<ChestSpawner>(Lifetime.Singleton).As<IChestSpawner>();
        
            builder.Register<ValveSpawner>(Lifetime.Singleton).As<IValveSpawner>();
        

            RegisterInteractionFeatures(builder);
            RegisterInteractionFactories(builder);
            RegisterStateMachine(builder);
        }

        private void RegisterStateMachine(IContainerBuilder builder)
        {
            builder.Register<GameStateMachine>(Lifetime.Singleton).As<IGameStateMachine>().As<IStateMachine>();
            builder.Register<StateFactory>(Lifetime.Singleton).As<IStateFactory>();

            builder.Register<BootstrapState>(Lifetime.Singleton);
            builder.Register<LoadState>(Lifetime.Singleton);
            builder.Register<GamePlayState>(Lifetime.Singleton);
            builder.Register<FirstPickUpState>(Lifetime.Singleton);
            builder.Register<DialogState>(Lifetime.Singleton);
        }

        private void RegisterInteractionFeatures(IContainerBuilder builder)
        {
            builder.Register<ITapInteractionFeature, ChestTapInteractionFeature>(Lifetime.Singleton);
            builder.Register<ITapInteractionFeature, ItemTapInteractionFeature>(Lifetime.Singleton);
            builder.Register<ITapInteractionFeature, NpcTapInteractionFeature>(Lifetime.Singleton);
            builder.Register<ITapInteractionFeature, SlotTapInteractionFeature>(Lifetime.Singleton);
        
            builder.Register<IHoldInteractionFeature, ValveHoldInteractionFeature>(Lifetime.Singleton);

            builder.Register<ITapInteractionFeatureResolver, TapInteractionFeatureResolver>(Lifetime.Singleton);
            builder.Register<IHoldInteractionFeatureResolver, HoldInteractionFeatureResolver>(Lifetime.Singleton);
            builder.Register<IInteractionFeatureService, InteractionFeatureService>(Lifetime.Singleton);
            builder.Register<IValveRotationService, ValveRotationService>(Lifetime.Singleton);
        }
    
        private void RegisterInteractionFactories(IContainerBuilder builder)
        {
            builder.Register<ISlotModelFactory, SlotModelFactory>(Lifetime.Singleton);
        }
    }
}
