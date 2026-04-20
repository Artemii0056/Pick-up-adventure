using System;
using System.Collections.Generic;
using _ProjectFiles.Interaction.Scripts.Data;
using _ProjectFiles.Interaction.Scripts.View;

namespace _ProjectFiles.Interaction.Scripts.Core.HoldFeatureServices
{
    public class HoldInteractionFeatureResolver : IHoldInteractionFeatureResolver
    {
        private readonly Dictionary<InteractableItemType, IHoldInteractionFeature> _features;

        private IHoldInteractionFeature _activeFeature;

        private IHoldInteractionFeature _returningFeature;

        public HoldInteractionFeatureResolver(IEnumerable<IHoldInteractionFeature> features)
        {
            _features = new Dictionary<InteractableItemType, IHoldInteractionFeature>();
            
            foreach (var feature in features)
                _features[feature.Type] = feature;
        }

        public InteractionInputType Type => InteractionInputType.Hold;

        public bool TryGetInteractData(InteractableView interactableView, out InteractData interactData)
        {
            interactData = default;

            if (!_features.TryGetValue(interactableView.InteractableItemType, out var feature))
                return false;

            return feature.TryGetInteractData(interactableView, out interactData);
        }

        public bool TryInteract(InteractableView itemView)
        {
            if (!_features.TryGetValue(itemView.InteractableItemType, out var feature))
                return false;

            feature.Interact(itemView);
            return true;
        }

        public void CancelInteract()
        {
            foreach (var features in _features.Values)
            {
                features.StopInteract();
            }
        }
    }
}