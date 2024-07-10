using UnityEngine;

[RequireComponent(typeof(CubeExplosion))]
public class CubeDivision : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;

    private CubeExplosion _cubeExplosion;

    private int _divisionChance = 100;

    private int _minNewCubeCount = 2;
    private int _maxNewCubeCount = 6;

    private int _minChance = 0;
    private int _maxChance = 100;

    private void Start()
    {
        _cubeExplosion = GetComponent<CubeExplosion>();
    }

    public void ChangeDivisionChance(int lastChance)
    {
        _divisionChance = lastChance / 2;
    }

    public void CheckDivisionChance()
    {
        if (GetRandomChanceNumber() < _divisionChance)
            Division();
        else
            _cubeExplosion.BlowUp();
    }

    private void Division()
    {
        GameObject newCube;

        for(int i = 0; i < GetRandomNewCubeCount(); i++)
        {
            newCube = Instantiate(_cubePrefab, transform.position, Quaternion.identity);

            if (newCube.TryGetComponent<CubeScaleChanger>(out CubeScaleChanger cubeChanger))
            {
                cubeChanger.ChangeScale(transform.localScale);
            }

            if (newCube.TryGetComponent<CubeDivision>(out CubeDivision cubeDivision))
            {
                cubeDivision.ChangeDivisionChance(_divisionChance);
            }

        }

        _cubeExplosion.BlowUp();
    }

    private int GetRandomNewCubeCount()
    {
        int randNewCubeCount = UnityEngine.Random.Range(_minNewCubeCount, _maxNewCubeCount);

        return randNewCubeCount;
    }

    private int GetRandomChanceNumber()
    {
        int randChanceNumber = UnityEngine.Random.Range(_minChance, _maxChance);

        return randChanceNumber;
    }
}
