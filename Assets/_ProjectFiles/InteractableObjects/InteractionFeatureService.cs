using System;
using System.Collections.Generic;
using _ProjectFiles.InteractableObjects.Scripts;
using _ProjectFiles.RaycastResolvers.Scripts;
using _ProjectFiles.UI;

namespace _ProjectFiles.InteractableObjects
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

        public void ShowViewData(Player player, InteractableEntity interactableEntity) 
        {
            if (!_features.TryGetValue(interactableEntity.InteractableItemType, out var feature))
                throw new Exception("Interaction feature not found");

            InteractData data = feature.GetInteractData(player, interactableEntity);

            _keyView.UpdateText(data.ActionName);
        }

        public bool TryExecute(Player player, InteractableEntity interactableEntity)
        {
            if (!_features.TryGetValue(interactableEntity.InteractableItemType, out var feature))
                return false;

            ShowViewData(player, interactableEntity);

            return true;
        }
    }
}