using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private List<Transform> _pool = new List<Transform>();
    [SerializeField] private int _capacity;
    [SerializeField] private Transform _container;

    protected void Initialize(Transform[] prefabs) 
    {
        for (int i = 0; i < _capacity; i++)
        {
            int prefab = Random.Range(0, prefabs.Length);
            Transform pooled = Instantiate(prefabs[prefab], _container);
            pooled.gameObject.SetActive(false);

            _pool.Add(pooled);
        }
    }

    protected bool TryGetObject(out Transform result)
    {
        result = _pool.FirstOrDefault(p => p.gameObject.activeSelf == false);

        return result != null;
    }
}
