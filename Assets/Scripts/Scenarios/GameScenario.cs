using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scenarios
{
    [CreateAssetMenu(fileName = "Scenario", menuName = "ScriptableObjects/GameScenario", order = 1)]
    public class GameScenario : ScriptableObject
    {
        public List<Unit> UnitsToInitialize = new List<Unit>();
        public float MapRadius = 10;
    }
}
