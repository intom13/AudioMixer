using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CubeDetonator))]
public class CubeSeparator : MonoBehaviour
{
    private CubeDetonator _cubeDetonator;
    private CubeSpawner _cubeSpawner;

    private float _divisionChance = 100;
    private readonly float _reductionCoefficent = 2;

    private readonly int _minNewCubeCount = 2;
    private readonly int _maxNewCubeCount = 6;

    private readonly int _minChance = 0;
    private readonly int _maxChance = 100;

    public float DivisionChance => _divisionChance;

    private void Start()
    {
        _cubeDetonator = GetComponent<CubeDetonator>();
        _cubeSpawner = GetComponent<CubeSpawner>();
    }

    public void DivideOrVanish()
    {
        if (GetRandomChanceNumber() < _divisionChance)
            _cubeSpawner.DivideCube(GetRandomNewCubeCount());
        else
            _cubeDetonator.BlowUp(_cubeDetonator.GetNearestRigidbodies());
    }

    public void DecreaseDivisionChance(float lastChance)
    {
        _divisionChance = lastChance / _reductionCoefficent;
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
