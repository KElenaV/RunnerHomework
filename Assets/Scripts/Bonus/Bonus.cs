using System.Collections;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    private float _lifeTime = 8;
    private WaitForSeconds _waitForSeconds;

    private void Awake()
    {
        _waitForSeconds = new WaitForSeconds(_lifeTime);
    }

    private void OnEnable()
    {
        StartCoroutine(Deactivate());
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            if (player.TryAddLife())
                gameObject.SetActive(false);
        }
    }

    private IEnumerator Deactivate()
    {
        yield return _waitForSeconds;
        gameObject.SetActive(false);
    }
}
