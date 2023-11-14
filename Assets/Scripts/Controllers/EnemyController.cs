using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Zenject;
using Behaviors;

public class EnemyController : MonoBehaviour, ICharacterController
{
    private UnitBehavior behavior;
    [SerializeField] private Unit controlledUnit;

    private TargetAcquirer targetAcquirer = new TargetAcquirer();
    private bool wrongInput = false;


    //External
    private EntityDataBase dataBase;

    [Inject]
    private void InstallExternalDependencies(EntityDataBase dataBase)
    {
        this.dataBase = dataBase;
        Debug.Log(controlledUnit + " nig");
        behavior = new BasicUnitBehavior(dataBase, controlledUnit.gameObject);
    }
    void Awake() => controlledUnit = GetComponent<Unit>();

    private void Update()
    {

    }

    public void Attack(GameObject target)
    {
        if (wrongInput)
        {
            Debug.Log("Wrong input alert sound");
            return;
        }
        (controlledUnit as IAbleToAttack).Attack(target);
    }

    public void MoveUnitTowards(Vector3 destination)
    {
        if (wrongInput)
        {
            Debug.Log("Wrong input alert sound");
            return;
        }
        (controlledUnit as IMovable).MoveToPosition(destination);
    }

}
