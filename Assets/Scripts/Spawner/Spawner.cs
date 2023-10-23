using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private Transform _point;

    private Transform[] _points;
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(3f);

    private void Start()
    {
        Init();
        StartCoroutine(SpawnItem());
    }

    private IEnumerator SpawnItem()
    {
        while (true)
        {
            GameObject item = TryGetObject();
            item.SetActive(true);
            item.transform.position = _points[Random.Range(0, _points.Length)].position;
            yield return _waitForSeconds;
        }
    }

    private void Init()
    {
        _points = new Transform[_point.childCount];

        for (int i = 0; i < _points.Length; i++)
            _points[i] = _point.GetChild(i);
    }
}
