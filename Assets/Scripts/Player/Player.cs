using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    public float TimeToDie { get; } = 0.6f;

    public event UnityAction<int, LifeChange> HealthChanged;
    public event UnityAction Died;
    public event UnityAction Dying;

    private int _health;

    private void Start()
    {
        _health = _maxHealth;
        HealthChanged?.Invoke(_health, LifeChange.None);
    }

    public void TakeDamage(int damage)
    {
        _health = Mathf.Clamp(_health - damage, 0, _maxHealth);
        HealthChanged?.Invoke(_health, LifeChange.Remove);

        if (_health == 0)
        {
            StartCoroutine(Die());
        }
    }

    public bool TryAddLife()
    {
        if (_health < _maxHealth)
        {
            _health++;
            HealthChanged?.Invoke(_health, LifeChange.Add);

            return true;
        }

        return false;
    }

    private IEnumerator Die()
    {
        Dying?.Invoke();
        yield return new WaitForSeconds(TimeToDie);
        Died?.Invoke();
    }
}
