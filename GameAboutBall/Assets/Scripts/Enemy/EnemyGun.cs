using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyGun : IEnemyShoot
{

    public void IEnemyAttack()
    {
        Debug.Log("Gun");
        /*GameObject _bullet = Instantiate(_attackBullet, barrel.position, barrel.rotation);
        _bullet.GetComponent<Rigidbody>().AddForce(transform.forward * _bulletSpeed);*/
    }
}
