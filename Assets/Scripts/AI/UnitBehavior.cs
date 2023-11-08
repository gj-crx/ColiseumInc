using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

using Zenject;

namespace Behaviors
{
    public abstract class UnitBehavior
    {

        internal EntityDataBase dataBase;
        internal TargetAcquirer targetAcquirer = new TargetAcquirer();
        internal OnUnitControlled onUnitControlled;


        [Inject]
        internal UnitBehavior(EntityDataBase dataBase)
        {
            Debug.Log("even injected");
            this.dataBase = dataBase;
        }

        public async void ControlUnitActions(GameObject controlledUnit, int controllingIntervalMilliseconds)
        {
            try
            {
                Debug.Log("controlling started " + dataBase.IsActive);
                while (dataBase.IsActive && controlledUnit != null)
                {
                    Debug.Log("Controlling");
                    onUnitControlled?.Invoke(controlledUnit);

                    await Task.Delay(controllingIntervalMilliseconds);
                }
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
        }

        internal delegate void OnUnitControlled(GameObject controlledUnit);
    }
}
