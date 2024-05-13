using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public byte damage;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
