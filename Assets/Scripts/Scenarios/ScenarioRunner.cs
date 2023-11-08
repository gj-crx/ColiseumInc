using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Scenarios
{
    public class ScenarioRunner : MonoBehaviour
    {
        [SerializeField] private GameScenario startingScenario;


        //external
        [Inject] private UnitSpawner unitSpawner;



        private void Start()
        {
            RunScenario(startingScenario);
        }

        public void RunScenario(GameScenario scenarioToRun)
        {
            //initialize starting units
            for (int i = 0; i < scenarioToRun.UnitsToInitialize.Count; i++)
            {
                Debug.Log(unitSpawner);
                unitSpawner.SpawnUnit(scenarioToRun.UnitsToInitialize[i].gameObject, GetRandomPosition(Vector3.zero, scenarioToRun.MapRadius));
            }
        }

        private Vector3 GetRandomPosition(Vector3 mapCenter, float mapRadius, float ZCord = 1)
        {
            return new Vector3(Random.Range(-mapRadius, mapRadius), Random.Range(-mapRadius, mapRadius), ZCord);
        }
    }
}
