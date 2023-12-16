using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovementComponent
{
    bool ExecureStoredMovementOrders();
    bool SetDestination(Vector3 targetPosition);
}
