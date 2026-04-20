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
        private readonly Dictionary<InteractableItemType, ITapInteractionFeature> _features;

        public TapInteractionFeatureResolver(IEnumerable<ITapInteractionFeature> features)
        {
            _features = new Dictionary<InteractableItemType, ITapInteractionFeature>();

            foreach (var feature in features)
                _features[feature.Type] = feature;
        }

        public InteractionInputType Type => InteractionInputType.Tap;

        public bool TryGetInteractData(IHandService handService, InteractableView itemView, out InteractData interactData)
        {
            interactData = default;

            if (!_features.TryGetValue(itemView.InteractableItemType, out ITapInteractionFeature feature))
                return false;

            return feature.TryGetInteractData(itemView, out interactData);
        }

        public bool TryInteract(IHandService handService, InteractableView itemView)
        {
            if (!_features.TryGetValue(itemView.InteractableItemType, out var feature))
                return false;

            feature.Interact(itemView);
            return true;
        }
    }
}