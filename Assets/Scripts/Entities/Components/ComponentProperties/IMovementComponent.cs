using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovementComponent
{
    bool SetDestination(Vector3 targetPosition);
}
