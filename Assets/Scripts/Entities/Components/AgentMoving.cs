using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

namespace Components {
    public class AgentMoving : IMovementComponent
    {
        private NavMeshAgent agent;

        public AgentMoving(NavMeshAgent agent)
        {
            this.agent = agent;
        }
        public AgentMoving(Unit unitToGetAgentFrom)
        {
            this.agent = unitToGetAgentFrom.GetComponent<NavMeshAgent>();
        }

        public bool SetDestination(Vector3 targetPosition)
        {
            return agent.SetDestination(targetPosition);
        }
    }
}
