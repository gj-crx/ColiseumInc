using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

using Zenject;

namespace Behaviors
{
    public abstract class AbstractUnitBehavior
    {

        internal EntityDataBase dataBase;
        internal TargetAcquirer targetAcquirer = new TargetAcquirer();
        internal OnUnitControlled onUnitControlled;


        [Inject]
        internal AbstractUnitBehavior(EntityDataBase dataBase)
        {
            this.dataBase = dataBase;
        }

        public async void ControlUnitActions(Unit controlledUnit, int controllingIntervalMilliseconds)
        {
            while (dataBase.IsActive && controlledUnit != null)
            {
                onUnitControlled?.Invoke(controlledUnit);

                await Task.Delay(controllingIntervalMilliseconds);
            }
        }

        internal delegate void OnUnitControlled(Unit controlledUnit);
    }
}
