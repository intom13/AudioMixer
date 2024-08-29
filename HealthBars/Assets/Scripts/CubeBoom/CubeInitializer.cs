using UnityEngine;

[RequireComponent(typeof(CubeSeparator))]
public class CubeInitializer : MonoBehaviour
{
    private Renderer _renderer;
    private CubeSeparator _cubeSeparator;
    private CubeDetonator _cubeDetonator;

    private readonly float _minColorValue = 0.0f;
    private readonly float _maxColorValue = 1.0f;

    private readonly float _reductionScale = 2f;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();

        _renderer.material.color = GetRandomColor();
    }

    public void InitializeNewCube(Vector3 lastScale, float lastChance, float lastExplosionForce, float lastExplosionRadius)
    {
        _cubeSeparator = GetComponent<CubeSeparator>();
        _cubeDetonator = GetComponent<CubeDetonator>();

        DecreaseScale(lastScale);

        _cubeSeparator.DecreaseDivisionChance(lastChance);

        _cubeDetonator.IncreaseExplosionCharacteristics(lastExplosionForce, lastExplosionRadius);
    }

    private void DecreaseScale(Vector3 lastScale)
    {
        transform.localScale = lastScale / _reductionScale;
    }

    private Color GetRandomColor()
    {
        float redChannelValue = Random.Range(_minColorValue, _maxColorValue);
        float greenChannelValue = Random.Range(_minColorValue, _maxColorValue);
        float blueChannelValue = Random.Range(_minColorValue, _maxColorValue);

        return new Color(redChannelValue, greenChannelValue, blueChannelValue);
    }
}
