using System;
using System.Collections.Generic;
using _ProjectFiles.Interaction.Scripts.Data;
using _ProjectFiles.Interaction.Scripts.View;
using _ProjectFiles.Player.Scripts.Core;
using _ProjectFiles.UI;

namespace _ProjectFiles.Interaction.Scripts.Core
{
    public class InteractionFeatureService
    {
        private readonly InfoKeyView _keyView;
        private readonly Dictionary<InteractableItemType, IInteractionFeature> _features;

        public InteractionFeatureService(List<IInteractionFeature> features, InfoKeyView keyView)
        {
            _keyView = keyView;
            _features = new Dictionary<InteractableItemType, IInteractionFeature>();

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

        private void ShowViewData(IHandService handService, InteractableView itemView)
        {
            if (!_features.TryGetValue(itemView.InteractableItemType, out var feature))
                throw new Exception("Interaction feature not found");

            if (feature.TryGetInteractData(handService, itemView, out InteractData interactData)) //Todo тут подумать
            {
            }

            _keyView.UpdateText(interactData.ActionName);
        }
    }
}