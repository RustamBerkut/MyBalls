using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupBallInCamera : MonoBehaviour
{
    private CinemachineVirtualCamera _virtualCamera;

    private void OnEnable()
    {
        _virtualCamera = GetComponent<CinemachineVirtualCamera>();
        BallSpawner.SetupLevelDataAction += SetupPlayerInCamera;
    }
    private void OnDisable()
    {
        BallSpawner.SetupLevelDataAction -= SetupPlayerInCamera;
    }

    private void SetupPlayerInCamera()
    {
        GameObject _ball = GameObject.FindGameObjectWithTag("Ball");
        _virtualCamera.Follow = _ball.transform;
        _virtualCamera.LookAt = _ball.transform;
    }
}
