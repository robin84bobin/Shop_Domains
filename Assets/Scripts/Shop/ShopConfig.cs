using Core;
using UnityEngine;

namespace Shop
{
    [CreateAssetMenu(fileName = "ShopConfig", menuName = "Shop Config")]
    public class ShopConfig : ScriptableObject, ISellable
    {
        public void Sell(int value)
        {
            throw new System.NotImplementedException();
        }
    }
}