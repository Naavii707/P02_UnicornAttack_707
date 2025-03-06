using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private UnityEvent onGameStart;

    [SerializeField]
    private UnityEvent onRespawnGame;

    [SerializeField]
    private float secondsToRestart = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        onGameStart.Invoke();
    }

    public void PlayerLose()
    {
        Invoke(nameof(RestartGame), secondsToRestart);
    }

    public void RestartGame()
    {
        onRespawnGame?.Invoke();
    }
}
