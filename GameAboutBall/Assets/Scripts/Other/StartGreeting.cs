using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using System;

public class StartGreeting : MonoBehaviour
{
    public static Action ActionStartGame;
    public float _timeOfDisappearance = 3;

    private Text _text;
    private Tween _tween;

    private void Start()
    {
        _text = GetComponent<Text>();
        _tween = _text.transform.DOPunchScale(new Vector3(0.1f, 0.1f, 0.1f), 2);
        _tween.SetLoops(-1);
    }
    public void StartGame()
    {
        ActionStartGame?.Invoke();
        _tween.Kill();
        _tween = _text.DOFade(0, _timeOfDisappearance).SetEase(Ease.Linear).OnComplete(() =>
        {
            Destroy(gameObject);
        });
    }
}
