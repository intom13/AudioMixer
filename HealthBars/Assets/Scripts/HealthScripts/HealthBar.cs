using UnityEngine;
using UnityEngine.UI;

public class HealthBar : HealthDisplayer
{
    [SerializeField] private Slider _bar;

    public override void DisplayHealth(int health)
    {
        _bar.value = health;
    }
}
