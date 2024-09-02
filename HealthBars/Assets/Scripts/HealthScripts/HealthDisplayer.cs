using UnityEngine;

public class HealthDisplayer : MonoBehaviour
{
    [SerializeField] protected Health _health;

    private void OnEnable()
    {
        _health.OnHealthChanged += DisplayHealth;
    }

    private void OnDisable()
    {
        _health.OnHealthChanged -= DisplayHealth;
    }

    protected virtual void DisplayHealth(float health) { }
}