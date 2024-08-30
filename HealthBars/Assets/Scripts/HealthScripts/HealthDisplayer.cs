using UnityEngine;

public class HealthDisplayer : Health
{
    [SerializeField] private TextHealthBar _textHealthBar;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private SmoothHealthBar _smoothHealthBar;

    private void ActivateDisplayers(int health)
    {
        _textHealthBar.DisplayHealth(health);
        _smoothHealthBar.DisplayHealth(health);
        _healthBar.DisplayHealth(health);
    }

    public virtual void DisplayHealth(int health) { }
    
    private void OnEnable()
    {
        OnHealthChanged += ActivateDisplayers;
    }

    private void OnDisable()
    {
        OnHealthChanged -= ActivateDisplayers;
    }
}