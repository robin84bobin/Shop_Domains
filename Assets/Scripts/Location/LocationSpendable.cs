using System;
using Core;
using UnityEngine;
using UnityEngine.Serialization;

namespace Location
{
    [Serializable]
    public class LocationSpendable : ISpendable
    {
        [FormerlySerializedAs("locationManager")] [SerializeField] LocationModel locationModel;
        [SerializeField] string name;
        public void Sell()
        {
            locationModel.Spend(name);
        }
    }
}