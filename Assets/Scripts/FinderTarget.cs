using UnityEngine;

public class FinderTarget : MonoBehaviour
{
    [SerializeField] private LayerMask targetMask;

    public void GetTarget(out Character targetCharacter)
    {
        Collider target = null;
        float distance = float.MaxValue;

        var colliders = Physics.OverlapSphere(transform.position, 15, targetMask);
        if (colliders.Length > 0)
        {
            foreach (var character in colliders)
            {
                var value = (transform.position - character.transform.position).magnitude;
                if (distance > value)
                {
                    distance = value;
                    target = character;
                }
            }

            targetCharacter = target.GetComponent<Character>();
            return;
        }

        targetCharacter = null;
    }
}