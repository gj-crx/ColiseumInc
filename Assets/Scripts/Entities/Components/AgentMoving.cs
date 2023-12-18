using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

namespace Components {
    public class AgentMoving : IMovementComponent
    {
        private NavMeshAgent agent;

        private Vector3 orderedTargetPosition = Vector3.zero;
        private Vector3 currentTargetPosition = Vector3.zero;

        public AgentMoving(NavMeshAgent agent)
        {
            this.agent = agent;
        }
        public AgentMoving(Unit unitToGetAgentFrom)
        {
            this.agent = unitToGetAgentFrom.GetComponent<NavMeshAgent>();
        }

        [System.Obsolete]
        public bool ExecureStoredMovementOrders()
        {
            if (orderedTargetPosition != Vector3.zero)
            {
                bool result = agent.SetDestination(orderedTargetPosition);
                currentTargetPosition = orderedTargetPosition;
                orderedTargetPosition = Vector3.zero;
                return result;
            }

            if (currentTargetPosition != Vector3.zero && Vector3.Distance(agent.transform.position, currentTargetPosition) < 5)
            {
                currentTargetPosition = Vector3.zero;
                agent.Stop();
            }

            return false;
        }

        public bool SetDestination(Vector3 targetPosition)
        {
            this.orderedTargetPosition = targetPosition;
            return true;
        }
    }
}
