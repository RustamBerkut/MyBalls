using UnityEngine;
using System.Threading.Tasks;
using System;

public class BallSpawner : MonoBehaviour
{
    public static Action SetupLevelDataAction;
    [SerializeField] private string _playerCurrentName;

    private string _playerName;
    
    private void OnEnable()
    {
        _playerName = PlayerPrefs.GetString(_playerCurrentName, "MainBallPrefab");
        StartGreeting.ActionStartGame += OnPlayerSpawn;
    }
    private void OnDisable()
    {
        StartGreeting.ActionStartGame -= OnPlayerSpawn;
    }
    private void OnPlayerSpawn()
    {
        SetupLevelData();
    }
    private async Task SetupLevelData()
    {
        await SetupPlayerOnScene();
        SetupLevelDataAction?.Invoke();
        Destroy(gameObject);
    }
    private async Task SetupPlayerOnScene()
    {
        Instantiate(Resources.Load(_playerName), transform.position, transform.rotation);
    }
}
