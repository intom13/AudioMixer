using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CubeExplosion : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;
    
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void BlowUp()
    {
        _rigidbody.AddExplosionForce(_explosionForce,transform.position, _explosionRadius);

        DestroyCube();
    }

    private void DestroyCube()
    {
        Destroy(gameObject);
    }
}
