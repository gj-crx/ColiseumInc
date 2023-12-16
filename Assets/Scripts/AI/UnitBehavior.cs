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
        internal Unit controlledUnit;
        internal OnUnitControlled onUnitControlled;


        [Inject]
        internal UnitBehavior(EntityDataBase dataBase)
        {
            this.dataBase = dataBase;
        }

        public async void ControlUnitActions(Unit controlledUnit, int controllingIntervalMilliseconds, int randomPreDelay = 0)
        {
            await Task.Delay(randomPreDelay);
            try
            {
                while (dataBase.IsActive && controlledUnit != null)
                {
                    Debug.Log("Controlling");
                    onUnitControlled?.Invoke();

                    await Task.Delay(controllingIntervalMilliseconds);
                }
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
        }

        internal delegate void OnUnitControlled();
    }
}
