using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerAction))]
public class PlayerAnimation : MonoBehaviour
{
    private Player _player;
    private Animator _animator;
    private PlayerAction _mover;

    private readonly int _isDying = Animator.StringToHash("IsDying");
    private readonly int _jump = Animator.StringToHash("Jump");

    private void Awake()
    {
        _player = GetComponent<Player>();
        _animator = GetComponent<Animator>();
        _mover = GetComponent<PlayerAction>();
    }

    private void OnEnable()
    {
        _player.Dying += OnDying;
        _mover.Jumping += OnJump;
    }

    private void OnDisable()
    {
        _player.Dying -= OnDying;
        _mover.Jumping -= OnJump;

    }

    private void OnDying()
    {
        _animator.SetTrigger(_isDying);
    }

    private void OnJump()
    {
        _animator.SetTrigger(_jump);
    }
}
