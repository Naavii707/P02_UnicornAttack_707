using UnityEngine;
using UnityEngine.Events;

public class Dash : MonoBehaviour
{
    [SerializeField]
    private float duration = 1.5f;
    [SerializeField]
    private UnityEvent onDash;
    [SerializeField]
    private UnityEvent onDashEnd;
    [SerializeField]
    private float inactiveDuration = 2f;


    private bool canDash = true;
    private bool isDashing;
    public bool IsDashing { get => isDashing; }

    public void DashAction()
    {
        if(!isDashing && canDash)
        {
            canDash = false;
            onDash?.Invoke();
            isDashing = true;
            Invoke(nameof(StopDash), duration);
        }
    }

    private void StopDash()
    {
        onDashEnd?.Invoke();
        isDashing = false;
        Invoke(nameof(EnableDash), inactiveDuration);
    }

    private void EnableDash()
    {
        canDash = true;
    }
}
