using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Pool
{
    [SerializeField] private Transform[] _enemyPrefabs;
    [SerializeField] private float _delay;
    [SerializeField] private Transform[] _points;
    [SerializeField] private int _maxCountInRaw;

    private WaitForSeconds _waitForSeconds;

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(_delay);

        Initialize(_enemyPrefabs);

        StartCoroutine(SpawnEnemiesRaw());
    }

    private IEnumerator SpawnEnemiesRaw()
    {
        while (true)
        {
            int count = Random.Range(0, _maxCountInRaw);
            List<Transform> points = new List<Transform>();

            foreach (var point in _points)
            {
                points.Add(point);
            }

            for (int i = 0; i <= count; i++)
            {
                TryGetEnemy(points);
            }

            yield return _waitForSeconds;
        }
    }

    private void TryGetEnemy(List<Transform> points)
    {
        if (TryGetObject(out Transform newEnemy))
        {
            int nextPoint = Random.Range(0, points.Count);
            ActivateEnemy(newEnemy, points[nextPoint]);
            points.RemoveAt(nextPoint);
        }
    }

    private void ActivateEnemy(Transform enemy, Transform point)
    {
        enemy.gameObject.SetActive(true);
        enemy.position = point.position;
    }
}
