using UnityEngine;

public class CubeColorChanger : MonoBehaviour
{
    private Color _color;

    private Renderer _renderer;
    private Material _newMatireal;

    private float _minColorValue = 0.0f;
    private float _maxColorValue = 1.0f;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();

        _color = GetRandomColor();

        _newMatireal = new Material(_renderer.material);

        _newMatireal.color = _color;
        _renderer.material = _newMatireal;
    }

    private Color GetRandomColor()
    {
        float R = Random.Range(_minColorValue, _maxColorValue);
        float G = Random.Range(_minColorValue, _maxColorValue);
        float B = Random.Range(_minColorValue, _maxColorValue);

        Color randColor = new Color(R, G, B);

        return randColor;
    }
}
