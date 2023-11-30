using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

using Zenject;

namespace Behaviors
{
    public class BasicUnitBehavior : UnitBehavior
    {
        public BasicUnitBehavior(EntityDataBase dataBase, Unit controlledUnit) : base(dataBase)
        {
            this.dataBase = dataBase;
            this.controlledUnit = controlledUnit;

            onUnitControlled += ChaseAndAttackClosestTarget;
            Task.Factory.StartNew(() => ControlUnitActions(controlledUnit, 1000));
        }

        private void ChaseAndAttackClosestTarget()
        {
            var closestTarget = targetAcquirer.GetClosestTarget(dataBase, controlledUnit.LastPosition, controlledUnit.GetUnitStats().DistanceOfSight, controlledUnit.FactionTag);

            if (closestTarget != null)
            {
                Debug.Log("Closest target is " + closestTarget.FactionTag);
                if (Vector3.Distance(controlledUnit.LastPosition, closestTarget.LastPosition) < controlledUnit.GetUnitStats().AttackRange)
                {
                    controlledUnit.Attack(closestTarget);
                }
                else controlledUnit.MoveToPosition(closestTarget.LastPosition);
            } 
        }
    }
}
