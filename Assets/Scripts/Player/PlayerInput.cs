using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMover _mover;

    private void Awake()
    {
        _mover = GetComponent<PlayerMover>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) 
            _mover.TryJumpUp();

        if (Input.GetKeyDown(KeyCode.S))
            _mover.TryJumpDown();

        if (Input.GetKey(KeyCode.A))
            _mover.MoveLeft();

        if (Input.GetKey(KeyCode.D))
            _mover.MoveRight();

    }
}
