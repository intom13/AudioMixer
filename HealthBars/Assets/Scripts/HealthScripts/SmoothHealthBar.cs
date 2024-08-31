using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothHealthBar : HealthDisplayer
{
    [SerializeField] private Slider _bar;
    [SerializeField] private float _smoothSpeed;

    private Coroutine _smoothDisplaying;

    public override void DisplayHealth(int health)
    {
        if(_smoothDisplaying != null)
            StopCoroutine(_smoothDisplaying);
        
        _smoothDisplaying = StartCoroutine(DisplaySmoothHealthBar(health));
    }

    private IEnumerator DisplaySmoothHealthBar(int health)
    {
        while (_bar.value != health)
        {
            _bar.value = Mathf.MoveTowards(_bar.value, health, _smoothSpeed * Time.deltaTime);

            yield return null;
        }
    }
}
