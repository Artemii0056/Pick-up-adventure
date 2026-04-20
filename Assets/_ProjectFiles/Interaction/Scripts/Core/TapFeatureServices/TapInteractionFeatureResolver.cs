using System;
using System.Collections.Generic;
using _ProjectFiles.Interaction.Scripts.Data;
using _ProjectFiles.Interaction.Scripts.View;
using _ProjectFiles.Player.Scripts.Core;
using _ProjectFiles.UI;

namespace _ProjectFiles.Interaction.Scripts.Core.TapFeatureServices
{
    public class TapInteractionFeatureResolver : ITapInteractionFeatureResolver
    {
        private readonly InfoKeyView _keyView;
        private readonly Dictionary<InteractableItemType, ITapInteractionFeature> _features;

        public TapInteractionFeatureResolver(IEnumerable<ITapInteractionFeature> features, InfoKeyView keyView)
        {
            _keyView = keyView;
            _features = new Dictionary<InteractableItemType, ITapInteractionFeature>();

            foreach (var feature in features)
                _features[feature.Type] = feature;
        }

        public bool TryExecute(IHandService handService, InteractableView itemView)
        {
            if (!_features.TryGetValue(itemView.InteractableItemType, out var feature))
                return false;

            ShowViewData(handService, itemView);

            return true;
        }

        public bool TryInteract(IHandService handService, InteractableView itemView)
        {
            if (!_features.TryGetValue(itemView.InteractableItemType, out var feature))
                return false;

            feature.Interact(handService, itemView);
            return true;
        }

        public void Hide()
        {
            //Хайд перетащить  сюда? 
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
}