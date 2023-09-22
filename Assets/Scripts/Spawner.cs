using System.Collections;
using UnityEngine;

public class Spawner : Pool
{
    [SerializeField] private Transform[] _enemyPrefabs;
    [SerializeField] private float _delay;
    [SerializeField] private Transform[] _points;

    private WaitForSeconds _waitForSeconds;

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(_delay);

        Initialize(_enemyPrefabs);

        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            int point = Random.Range(0, _points.Length);

            if(TryGetObject(out Transform newEnemy))
            {
                ActivateEnemy(newEnemy, _points[point]);
            }

            yield return _waitForSeconds;
        }
    }

    private void ActivateEnemy(Transform enemy, Transform point)
    {
        enemy.gameObject.SetActive(true);
        enemy.position = point.position;
    }
}
