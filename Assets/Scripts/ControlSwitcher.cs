using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class ControlSwitcher : MonoBehaviour
{
    [SerializeField] private JoystickForMovement _joystick;
    [SerializeField] private Car _demolitionCar;
    [SerializeField] private Car _bulldozer;
    [SerializeField] private Character _character;

    private Car _activeCar;
        
    public event UnityAction GameOver;
    public event UnityAction CarSwitched;

    public Car ActiveCar => _activeCar;
       
    private void Start()
    {
        _activeCar = _demolitionCar;
        _joystick.SetActiveCar(_activeCar);
    }

    private void FixedUpdate()
    {        
        SwitchCar(_bulldozer, _character);

        if (_bulldozer.CanMove == false)
            GameOver?.Invoke();
    }

    private void SwitchCar(Car car, Character character)
    {
        if (_activeCar.CanMove == false && _activeCar != car)
        {
            _activeCar = car;
            TransferCharacterToActiveCar(character, car);
            CarSwitched?.Invoke();
        }
    }
    
    private void TransferCharacterToActiveCar(Character character, Car car)
    {
        int distance = 100;
        float duration = 1f;
        character.transform.SetParent(car.SeatPoint, false);
        character.transform.DOLocalMoveY(distance, duration).From().OnComplete(() => _joystick.SetActiveCar(car));
    }
}