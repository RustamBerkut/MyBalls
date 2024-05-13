using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BallData", order = 1)]
public class BallData : ScriptableObject
{
    [SerializeField] private int _ballHealth;
    [SerializeField] private float _ballSpeed;
    [SerializeField] private float _timeDilation;

    public int BallHealth { get => _ballHealth; set => _ballHealth = value; }
    public float BallSpeed { get => _ballSpeed; set => _ballSpeed = value; }
    public float TimeDilation { get => _timeDilation; set => _timeDilation = value; }
}
