using System;
public class Enemy : Character
{
    public void InitEnemy(int health, Action onManDied, PoolObject bulletPool)
    {
        ResetCharacter(health);
        InitCharacter(onManDied);
        GetComponent<ShotController>().InitShotController(bulletPool);
    }
    
    protected override void Death()
    {
        base.Death();
        Destroy(gameObject);
    }
}