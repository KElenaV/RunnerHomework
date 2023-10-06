using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioEffects : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private AudioClip _bonus;
    [SerializeField] private AudioClip _collision;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int health, LifeChange action)
    {
        switch (action)
        {
            case LifeChange.Add:
                _audioSource.PlayOneShot(_bonus);
                break;
            case LifeChange.Remove:
                _audioSource.PlayOneShot(_collision);
                break;
            default:
                break;
        }
    }
}

