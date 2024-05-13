using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLevelComplete : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<FinishLine>())
        {
            Debug.Log("Level was finished");
        }
    }
}
