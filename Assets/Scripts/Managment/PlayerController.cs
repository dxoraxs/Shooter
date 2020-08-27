using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private ShotController shotController;
    private Character player;
    
    public void SetPlayerSetting(int health)
    {
        player.transform.position = Vector3.zero;
        player.ResetCharacter(health); 
        shotController.enabled = true;
    }
    
    public void InitController(Character player, PoolObject bulletPool, Action manDied)
    {
        this.player = player;
        manDied += () => shotController.enabled = false;
        player.InitCharacter(manDied);
        shotController = player.GetComponent<ShotController>();
        shotController.InitShotController(bulletPool);
    }
}
