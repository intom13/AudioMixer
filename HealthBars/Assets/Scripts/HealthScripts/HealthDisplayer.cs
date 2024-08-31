using UnityEngine;

public class HealthDisplayer : MonoBehaviour
{
    [SerializeField] private Health _health;

    public virtual void DisplayHealth(int health) { }
    
    private void OnEnable()
    {
        _health.OnHealthChanged += DisplayHealth;
    }

    private void OnDisable()
    {
        _health.OnHealthChanged -= DisplayHealth;
    }
}