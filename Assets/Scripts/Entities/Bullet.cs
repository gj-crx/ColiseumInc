using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float damage = 25;
    [SerializeField] private float speed = 6;
    [SerializeField] private float lifeTime = 3f;

    private void Start() => StartCoroutine(LifeTimeCoroutine());
    private void FixedUpdate()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
    }
    private IEnumerator LifeTimeCoroutine()
    {
        float timerLife = 0;
        while (timerLife < lifeTime)
        {
            timerLife += Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
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
