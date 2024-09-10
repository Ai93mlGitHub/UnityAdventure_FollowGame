using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _rotationSpeed = 10f;
    [SerializeField] private float _movementThreshold;
    private Vector3 _startPosition;
    private bool _isMoving = true;

    private void Start()
    {
        _startPosition = gameObject.transform.position;
    }

    void Update()
    {

        if (_isMoving)
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");
            Vector3 move = new Vector3(moveX, 0, moveZ);

            if(move.magnitude > _movementThreshold)
            {
                transform.Translate(move.normalized * _moveSpeed * Time.deltaTime, Space.World);
                Quaternion toRotation = Quaternion.LookRotation(move, Vector3.up);
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
