using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Zenject;
using Behaviors;

public class PlayerCharacterController : MonoBehaviour, ICharacterController
{
    [SerializeField] private Unit playerObject;
    private EntityDataBase dataBase;

    private TargetAcquirer targetAcquirer = new TargetAcquirer();

    private bool wrongInput = false;

    [Inject]
    private void InstallExternalDependencies(EntityDataBase dataBase)
    {
        this.dataBase = dataBase;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) MoveUnitTowards(GetClickedPosition());
        if (Input.GetKeyDown(KeyCode.E))
        {
            var target = targetAcquirer.GetClosestTarget(dataBase, playerObject.transform.position, playerObject.GetUnitStats().DistanceOfSight, playerObject.tag);
            if (target != null) Attack(target.gameObject);
        }
    }

    public void Attack(GameObject target)
    {
        if (wrongInput)
        {
            Debug.Log("Wrong input alert sound");
            return;
        }
        (playerObject as IAbleToAttack).Attack(target);
    }

    public void MoveUnitTowards(Vector3 destination)
    {
        if (wrongInput)
        {
            Debug.Log("Wrong input alert sound");
            return;
        }
        (playerObject as IMovable).MoveToPosition(destination);
    }

    private Vector3 GetClickedPosition()
    {
        wrongInput = false;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100)) return hit.point;
        else
        {
            wrongInput = true;
            return Vector3.zero;
        }

    }
}
