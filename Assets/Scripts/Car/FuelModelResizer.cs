using UnityEngine;
using DG.Tweening;

public class FuelModelResizer : MonoBehaviour
{    
    [SerializeField] private Car _car;    

    private Transform _transform;
    private readonly float _delay = 1f;
    private readonly float _step = 0.01f;

    private void OnEnable()
    {
        _car.FuelChanged += Resize;
    }

    private void OnDisable()
    {
        _car.FuelChanged -= Resize;
    }

    private void Start()
    {
        _transform = transform;        
    }   

    private void Resize(float fuelValue)
    {        
        float size = fuelValue * _step;
        _transform.DOScaleY(size, _delay);     
    }
}