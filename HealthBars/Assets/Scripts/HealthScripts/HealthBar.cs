using UnityEngine;
using UnityEngine.UI;

public class HealthBar : HealthDisplayer
{
    [SerializeField] private Slider _bar;

    protected override void DisplayHealth(float health)
    {
        _bar.value = health / _health.MaxValue;
    }
}
