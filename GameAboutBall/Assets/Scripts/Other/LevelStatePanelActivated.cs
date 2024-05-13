using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LevelStatePanelActivated : MonoBehaviour
{
    public float _timeOfDisappearance = 2;
    public Button _restartButton;

    private Tween _tween;

    private void OnEnable()
    {
        _tween = transform.DOPunchScale(new Vector3(0.1f, 0.1f, 0.1f), 2).SetEase(Ease.Linear).OnComplete(() =>
        {
            GameWin();
        });
    }
    private void OnDisable()
    {
        _tween.Kill();
    }
    private void GameWin()
    {
        _tween.Kill();
        _tween = _restartButton.image.DOFade(1, _timeOfDisappearance).SetEase(Ease.Linear);
        _tween = _restartButton.GetComponentInChildren<Text>().DOFade(1, _timeOfDisappearance).SetEase(Ease.Linear);
    }
}
