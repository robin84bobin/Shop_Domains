using Core.Models;
using UnityEngine;

namespace Health
{
    [CreateAssetMenu(menuName = "Create HealthModel", fileName = "HealthModel", order = 0)]
    public class HealthModel : IntParamModel
    {
        public void Spend(int value)
        {
            Parameter.Value -= value;
        }
    }
}