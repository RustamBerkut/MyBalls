using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupBallInEnemy : MonoBehaviour
{
    public EnemyData _enemyData;
    public Transform _barrel;

    private float _attackDistance;
    private float _attackTime;
    private float _bulletSpeed;
    private GameObject _attackBullet;
    private GameObject _ball;
    private float _currentTimer;

    private void OnEnable()
    {
        BallSpawner.SetupLevelDataAction += SetupPlayerInCamera;
        SetupDataOnenemy();
    }
    private void OnDisable()
    {
        BallSpawner.SetupLevelDataAction -= SetupPlayerInCamera;
    }
    private void SetupDataOnenemy()
    {
        _attackDistance = _enemyData.AttackDistance;
        _attackTime = _enemyData.AttackTime;
        _attackBullet = _enemyData.AttackBullet;
        _bulletSpeed = _enemyData.BulletSpeed;
        _currentTimer = _attackTime;
    }

    private void SetupPlayerInCamera()
    {
        _ball = GameObject.FindGameObjectWithTag("Ball");
    }
    private void Update()
    {
        if (_ball != null) 
        {
            _currentTimer -= Time.deltaTime;
            transform.LookAt(_ball.transform.position);
            float _distanceBeetwen = Vector3.Distance(transform.position, _ball.transform.position);
            if (_attackDistance >= _distanceBeetwen && _currentTimer <= 0) 
            {
                _currentTimer = _attackTime;
                OnBallAttack();
            }
        }  
    }

    private void OnBallAttack()
    {
        GameObject _bullet = Instantiate(_attackBullet, _barrel.position, _barrel.rotation);
        _bullet.GetComponent<Rigidbody>().AddForce(transform.forward * _bulletSpeed);
    }
}
