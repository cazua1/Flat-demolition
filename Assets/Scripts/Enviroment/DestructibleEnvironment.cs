using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeshRenderer))]

public class DestructibleEnvironment : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private MeshRenderer _renderer;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _renderer = GetComponent<MeshRenderer>();
    }

    public void ChangeMaterial(Material[] material)
    {
        _renderer.materials = material;
    }

    public void Crash()
    {
        _rigidbody.isKinematic = false;        
        _rigidbody.AddForceAtPosition(transform.up * 5, transform.position, ForceMode.Impulse);
    }
}
