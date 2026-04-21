using _ProjectFiles.Items.Scripts;
using UnityEngine;

namespace _ProjectFiles.Items.Knifes.Scripts.Data
{
    [CreateAssetMenu(fileName = nameof(KnifeItemConfig), menuName = "StaticData/Interactable/" + nameof(KnifeItemConfig))]
    public class KnifeItemConfig : BaseItemConfig
    {
        [field: SerializeField] public int  Damage { get; private set; }
    }
}