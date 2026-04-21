using System.Collections.Generic;
using _ProjectFiles.Interaction.Scripts.Data;
using _ProjectFiles.Interaction.Scripts.View;

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

        public bool TryGetInteractData(InteractableView itemView, out InteractData interactData)
        {
            interactData = default;

            if (!_features.TryGetValue(itemView.InteractableItemType, out ITapInteractionFeature feature))
                return false;

            return feature.TryGetInteractData(itemView, out interactData);
        }

        public bool TryInteract(InteractableView itemView)
        {
            if (!_features.TryGetValue(itemView.InteractableItemType, out var feature))
                return false;
            
            feature.Interact(itemView);
            return true;
        }
    }
}