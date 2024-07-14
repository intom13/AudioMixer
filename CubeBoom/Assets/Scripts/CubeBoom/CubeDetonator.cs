using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CubeDetonator : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;

    private readonly float _reductionCoefficent = 0.5f;

    public float ExplosionForce => _explosionForce;
    public float ExplosionRadius => _explosionRadius;

    public void BlowUp(List<Rigidbody> childrenRigidbodies)
    {
        foreach (Rigidbody childRigidbody in childrenRigidbodies)
        {
            childRigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }

        DestroyCube();
    }

    public List<Rigidbody> GetNearestRigidbodies()
    {
        Collider[] nearestColliders = Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Rigidbody> nearestRigidbodies = new List<Rigidbody>();

        foreach(Collider nearlyCollider in nearestColliders)
        {
            if(nearlyCollider.TryGetComponent(out Rigidbody itemRigidbody))
                nearestRigidbodies.Add(itemRigidbody);
        }

        return nearestRigidbodies;
    }

    public void IncreaseExplosionCharacteristics(float lastExplosionForce, float lastExplosionRadius)
    {
        _explosionForce = lastExplosionForce / _reductionCoefficent;
        _explosionRadius = lastExplosionRadius / _reductionCoefficent;
    }

    private void DestroyCube()
    {
        Destroy(gameObject);
    }
}
