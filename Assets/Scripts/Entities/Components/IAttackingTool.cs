using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackingTool
{
    void SetAttackingOrder(Unit target, Unit attacker);
    void ExecureStoredAttackOrders();
}