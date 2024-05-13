using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateActionLevel : MonoBehaviour
{
    public GameObject _winPanel;
    public GameObject _losePanel;

    private void OnEnable()
    {
        BallLevelComplete.LevelWasWinAction += ActivatedWinPanel;
        Ball.BallWasDeadAction += ActivatedLosePanel;
    }
    private void OnDisable()
    {
        BallLevelComplete.LevelWasWinAction -= ActivatedWinPanel;
        Ball.BallWasDeadAction -= ActivatedLosePanel;
    }
    private void ActivatedWinPanel()
    {
        _winPanel.SetActive(true);
    }
    private void ActivatedLosePanel()
    {
        _losePanel.SetActive(true);
    }
}
