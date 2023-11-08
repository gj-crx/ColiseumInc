using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

using Zenject;

namespace Behaviors
{
    public class BasicUnitBehavior : UnitBehavior
    {
        public BasicUnitBehavior(EntityDataBase dataBase, GameObject controlledUnit) : base(dataBase)
        {
            this.dataBase = dataBase;

            onUnitControlled += ChaseAndAttackClosestTarget;
            Task.Factory.StartNew(() => ControlUnitActions(controlledUnit, 1000));
        }

        private void ChaseAndAttackClosestTarget(GameObject attackingUnit)
        {
            var closestTarget = targetAcquirer.GetClosestTarget(dataBase, attackingUnit.transform.position, attackingUnit.GetUnitStats().DistanceOfSight, attackingUnit.FactionID);

            if (closestTarget != null)
            {
                if (Vector3.Distance(attackingUnit.transform.position, closestTarget.transform.position) < attackingUnit.GetUnitStats().AttackRange)
                {
                    attackingUnit.Attack(closestTarget);
                }
                else attackingUnit.MoveToPosition(closestTarget.transform.position);
            } 
        }
    }
}
