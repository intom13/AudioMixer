using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CubeDetonator : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;
    
    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    public void BlowUp(List<Rigidbody> childrenRigidbodys)
    {
        Debug.Log("Btoom");
        foreach (var childRigidbody in childrenRigidbodys)
        {
            childRigidbody.AddExplosionForce(_explosionForce, _transform.position, _explosionRadius);
        }

        DestroyCube();
    }

    public void DestroyCube()
    {
        Destroy(gameObject);
    }
}
