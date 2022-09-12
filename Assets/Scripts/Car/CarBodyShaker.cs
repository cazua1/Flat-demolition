using UnityEngine;
using DG.Tweening;

public class CarBodyShaker : MonoBehaviour
{
    [SerializeField] private Transform _carBody;
    [SerializeField] private Car _car;
    [SerializeField] private float _duration;
    [SerializeField] private Vector3 _strength;

    private Tween _tween;

    private void OnEnable()
    {
        _car.MovementStarted += Shake;
    }

    private void OnDisable()
    {
        _car.MovementStarted -= Shake;
    }

    private void FixedUpdate()
    {
        if (_car.CanMove == false)
        {
            _tween.Kill();
        }
    }

    private void Shake()
    {            
        _tween = _carBody.DOShakePosition(_duration, _strength).SetLoops(-1, LoopType.Yoyo);
    }    
}
