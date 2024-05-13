using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BallLevelComplete : MonoBehaviour
{
    public static Action LevelWasWinAction; 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<FinishLine>())
        {
            LevelWasWinAction?.Invoke();
            Destroy(gameObject);
        }
    }
}
