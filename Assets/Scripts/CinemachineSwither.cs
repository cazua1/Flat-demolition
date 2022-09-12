using UnityEngine;
using Cinemachine;

public class CinemachineSwither : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _vcam1;
    [SerializeField] private CinemachineVirtualCamera _vcam2;
    [SerializeField] private ControlSwitcher _switcher;

    private void OnEnable()
    {
        _switcher.CarSwitched += OnCarSwitched;
    }

    private void OnDisable()
    {
        _switcher.CarSwitched -= OnCarSwitched;
    }

    private void OnCarSwitched()
    {
        _vcam1.Priority = 0;
        _vcam2.Priority = 1;
    }
}
