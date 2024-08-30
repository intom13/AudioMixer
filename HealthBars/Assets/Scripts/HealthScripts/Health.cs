using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int _value = 50;

    private readonly int _healValue = 20;
    private readonly int _damageValue = 20;

    private readonly int _maxValue = 100;
    private readonly int _minValue = 0;

    public event Action<int> OnHealthChanged;

    public void ApplyDamage()
    {
        _value -= _damageValue;

        if(_value < _minValue)
            _value = _minValue;

        OnHealthChanged?.Invoke(_value);
    }

    public void ApplyHeal()
    {
        _value += _healValue;

        if (_value > _maxValue)
            _value = _maxValue;

        OnHealthChanged?.Invoke(_value);
    }
}