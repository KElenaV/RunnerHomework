using System.Collections;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    [SerializeField] private float _minXPosition;
    [SerializeField] private float _maxXPosition;
    [SerializeField] private float _delay;
    
    private Bonus[] _bonuses;

    private WaitForSeconds _waitForSeconds;

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(_delay);

        Initialize();

        StartCoroutine(TrySpawn());
    }

    private void Initialize()
    {
        _bonuses = GetComponentsInChildren<Bonus>();

        foreach (Bonus bonus in _bonuses)
        {
            bonus.gameObject.SetActive(false);
        }
    }

    private IEnumerator TrySpawn()
    {
        while (true)
        {
            GameObject bonus = _bonuses[Random.Range(0, _bonuses.Length)].gameObject;

            if(bonus != null && bonus.activeSelf == false)
            {
                Activate(bonus);

                yield return _waitForSeconds;
            }

            yield return null;
        }
    }

    private void Activate(GameObject bonus)
    {
        Vector2 spawnPosition = new Vector2(Random.Range(_minXPosition, _maxXPosition), transform.position.y);
        bonus.transform.position = spawnPosition;
        bonus.SetActive(true);
    }
}
