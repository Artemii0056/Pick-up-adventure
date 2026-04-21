using _ProjectFiles.Items;
using _ProjectFiles.Keys.Scripts.Data;
using UnityEngine;

namespace _ProjectFiles.Knifes.Scripts.Data
{
    [CreateAssetMenu(fileName = nameof(KnifeItemConfig), menuName = "StaticData/Interactable/" + nameof(KnifeItemConfig))]
    public class KnifeItemConfig : BaseItemConfig
    {
        [field: SerializeField] public int  Damage { get; private set; }
    }
}