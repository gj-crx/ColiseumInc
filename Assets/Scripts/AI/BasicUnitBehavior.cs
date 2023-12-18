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

            int randomPreDelay = Random.Range(0, 500);
            Task.Factory.StartNew(() => ControlUnitActions(controlledUnit, 1000, randomPreDelay));
        }

        private void ChaseAndAttackClosestTarget()
        {
            var closestTarget = targetAcquirer.GetClosestTarget(dataBase, controlledUnit.LastPosition, controlledUnit.GetUnitStats().DistanceOfSight, controlledUnit.FactionTag);

            if (closestTarget != null)
            {
                if (Vector3.Distance(controlledUnit.LastPosition, closestTarget.LastPosition) < controlledUnit.GetUnitStats().AttackRange)
                {
                    controlledUnit.Attack(closestTarget);
                }
                else controlledUnit.MoveToPosition(GetPositionNearTarget(closestTarget.LastPosition));
            } 
        }
        private Vector3 GetPositionNearTarget(Vector3 targetPosition)
        {
            return targetPosition + (targetPosition - controlledUnit.LastPosition).normalized * controlledUnit.GetUnitStats().AttackRange;
        }
    }
}
