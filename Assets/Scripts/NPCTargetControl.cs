using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTargetControl : MonoBehaviour
{
    [SerializeField] private Transform _borderUp;
    [SerializeField] private Transform _borderDown;
    [SerializeField] private Transform _borderLeft;
    [SerializeField] private Transform _borderRight;
    [SerializeField] private float _yCoordinate;
    [SerializeField] private Transform _npc;
    [SerializeField] private float _goalDistanceThreshold = 1f;

    void Start()
    {
        SetRandomCoordinateWithinBorders();
    }

    void Update()
    {
        float magnitude = (transform.position - _npc.position).magnitude;

        if (magnitude < _goalDistanceThreshold)
        {
            SetRandomCoordinateWithinBorders();
        }
    }

    public void SetRandomCoordinateWithinBorders()
    {
        float randomX = Random.Range(_borderLeft.position.x, _borderRight.position.x);
        float randomZ = Random.Range(_borderDown.position.z, _borderUp.position.z);

        transform.position = new Vector3(randomX, _yCoordinate, randomZ);
    }
}
