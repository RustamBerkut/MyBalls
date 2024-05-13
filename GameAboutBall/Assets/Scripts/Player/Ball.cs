using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ball : MonoBehaviour
{
    public static Action BallWasDeadAction;
    public BallData _ballData;
    public BallHealthSystem _healthSystem;

    private int _maxHealth;
    private int _currentHealth;

    private void Start()
    {
        _maxHealth = _ballData.BallHealth;
        _currentHealth = _maxHealth;
        _healthSystem.SetMaxHealth(_maxHealth);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BulletDamage>()) 
        {
            int _damage = other.gameObject.GetComponent<BulletDamage>().damage;
            OnBallTakeDamage(_damage);
        }
    }

    private void OnBallTakeDamage(int damage)
    {
        _currentHealth -= damage;
        _healthSystem.SetHealth(_currentHealth);

        if (_currentHealth <= 0)
        {
            BallWasDeadAction?.Invoke();
            BallDeath();
        }
    }
    private void BallDeath()
    {
        Destroy(gameObject);
    }
}
