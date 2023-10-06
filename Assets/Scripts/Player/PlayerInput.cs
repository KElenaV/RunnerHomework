using UnityEngine;

[RequireComponent(typeof(PlayerAction))]
public class PlayerInput : MonoBehaviour
{
    private PlayerAction _mover;
    private PlayerJumper _jumper;

    private void Awake()
    {
        _mover = GetComponent<PlayerAction>();
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
