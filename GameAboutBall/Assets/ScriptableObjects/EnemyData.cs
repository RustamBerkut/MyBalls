using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/EnemyData", order = 2)]
public class EnemyData : ScriptableObject
{
    [SerializeField] private float _attackDistance;
    [SerializeField] private float _attackTime;
    [SerializeField] private GameObject _attackBullet;
    [SerializeField] private float _bulletSpeed;

    public float AttackDistance { get => _attackDistance; set => _attackDistance = value; }
    public float AttackTime { get => _attackTime; set => _attackTime = value; }
    public GameObject AttackBullet { get => _attackBullet; set => _attackBullet = value; }
    public float BulletSpeed { get => _bulletSpeed; set => _bulletSpeed = value; }
}
