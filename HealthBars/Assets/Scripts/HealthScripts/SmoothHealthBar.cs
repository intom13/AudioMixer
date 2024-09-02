using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothHealthBar : HealthDisplayer
{
    [SerializeField] private Slider _bar;
    [SerializeField] private float _smoothSpeed;

    private Coroutine _smoothDisplaying;

    protected override void DisplayHealth(float health)
    {
        if(_smoothDisplaying != null)
            StopCoroutine(_smoothDisplaying);
        
        _smoothDisplaying = StartCoroutine(DisplaySmoothHealthBar(health));
    }

    private IEnumerator DisplaySmoothHealthBar(float health)
    {
        while (!Mathf.Approximately(_bar.value, health / _health.MaxValue))
        {
            _bar.value = Mathf.MoveTowards(_bar.value, health / _health.MaxValue, _smoothSpeed * Time.deltaTime);

            yield return null;
        }
    }
}
