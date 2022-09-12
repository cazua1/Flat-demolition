using UnityEngine;
using DG.Tweening;

public class ModelRotator : MonoBehaviour
{    
    [SerializeField] private Car _car;
    [SerializeField] private float _duration;


    private Tween _tween;

    private void OnEnable()
    {
        _car.MovementStarted += Rotate;
    }

    private void OnDisable()
    {
        _car.MovementStarted -= Rotate;
    }

    private void FixedUpdate()
    {
        if (_car.CanMove == false)
        {
            _tween.Kill();
        }
    }

    private void Rotate()
    {        
        _tween = transform.DOLocalRotate(new Vector3(-360, 0, 0), _duration).SetEase(Ease.Linear).SetLoops(-1);        
    } 
}
