using System.Collections.Generic;
using UnityEngine;

namespace Shop.Configs
{
    [CreateAssetMenu(fileName = "ShopConfig", menuName = "Shop Config /Shop Config")]
    public class ShopConfig : ScriptableObject
    {
        [SerializeField] 
        public List<SellableItemConfig> items;
        
    }
}