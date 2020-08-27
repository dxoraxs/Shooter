using System.Collections;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    [SerializeField] private Transform spawnPointBullet;
    private float delayShot = 1;
    private FinderTarget finderTarget;
    private Character target;
    private PoolObject bulletPool;

    public void InitShotController(PoolObject bulletPool)
    {
        this.bulletPool = bulletPool;
        StartCoroutine(TimerShot());
        finderTarget = GetComponent<FinderTarget>();
    }

    private void Update()
    {
        if (target == null)
            finderTarget.GetTarget(out target);
        else
        {
            transform.LookAt(target.transform);
        }
    }

    private IEnumerator TimerShot()
    {
        yield return new WaitForSeconds(delayShot);
        if (target != null)
        {
            var bullet = bulletPool.GetObject(spawnPointBullet.position);
            bullet.InitBullet(target, bulletPool.ReturnObject);
        }

        StartCoroutine(TimerShot());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(spawnPointBullet.position, spawnPointBullet.position + spawnPointBullet.forward * 2);
    }
}
