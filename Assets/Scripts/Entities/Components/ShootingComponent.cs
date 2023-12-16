using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShootingComponent : IAttackingComponent
{
    private Unit storedTarget = null;
    private Unit attacker = null;

    public void ExecureStoredAttackOrders()
    {
        if (storedTarget != null)
        {
            Bullet newBullet = GameObject.Instantiate(PrefabManager.BulletPrefabs[0], attacker.LastPosition + attacker.transform.forward, Quaternion.identity).GetComponent<Bullet>();

            newBullet.transform.rotation = attacker.transform.rotation;
            newBullet.transform.LookAt(new Vector3(storedTarget.transform.position.x, newBullet.transform.position.y, storedTarget.transform.position.z));

            storedTarget = null;
        }
    }

    public void SetAttackingOrder(Unit target, Unit attacker)
    { //stores order to be executed later from mainthread
        this.storedTarget = target;
        this.attacker = attacker;
    }
}
