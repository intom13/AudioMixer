using System;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Button _damageButton;
    [SerializeField] private Button _healButton;

    private float _value = 100.0f;

    private readonly int _healValue = 20;
    private readonly int _damageValue = 20;

    private readonly float _maxValue = 100.0f;
    private readonly float _minValue = 0.0f;

    public event Action<float> Changed;

    public float MaxValue => _maxValue;

    private void OnEnable()
    {
        _damageButton.onClick.AddListener(ApplyDamage);
        _healButton.onClick.AddListener(ApplyHeal);
    }

    private void OnDisable()
    {
        _damageButton.onClick.RemoveListener(ApplyDamage);
        _healButton.onClick.RemoveListener(ApplyHeal);
    }

    private void ApplyDamage()
    {
        _value -= _damageValue;

        if(_value < _minValue)
            _value = _minValue;

        Changed?.Invoke(_value);
    }

    private void ApplyHeal()
    {
        _value += _healValue;

        if (_value > _maxValue)
            _value = _maxValue;

        Changed?.Invoke(_value);
    }
}