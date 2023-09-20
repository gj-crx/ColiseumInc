using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour, ICharacterController
{
    [SerializeField] private Player playerObject;

    private bool wrongInput = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) MoveUnitTowards(GetClickedPosition());
        if (Input.GetKeyDown(KeyCode.E)) Attack(GetClickedPosition());
    }

    public void Attack(Vector3 targetPosition)
    {
        if (wrongInput)
        {
            Debug.Log("Wrong input alert sound");
            return;
        }
        (playerObject as IAbleToAttack).Attack(targetPosition);
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
