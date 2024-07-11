using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CubeDetonator))]
public class CubeSeparator : MonoBehaviour
{
    [SerializeField] private CubeSeparator _cubePrefab;

    private CubeDetonator _cubeDetonator;
    private Transform _transform;

    private float _divisionChance = 100;
    private readonly float _reductionCoefficent = 2;

    private readonly int _minNewCubeCount = 2;
    private readonly int _maxNewCubeCount = 6;

    private readonly int _minChance = 0;
    private readonly int _maxChance = 100;

    private List<Rigidbody> _childrenRigidbodys = new List<Rigidbody>();

    private void Start()
    {
        _cubeDetonator = GetComponent<CubeDetonator>();
        _transform = GetComponent<Transform>();
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
            _cubeDetonator.DestroyCube();
    }

    private void Division()
    {
        CubeSeparator newCube;

        for(int i = 0; i < GetRandomNewCubeCount(); i++)
        {
            newCube = Instantiate(_cubePrefab, _transform.position, Quaternion.identity);

            if (newCube.TryGetComponent(out CubeScaleChanger cubeScaleChanger))
                cubeScaleChanger.ChangeScale(transform.localScale);

            if (newCube.TryGetComponent(out CubeSeparator cubeSeparator))
                cubeSeparator.ChangeDivisionChance(_divisionChance);

            if (newCube.TryGetComponent(out Rigidbody childRigidbody))
                _childrenRigidbodys.Add(childRigidbody);
        }

        _cubeDetonator.BlowUp(_childrenRigidbodys);
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
