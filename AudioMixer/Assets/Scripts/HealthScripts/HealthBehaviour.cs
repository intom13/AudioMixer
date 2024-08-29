using UnityEngine;

public class HealthBehaviour : MonoBehaviour
{
    [SerializeField] private HealthDisplayer _healthDisplayer;
    
    private int _health = 100;

    private readonly int _healValue = 10;
    private readonly int _damageValue = 15;

    private readonly int _maxHealth = 100;
    private readonly int _minHealth = 0;

    public void ApplyDamage()
    {
        _health -= _damageValue;

        if(_health < _minHealth)
            _health = _minHealth;

        _healthDisplayer.DisplayHealth(_health);
    }

    public void ApplyHeal()
    {
        _health += _healValue;

        if (_health > _maxHealth)
            _health = _maxHealth;

        _healthDisplayer.DisplayHealth(_health);
    }
}