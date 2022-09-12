using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]

public class Car : MonoBehaviour, IMovable
{
    [SerializeField] private float _fuelFlowPerUnit = 1;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private Transform _seatPoint;    

    private Rigidbody _rigidbody;
    private readonly float _minFuelValue = 0;
    private readonly float _maxFuelValue = 100;
    private Vector3 _lastPosition;
    private float _distanceX = 0;
    private float _distanceZ = 0;
    private bool _isMovingStarted;

    public event UnityAction<float> FuelChanged;
    public event UnityAction MovementStarted;

    public float FuelValue { get; private set; }
    public bool CanMove => FuelValue > 0;
    public Transform SeatPoint => _seatPoint;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        FuelValue = _maxFuelValue;
        _lastPosition = transform.position;
        _isMovingStarted = false;
    }

    private void FixedUpdate()
    {
        CheckTraversedDistance();
    }

    public void Move(Vector3 moveDirection)
    {
        if (CanMove)
        {            
            Vector3 offset = _moveSpeed * Time.deltaTime * moveDirection;
            _rigidbody.MovePosition(_rigidbody.position + offset);

            if (_isMovingStarted == false)
            {
                MovementStarted?.Invoke();
                _isMovingStarted = true;
            }            
        }        
    } 

    public void Rotate(Vector3 moveDirection)
    {
        if (CanMove)
        {
            if (Vector3.Angle(transform.forward, moveDirection) > 0)
            {
                Vector3 newDirection = Vector3.RotateTowards(transform.forward, moveDirection, _rotateSpeed, 0);
                transform.rotation = Quaternion.LookRotation(newDirection);
            }
        }
    }

    private void CheckTraversedDistance()
    {
        float minDistance = 0.1f;
        float tempDistanceX = Mathf.Abs(transform.position.x - _lastPosition.x);
        float tempDistanceZ = Mathf.Abs(transform.position.z - _lastPosition.z);

        _lastPosition = transform.position;
        _distanceX += tempDistanceX;
        _distanceZ += tempDistanceZ;
        
        if (_distanceX > minDistance || _distanceZ > minDistance)
        {
            SpendFuel();
            _distanceX = 0;
            _distanceZ = 0;
        }
    }

    private void SpendFuel()
    {        
        ChangeFuelValue(-_fuelFlowPerUnit);
        FuelChanged?.Invoke(FuelValue);
    }

    private void ChangeFuelValue(float value)
    {
        FuelValue += value;
        FuelValue = Mathf.Clamp(FuelValue, _minFuelValue, _maxFuelValue);
    }     
}