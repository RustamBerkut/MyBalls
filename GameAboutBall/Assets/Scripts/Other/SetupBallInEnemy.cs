using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupBallInEnemy : MonoBehaviour
{
    public GameObject _ball;

    private void OnEnable()
    {
        BallSpawner.SetupLevelDataAction += SetupPlayerInCamera;
    }
    private void OnDisable()
    {
        BallSpawner.SetupLevelDataAction -= SetupPlayerInCamera;
    }

    private void SetupPlayerInCamera()
    {
        _ball = GameObject.FindGameObjectWithTag("Ball");
    }
    private void Update()
    {
        if (_ball != null) 
        {   
            transform.LookAt(_ball.transform.position);
        }  
    }
}
