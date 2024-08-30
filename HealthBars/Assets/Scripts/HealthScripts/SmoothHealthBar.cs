using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothHealthBar : HealthDisplayer
{
    [SerializeField] private Slider _bar;
    [SerializeField] private float _smoothSpeed;

    private WaitForSeconds _smoothBarUpdate = new WaitForSeconds(0.01f);

    public override void DisplayHealth(int health)
    {
        StartCoroutine(DisplaySmoothHealthBar(health));
    }

    private IEnumerator DisplaySmoothHealthBar(int health)
    {
        while (_bar.value != health)
        {
            _bar.value = Mathf.MoveTowards(_bar.value, health, _smoothSpeed * Time.deltaTime);

            yield return _smoothBarUpdate;
        }
    }
}
