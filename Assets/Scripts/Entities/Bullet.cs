using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float damage = 25;
    [SerializeField] private float speed = 6;

    private void FixedUpdate()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<IHittable>() != null)
        {
            collision.gameObject.GetComponent<IHittable>().RecieveDamage(damage);
            Destroy(gameObject);
        }
    }
}
