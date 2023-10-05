using System.Collections;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    [SerializeField] private float _minXPosition;
    [SerializeField] private float _maxXPosition;
    [SerializeField] private float _delay;
    [SerializeField] private Bonus _template;

    private WaitForSeconds _waitForSeconds;

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(_delay);
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            Vector2 spawnPosition = new Vector2(Random.Range(_minXPosition, _maxXPosition), transform.position.y);
            Bonus bonus = Instantiate(_template, spawnPosition, Quaternion.identity, transform);
            yield return _waitForSeconds;
        }
    }
}
