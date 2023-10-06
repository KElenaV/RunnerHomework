using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerJumper : MonoBehaviour
{
    [SerializeField] private float _jumpStep;
    [SerializeField] private float _maxPositionY;
    [SerializeField] private float _minPositionY;

    public event UnityAction Jumping;

    public void TryJumpUp()
    {
        TryJump(_jumpStep, _maxPositionY);
    }

    public void TryJumpDown()
    {
        TryJump(-_jumpStep, _minPositionY);
    }

    private void TryJump(float step, float extremum)
    {
        Vector3 currentPosition = transform.position;

        if (Mathf.Approximately(currentPosition.y, extremum) == false)
        {
            float newPosition = Mathf.Clamp(currentPosition.y + step, _minPositionY, _maxPositionY);
            currentPosition.y = newPosition;

            transform.position = currentPosition;

            Jumping?.Invoke();
        }
    }
}
