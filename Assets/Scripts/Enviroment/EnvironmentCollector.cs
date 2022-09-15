using System.Collections;
using UnityEngine;
using TMPro;

public class EnvironmentCollector : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particle;
    [SerializeField] private TMP_Text _text;

    private Coroutine _changeAlphaCoroutine;

    private void Start()
    {
        _text.alpha = 0;
    }      

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<DestructibleEnvironment>())
        {
            Instantiate(_particle, collider.transform.position, Quaternion.Euler(-90, 0, 0));
            DisplayText();
        }        
    }

    private void DisplayText()
    {
        _text.alpha = 1;
        HideText();
    }

    private void HideText()
    {
        if (_changeAlphaCoroutine != null)
            StopCoroutine(_changeAlphaCoroutine);

        _changeAlphaCorotine = StartCoroutine(ChangeAlphaValue(0));
    }

    private IEnumerator ChangeAlphaValue(float targetValue)
    {
        float changeStep = 0.01f;

        while (_text.alpha != targetValue)
        {
            _text.alpha = Mathf.MoveTowards(_text.alpha, targetValue, changeStep);
            yield return null;
        }
    }
}
