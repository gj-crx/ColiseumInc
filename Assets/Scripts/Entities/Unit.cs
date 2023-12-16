using Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Unit : MonoBehaviour, IMovable, IHittable, IAbleToAttack
{
    public string FactionTag = "NoTag";
    public Vector3 LastPosition = Vector3.zero;

    //Local components
    [SerializeField] private HealthComponent healthComponent = new HealthComponent();
    [SerializeField] private IAttackingComponent attackingComponent = new ShootingComponent();
    [SerializeField] private IMovementComponent movementComponent = null;
    
    void Awake()
    {
        movementComponent = new AgentMoving(this);
    }
    void Update()
    {
        LastPosition = transform.position;

        attackingComponent.ExecureStoredAttackOrders();
        movementComponent.ExecureStoredMovementOrders();
    }

    public HealthComponent.UnitStatsReadOnly GetUnitStats() => healthComponent.UnitStats;

    public void MoveToPosition(Vector3 destination) => movementComponent.SetDestination(destination);

    public void RecieveDamage(float damage)
    {
        if (healthComponent.RecieveDamage(damage) == HealthComponent.HealthStatus.Dead) Death();
    }

    public void Attack(Unit target) => attackingComponent.SetAttackingOrder(target, this);

    private void Death()
    {
        Debug.Log("Unit dead " + gameObject.name);
        Destroy(gameObject);
    }
}
