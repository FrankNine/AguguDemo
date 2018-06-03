using UnityEngine;
using Zenject;

public class KeyboardListener : MonoBehaviour
{
    [Inject] IncreaseRequestedSignal _increaseRequestedSignal;
    [Inject] DecreaseRequestedSignal _decreaseRequestedSignal;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _decreaseRequestedSignal.Fire();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            _increaseRequestedSignal.Fire();
        }
    }
}