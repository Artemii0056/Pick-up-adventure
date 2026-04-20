using System;
using System.Collections.Generic;
using _ProjectFiles.Interaction.Scripts.Data;
using _ProjectFiles.Interaction.Scripts.View;
using _ProjectFiles.Player.Scripts.Core;
using _ProjectFiles.UI;
using UnityEngine.UI;

namespace _ProjectFiles.Interaction.Scripts.Core
{
    public class InteractionFeatureService : IInteractionFeatureService
    {
        private readonly InfoKeyView _keyView;
        
        //private Dictionary<InteractionInputType, ITapInteractionFeature> _features;

        public InteractionFeatureService(InfoKeyView keyView)
        {
            _keyView = keyView;
        }
        
        private void ShowViewData(IHandService handService, InteractableView itemView)
        {
            if (!_features.TryGetValue(itemView.InteractableItemType, out var feature))
                throw new Exception("Interaction feature not found");

            if (feature.TryGetInteractData(handService, itemView, out InteractData interactData)) 
            {
                _keyView.gameObject.SetActive(true); //TODO Плохо, что тут. Надо бы логику разнести и не выключать/включать постоянно 
                _keyView.UpdateText(interactData.ActionName);
            }
            else
            {
                _keyView.gameObject.SetActive(false);
            }
        }
    }

    internal interface IInteractionInputExecutor
    {
        InteractionInputType InputType { get; }

        bool TryGetInteractData(
            IHandService handService,
            InteractableView interactableView,
            out InteractData interactData);

        bool TryStartInteraction(
            IHandService handService,
            InteractableView interactableView);

        void CancelInteraction(IHandService handService);

        void Tick(IHandService handService, float deltaTime);
    }
}