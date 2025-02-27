using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private UnityEvent onGameStart;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        onGameStart.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
