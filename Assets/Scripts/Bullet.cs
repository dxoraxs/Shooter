using System;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int damage;
    private float speed = 5;
    private Character target;
    private Vector3 direction;
    private Action<Bullet> returnBullet;

    public void SetDamage(int value) => damage = value;

    public void InitBullet(Character target, Action<Bullet> callback)
    {
        returnBullet += callback;
        this.target = target;
        direction = target.transform.position - transform.position;
        direction.y = 0;
        direction = direction.normalized;
        
        StartCoroutine(BulletFly());
    }

    private IEnumerator BulletFly()
    {
        while ((transform.position - target.transform.position).magnitude > 1.25f)
        {
            yield return null;
            transform.Translate(direction * (Time.deltaTime * speed));
        }
        target.TakeDamage(damage);
        returnBullet.Invoke(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        StopAllCoroutines();
        returnBullet.Invoke(this);
    }
}