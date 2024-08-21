using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private CubeInitializer _cubePrefab;

    private CubeDetonator _cubeDetonator;
    private CubeSeparator _cubeSeparator;

    private readonly List<Rigidbody> _childrenRigidbodies = new List<Rigidbody>();

    private void Start()
    {
        _cubeDetonator = GetComponent<CubeDetonator>();
        _cubeSeparator = GetComponent<CubeSeparator>();
    }

    public void DivideCube(int newCubeCount)
    {
        CubeInitializer newCube;

        for (int i = 0; i < newCubeCount; i++)
        {
            newCube = Instantiate(_cubePrefab, transform.position, Quaternion.identity);

            newCube.InitializeNewCube(transform.localScale, _cubeSeparator.DivisionChance, _cubeDetonator.ExplosionForce, _cubeDetonator.ExplosionRadius);

            if (newCube.TryGetComponent(out Rigidbody childRigidbody))
                _childrenRigidbodies.Add(childRigidbody);
        }

        _cubeDetonator.BlowUp(_childrenRigidbodies);
    }
}
