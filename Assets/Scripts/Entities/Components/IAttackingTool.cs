using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackingTool 
{
    void Attack(Unit target, GameObject attacker);
}
