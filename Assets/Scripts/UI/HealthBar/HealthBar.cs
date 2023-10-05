using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Life _liveIcon;

    private List<Life> _lives = new List<Life>();

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int health)
    {
        int difference = health - _lives.Count;

        if(difference > 0)
        {
            for (int i = 0; i < difference; i++)
            {
                AddLive();
            }
        }
        else if(difference < 0)
        {
            for (int i = 0; i > difference; i--)
            {
                DeleteLive(_lives[_lives.Count - 1]);
            }
        }
    }

    private void AddLive()
    {
        Life newLife = Instantiate(_liveIcon, transform);
        newLife.Init(_player.TimeToDie);
        newLife.Fill();
        _lives.Add(newLife);
    }

    private void DeleteLive(Life life)
    {
        _lives.Remove(life);
        life.Empty();
    }
}
