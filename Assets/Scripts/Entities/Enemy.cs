using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class Enemy : MonoBehaviour, IMovable, IHittable, IAbleToAttack
{
    public float CurrentHP { get { return healthComponent.CurrentHP; } }

    //Local components
    [SerializeField] private HealthComponent healthComponent = new HealthComponent();
    [SerializeField] private NavMeshAgent agent;
    private IAttackingTool attackingComponent = new ShootingComponent();

    public void MoveToPosition(Vector3 destination)
    {
        agent.SetDestination(destination);
    }

    public void RecieveDamage(float damage)
    {
        healthComponent.CurrentHP -= damage;
        if (CurrentHP <= 0) Death();
    }

    public void Attack(Vector3 target)
    {
        attackingComponent.Attack(target, gameObject);
    }
    
    private void Death()
    {
        Debug.Log("Unit dead " + gameObject.name);
        Destroy(gameObject);
    }
}
