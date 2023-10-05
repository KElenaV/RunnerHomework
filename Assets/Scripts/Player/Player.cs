using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    public float TimeToDie { get; } = 1f;

    public event UnityAction<int> HealthChanged;
    public event UnityAction Died;
    public event UnityAction Dying;

    private int _health;

    private void Start()
    {
        _health = _maxHealth;
        HealthChanged?.Invoke(_health);
    }

    public void TakeDamage(int damage)
    {
        _health = Mathf.Clamp(_health - damage, 0, _maxHealth);
        HealthChanged?.Invoke(_health);

        if (_health == 0)
        {
            StartCoroutine(Die());
        }
    }

    private IEnumerator Die()
    {
        Dying?.Invoke();
        yield return new WaitForSeconds(TimeToDie);
        Died?.Invoke();
    }
}
