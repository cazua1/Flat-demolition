using UnityEngine;

public class EnvironmentPusher : MonoBehaviour
{
    [SerializeField] private float _forse = 25f;    

    private void OnTriggerStay(Collider collider)
    {
        Rigidbody rigidbody = collider.GetComponent<Rigidbody>();

        if (collider.GetComponent<DestructibleEnvironment>())
        {            
            rigidbody.AddForceAtPosition(transform.forward * _forse, transform.position);
            rigidbody.AddForceAtPosition(transform.up * _forse, transform.position);
        }
    }
}
