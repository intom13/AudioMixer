using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CubeDetonator))]
public class CubeSeparator : MonoBehaviour
{
    [SerializeField] private CubeSeparator _cubePrefab;

    private CubeDetonator _cubeDetonator;

    private float _divisionChance = 100;
    private readonly float _reductionCoefficent = 2;

    private readonly int _minNewCubeCount = 2;
    private readonly int _maxNewCubeCount = 6;

    private readonly int _minChance = 0;
    private readonly int _maxChance = 100;

    private List<Rigidbody> _childrenRigidbodies = new List<Rigidbody>();

    private void Start()
    {
        _cubeDetonator = GetComponent<CubeDetonator>();
    }

    public void ChangeDivisionChance(float lastChance)
    {
        _divisionChance = lastChance / _reductionCoefficent;
    }

    public void CheckDivisionChance()
    {
        if (GetRandomChanceNumber() < _divisionChance)
            Division();
        else
            _cubeDetonator.BlowUp(_cubeDetonator.GetNearestRigidbodies());
    }

    private void Division()
    {
        CubeSeparator newCube;

        for(int i = 0; i < GetRandomNewCubeCount(); i++)
        {
            newCube = Instantiate(_cubePrefab, transform.position, Quaternion.identity);

            if (newCube.TryGetComponent(out CubeScaleChanger cubeScaleChanger))
                cubeScaleChanger.ChangeScale(transform.localScale);

            if (newCube.TryGetComponent(out CubeSeparator cubeSeparator))
                cubeSeparator.ChangeDivisionChance(_divisionChance);

            if (newCube.TryGetComponent(out CubeDetonator cubeDetonator))
                cubeDetonator.ChangeExplosionCharacteristics(_cubeDetonator.ExplosionForce, _cubeDetonator.ExplosionRadius);

            if (newCube.TryGetComponent(out Rigidbody childRigidbody))
                _childrenRigidbodies.Add(childRigidbody);
        }

        _cubeDetonator.BlowUp(_childrenRigidbodies);
    }

    private int GetRandomNewCubeCount()
    {
        return Random.Range(_minNewCubeCount, _maxNewCubeCount);
    }

    private int GetRandomChanceNumber()
    {
        return Random.Range(_minChance, _maxChance);
    }
}
