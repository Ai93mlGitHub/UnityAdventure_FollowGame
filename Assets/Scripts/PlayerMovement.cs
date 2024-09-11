using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _rotationSpeed = 10f;
    [SerializeField] private float _movementThreshold;

    private Vector3 _startPosition;
    private bool _isMoving = true;
    private float movementAxisX;
    private float movementAxisZ;


    private void Awake()
    {
        _startPosition = gameObject.transform.position;
    }

    void Update()
    {
        if (_isMoving)
        {
            movementAxisX = Input.GetAxis("Horizontal");
            movementAxisZ = Input.GetAxis("Vertical");
            Vector3 movementDirection = new Vector3(movementAxisX, 0, movementAxisZ);

            if(movementDirection.magnitude > _movementThreshold)
            {
                transform.Translate(movementDirection.normalized * _moveSpeed * Time.deltaTime, Space.World);
                Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, _rotationSpeed * Time.deltaTime);
            }
        }
    }

    public void Restart()
    {
        gameObject.transform.position = _startPosition;
        _isMoving = true;
    }

    public void StopMoving()
    {
        _isMoving = false;
    }
}
