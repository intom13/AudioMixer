using TMPro;
using UnityEngine;

public class TextHealthBar : HealthDisplayer
{
    [SerializeField] private TMP_Text _bar;

    private readonly char _textBarSeparator = '/';
    private readonly int _maxHealthValue = 100;

    public override void DisplayHealth(int health)
    {
        _bar.text = health.ToString() + _textBarSeparator + _maxHealthValue;
    }
}
