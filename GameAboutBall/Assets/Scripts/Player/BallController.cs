using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallController : MonoBehaviour
{
    public BallData _ballData;
    public PlayerInput _playerInput;

    private float _timeDilation;
    private float _ballSpeed;
    private LineRenderer _lineRenderer;
    private Vector3 _beginDragPosition;
    private Vector3 _force;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _ballSpeed = _ballData.BallSpeed;
        _timeDilation = _ballData.TimeDilation;
        _lineRenderer = GetComponent<LineRenderer>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            _beginDragPosition = Input.mousePosition;
            Time.timeScale = _timeDilation;
        }
        if (Input.GetMouseButton(0))
        {
            _force = new(Input.mousePosition.x - _beginDragPosition.x,
                Input.mousePosition.y - _beginDragPosition.y, 0);
            
            Vector3[] point = new Vector3[10];
            _lineRenderer.positionCount = point.Length;
            for (int i = 0; i < point.Length; i++)
            {
                float _time = i * 0.1f;
                point[i] = transform.position + _force * _time + _time * _time * Physics.gravity / (2f + i);
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
    private void OnEnable()
    {
        Time.timeScale = 1;
    }
    private void OnDisable()
    {
        Time.timeScale = 1;
    }
}
