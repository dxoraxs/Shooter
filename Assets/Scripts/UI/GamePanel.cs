using UnityEngine;

public class GamePanel : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    
    private void OnDisable()
    {
        joystick.OnDisablePanel();
    }
}
