using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterController
{
    void MoveUnitTowards(Vector3 destination);
    void Attack(GameObject target);
}
