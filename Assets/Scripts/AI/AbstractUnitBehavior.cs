using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

using Zenject;

namespace Behaviors
{
    public abstract class AbstractUnitBehavior : ICharacterController
    {

        internal EntityDataBase dataBase;
        internal TargetAcquirer targetAcquirer = new TargetAcquirer();
        internal OnUnitControlled onUnitControlled;


        [Inject]
        internal AbstractUnitBehavior(EntityDataBase dataBase)
        {
            this.dataBase = dataBase;
        }


        public void Attack(Vector3 targetPosition)
        {
            throw new System.NotImplementedException();
        }

        public void MoveUnitTowards(Vector3 destination)
        {

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
