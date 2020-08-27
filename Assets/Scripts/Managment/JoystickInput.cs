using UnityEngine;

public class JoystickInput : MonoBehaviour
{
    [SerializeField] private Joystick joystick;

    private MotorObject motor;

    private void Awake()
    {
        motor = GetComponent<MotorObject>();
    }

    private void Update()
    {
        var direction = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
        motor.MoveObject(direction);
    }
}