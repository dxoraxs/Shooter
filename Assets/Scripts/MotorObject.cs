using UnityEngine;

public class MotorObject : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody rigidbody;
    
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void MoveObject(Vector3 direction)
    {
        rigidbody.velocity = direction * speed;
    }
}
