using UnityEngine;

public class JoystickForMovement : JoystickHandler
{
    private Car _activeCar;   

    private void Update()
    {
        if (InputVector.x != 0 || InputVector.y != 0)
        {
            _activeCar.Move(new Vector3(InputVector.x, 0, InputVector.y));
            _activeCar.Rotate(new Vector3(InputVector.x, 0, InputVector.y));
        }
    }

    public void SetActiveCar(Car car)
    {
        _activeCar = car;
    }
}