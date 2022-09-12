using UnityEngine;

public class EnvironmentDestroyer : MonoBehaviour
{
    [SerializeField] private Material[] _material;
    [SerializeField] private float _forse = 2.5f;

    private void OnTriggerEnter(Collider collider)
    {
        DestructibleEnvironment environment = collider.GetComponent<DestructibleEnvironment>();
        Rigidbody rigidbody = collider.GetComponent<Rigidbody>();
        
        if (collider.GetComponent<DestructibleEnvironment>())
        {            
            environment.ChangeMaterial(_material);
            rigidbody.isKinematic = false;
            rigidbody.AddForceAtPosition(transform.up * _forse, transform.position, ForceMode.Impulse);            
        }
    }    
}