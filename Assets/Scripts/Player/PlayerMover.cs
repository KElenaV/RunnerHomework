using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpStep;
    [SerializeField] private float _maxPosition;
    [SerializeField] private float _minPosition;

    private Vector3 _targetPosition;

    private void Start()
    {
        _targetPosition = transform.position;
    }

    private void Update()
    {
        if (transform.position != _targetPosition)
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
    }

    public void TryMoveUp()
    {
        if (!Mathf.Approximately(_targetPosition.y, _maxPosition))
            SetPosition(_jumpStep);
    }

    public void TryMoveDown()
    {
        if (!Mathf.Approximately(_targetPosition.y, _minPosition))
            SetPosition(-_jumpStep);
    }

    private void SetPosition(float step)
    {
        _targetPosition = new Vector3(transform.position.x, _targetPosition.y + step);
    }
}
