using UnityEngine;

public class CubeColorChanger : MonoBehaviour
{
    private Renderer _renderer;

    private float _minColorValue = 0.0f;
    private float _maxColorValue = 1.0f;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();

        _renderer.material.color = GetRandomColor();
    }

    private Color GetRandomColor()
    {
        float R = Random.Range(_minColorValue, _maxColorValue);
        float G = Random.Range(_minColorValue, _maxColorValue);
        float B = Random.Range(_minColorValue, _maxColorValue);

        return new Color(R, G, B);
    }
}
