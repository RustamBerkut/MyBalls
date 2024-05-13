using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float _ballSpeed;

    private LineRenderer _lineRenderer;
    private Vector3 _beginDragPosition;
    private Vector3 _force;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _beginDragPosition = Input.mousePosition;
            Time.timeScale = 0.3f;
        }
        if (Input.GetMouseButton(0))
        {
            _force = new(Input.mousePosition.x - _beginDragPosition.x,
                Input.mousePosition.y - _beginDragPosition.y, 0);
            float _distance = Vector3.Distance(_beginDragPosition, Input.mousePosition);

            Vector3[] point = new Vector3[5];
            _lineRenderer.positionCount = point.Length;
            for (int i = 0; i < point.Length; i++)
            {
                float _time = i * 0.01f;
                point[i] = transform.position + _force * _time;
            }
            _lineRenderer.SetPositions(point);

        }
        if (Input.GetMouseButtonUp(0))
        {
            _rigidbody.velocity = new Vector2(0f, 0f);
            _rigidbody.AddForce(_force * _ballSpeed);
            _lineRenderer.positionCount = 0;
            Time.timeScale = 1;
        }
    }
    private void OnDisable()
    {
        Time.timeScale = 1;
    }
}
