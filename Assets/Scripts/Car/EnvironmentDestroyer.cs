using UnityEngine;

public class EnvironmentDestroyer : MonoBehaviour
{
    [SerializeField] private Material[] _material;

    private void OnTriggerEnter(Collider collider)
    {
        DestructibleEnvironment environment = collider.GetComponent<DestructibleEnvironment>();
        Rigidbody rigidbody = collider.GetComponent<Rigidbody>();
        
        if (collider.GetComponent<DestructibleEnvironment>())
        {            
            environment.ChangeMaterial(_material);
            rigidbody.isKinematic = false;
            rigidbody.AddForceAtPosition(transform.up * 2.5f, transform.position, ForceMode.Impulse);            
        }
    }    
}