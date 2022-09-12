using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private ControlSwitcher _switcher;
    [SerializeField] private Image _screen;
    [SerializeField] private Image _joystick;
    [SerializeField] private Slider _slider;

    private void OnEnable()
    {
        _switcher.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _switcher.GameOver -= OnGameOver;
    }

    private void OnGameOver()
    {        
        _screen.gameObject.SetActive(true);
        _joystick.gameObject.SetActive(false);
        _slider.gameObject.SetActive(false);
    }
}
