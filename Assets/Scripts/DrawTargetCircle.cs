using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTargetCircle : MonoBehaviour
{
    [SerializeField] private GameController _gameController;
   [SerializeField] private int _segments = 36;
    [SerializeField] private float _lineWidth = 0.3f;
    [SerializeField] private Color _circleColor = Color.white;

    private float _radius;
    private LineRenderer _lineRenderer;

    private void Awake()
    {
        _radius = _gameController.RadiusGoal;
    }
    void Start()
    {
        _lineRenderer = gameObject.GetComponent<LineRenderer>();

        _lineRenderer.positionCount = _segments + 1;
        _lineRenderer.widthMultiplier = _lineWidth;
        _lineRenderer.useWorldSpace = false;
        _lineRenderer.startColor = _circleColor;
        _lineRenderer.endColor = _circleColor;

        CreateCircle();
    }
    void CreateCircle()
    {
        float angle = 360f / _segments;
        for (int i = 0; i <= _segments; i++)
        {
            float radian = Mathf.Deg2Rad * angle * i;
            float x = Mathf.Cos(radian) * _radius;
            float z = Mathf.Sin(radian) * _radius;
            _lineRenderer.SetPosition(i, new Vector3(x, 0, z));
        }
    }
}
