using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplayer : HealthBehaviour
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Slider _smoothHealthBar;
    [SerializeField] private TMP_Text _textBar;

    [SerializeField] private float _smoothSpeed;

    private readonly char _textBarSeparator = '/';
    private readonly int _maxHealthValue = 100;

    private WaitForSeconds _smoothBarUpdate = new WaitForSeconds(0.01f);

    public void DisplayHealth(int health)
    {
        StartCoroutine(DisplaySmoothHealthBar(health));
        DisplayHealthBar(health);
        DisplayTextHealthBar(health);
    }

    private void DisplayHealthBar(int health)
    {
        _healthBar.value = health;
    }

    private IEnumerator DisplaySmoothHealthBar(int health)
    {
        while(_smoothHealthBar.value != health)
        {
            _smoothHealthBar.value = Mathf.MoveTowards(_smoothHealthBar.value, health, _smoothSpeed * Time.deltaTime);

            yield return _smoothBarUpdate;
        }
    }

    private void DisplayTextHealthBar(int health)
    {
        _textBar.text = health.ToString() + _textBarSeparator + _maxHealthValue;
    }
}