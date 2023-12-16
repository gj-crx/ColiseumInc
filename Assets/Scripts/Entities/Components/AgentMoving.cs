using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

namespace Components {
    public class AgentMoving : IMovementComponent
    {
        private NavMeshAgent agent;

        private Vector3 storedTargetPosition = Vector3.zero;

        public AgentMoving(NavMeshAgent agent)
        {
            this.agent = agent;
        }
        public AgentMoving(Unit unitToGetAgentFrom)
        {
            this.agent = unitToGetAgentFrom.GetComponent<NavMeshAgent>();
        }

        public bool ExecureStoredMovementOrders()
        {
            if (storedTargetPosition != Vector3.zero)
            {
                bool result = agent.SetDestination(storedTargetPosition);
                storedTargetPosition = Vector3.zero;
                return result;
            }
            return false;
        }

        public bool SetDestination(Vector3 targetPosition)
        {
            this.storedTargetPosition = targetPosition;
            return true;
        }
    }
}
