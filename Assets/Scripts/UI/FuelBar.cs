using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Slider))]

public class FuelBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;     
    [SerializeField] private Car _demolutionCar;
    [SerializeField] private Car _bulldozer;
    
    private void OnEnable()
    {
        _demolutionCar.FuelChanged += ChangeSliderValue;
        _bulldozer.FuelChanged += ChangeSliderValue;
    }

    private void OnDisable()
    {
        _demolutionCar.FuelChanged -= ChangeSliderValue;
        _bulldozer.FuelChanged -= ChangeSliderValue;
    }

    private void ChangeSliderValue(float fuelValue)
    {
        float delay = 0f;
        _slider.DOValue(fuelValue, delay);
    }      
}