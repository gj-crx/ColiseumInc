using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShootingComponent : IAttackingTool
{
    private Unit target = null;
    private Unit attacker = null;

    public void ExecureStoredAttackOrders()
    {
        if (target != null)
        {
            Bullet newBullet = GameObject.Instantiate(PrefabManager.BulletPrefabs[0], attacker.LastPosition + attacker.transform.forward, Quaternion.identity).GetComponent<Bullet>();

            newBullet.transform.rotation = attacker.transform.rotation;
            newBullet.transform.LookAt(new Vector3(target.transform.position.x, newBullet.transform.position.y, target.transform.position.z));
            //   newBullet.transform.rotation = Quaternion.Slerp(newBullet.transform.rotation, Quaternion.LookRotation(target - newBullet.transform.position).normalized, 1);
            //   newBullet.transform.localEulerAngles = new Vector3(0, newBullet.transform.localEulerAngles.y, newBullet.transform.localEulerAngles.z);
        }
    }

    public void SetAttackingOrder(Unit target, Unit attacker)
    { //stores order to be executed later from mainthread
        this.target = target;
        this.attacker = attacker;
    }
}
