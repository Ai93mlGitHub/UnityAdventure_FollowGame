using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    [SerializeField] private Transform _targetPoint;
    [SerializeField] private float _speedMove;
    [SerializeField] private float _speedRotation;
    [SerializeField] private float _stopDistanceThreshold = 0.1f;
    [SerializeField] private float _stopRotationThreshold = 5f;

    void Update()
    {
        Vector3 direction = _targetPoint.position - transform.position;
        direction.y = 0;

        if (direction.magnitude > _stopDistanceThreshold)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _speedRotation * Time.deltaTime);

            if (Quaternion.Angle(transform.rotation, targetRotation) < _stopRotationThreshold)
            {
                transform.position = Vector3.MoveTowards(transform.position, _targetPoint.position, _speedMove * Time.deltaTime);
            }
        }
    }
}
