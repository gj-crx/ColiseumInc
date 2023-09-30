using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

using Zenject;

namespace Behaviors
{
    public class BasicUnitBehavior : AbstractUnitBehavior
    {
        public BasicUnitBehavior(EntityDataBase dataBase) : base(dataBase)
        {
            this.dataBase = dataBase;

            onUnitControlled += ChaseAndAttackClosestTarget;
        }

        private void ChaseAndAttackClosestTarget(Unit attackingUnit)
        {
            var closestTarget = targetAcquirer.GetClosestTarget(dataBase, attackingUnit.transform.position, attackingUnit.GetUnitStats().DistanceOfSight, attackingUnit.FactionID);

            if (closestTarget != null)
            {
                if (Vector3.Distance(attackingUnit.transform.position, closestTarget.transform.position) < attackingUnit.GetUnitStats().AttackRange)
                {
                    attackingUnit.Attack(closestTarget.gameObject);
                }
                else attackingUnit.MoveToPosition(closestTarget.transform.position);
            } 
        }
    }
}
