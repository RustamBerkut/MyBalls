using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public enum States
{
    Gun,
    Laser
}

public class Enemy : MonoBehaviour
{
    public EnemyGun enemyGun = new();
    public EnemyLaser enemyLaser = new();
    public States states;
    
    [SerializeField] private EnemyData enemyData;
    [SerializeField] private Transform barrel;

    private GameObject _attackBullet;
    private GameObject _ball;

    private float _attackDistance;
    private float _attackTime;
    private float _bulletSpeed;
    private float _currentTimer;

    private void Start()
    {
        SetupEnemyData();
        CreateDetectSphere();
    }
    private void SetupEnemyData()
    {
        _attackDistance = enemyData.AttackDistance;
        _attackTime = enemyData.AttackTime;
        _attackBullet = enemyData.AttackBullet;
        _bulletSpeed = enemyData.BulletSpeed;
        _currentTimer = _attackTime;
    }
    private void CreateDetectSphere()
    {
        this.gameObject.AddComponent<SphereCollider> ();
        GetComponent<SphereCollider>().isTrigger = true;
        GetComponent<SphereCollider>().radius = _attackDistance / 2;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Ball>())
        {
            _ball = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Ball>())
        {
            _ball = null;
        }
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
                Ray ray = new(transform.position, transform.forward);
                if (Physics.Raycast(ray, out RaycastHit hitInfo, _attackDistance))
                {
                    if (hitInfo.collider.GetComponent<Ball>())
                    {
                        _currentTimer = _attackTime;
                        switch (states)
                        {
                            case States.Gun:
                                EnemyAttack(enemyGun);
                                break;
                            case States.Laser:
                                EnemyAttack(enemyLaser);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
    }
    private void EnemyAttack(IEnemyShoot enemyShoot)
    {
        enemyShoot.IEnemyAttack();
    }
}


