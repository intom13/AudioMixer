using System;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Button _damageButton;
    [SerializeField] private Button _healButton;

    private int _value = 50;

    private readonly int _healValue = 20;
    private readonly int _damageValue = 20;

    private readonly int _maxValue = 100;
    private readonly int _minValue = 0;

    public event Action<int> OnHealthChanged;

    private void ApplyDamage()
    {
        _value -= _damageValue;

        if(_value < _minValue)
            _value = _minValue;

        OnHealthChanged?.Invoke(_value);
    }

    private void ApplyHeal()
    {
        _value += _healValue;

        if (_value > _maxValue)
            _value = _maxValue;

        OnHealthChanged?.Invoke(_value);
    }

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
}