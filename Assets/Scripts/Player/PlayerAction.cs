using UnityEngine;
using UnityEngine.Events;

public class PlayerAction : MonoBehaviour
{
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private float _jumpStep;
    [SerializeField] private float _maxPositionY;
    [SerializeField] private float _minPositionY;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _maxPositionX;
    [SerializeField] private float _minPositionX;

    private Vector3 _targetPosition;
    private float _rightDirection = 1;
    private float _leftDirection = -1;

    public event UnityAction Jumping;

    private void Start()
    {
        _targetPosition = transform.position;
    }

    private void Update()
    {
        if (transform.position != _targetPosition)
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
    }

    public void TryJumpUp()
    {
        TryJump(_jumpStep, _maxPositionY);
    }

    public void TryJumpDown()
    {
        TryJump(-_jumpStep, _minPositionY);
    }

    public void MoveRight()
    {
        Move(_rightDirection);
    }

    public void MoveLeft()
    {
        Move(_leftDirection);
    }

    private void TryJump(float step, float extremum)
    {
        if (Mathf.Approximately(_targetPosition.y, extremum) == false)
        {
            _targetPosition = new Vector3(transform.position.x, _targetPosition.y + step);
            Jumping?.Invoke();
        }
    }

    private void Move(float direction)
    {
        float positionX = Mathf.Clamp(transform.position.x + direction * _moveSpeed * Time.deltaTime, _minPositionX, _maxPositionX);
        _targetPosition = new Vector3(positionX, _targetPosition.y);
    }
}
