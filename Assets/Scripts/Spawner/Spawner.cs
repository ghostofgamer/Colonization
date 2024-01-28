using System.Collections;
using System.Linq;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private Transform _point;
    [SerializeField] private Position[] _positions;

    private Transform[] _points;
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);

    private void Start()
    {
        Init();
        StartCoroutine(SpawnItem());
    }

    private IEnumerator SpawnItem()
    {
        while (true)
        {
            Position position = GetPosition();

            if (position != null)
            {
                GameObject item = TryGetObject();
                item.SetActive(true);
                item.transform.position = position.gameObject.transform.position;
            }

            yield return _waitForSeconds;
        }
    }

    private void Init()
    {
        _points = new Transform[_point.childCount];

        for (int i = 0; i < _points.Length; i++)
            _points[i] = _point.GetChild(i);
    }

    private Position GetPosition()
    {
        var filter = _positions.FirstOrDefault(p => !p.GetComponent<Position>().IsStay);

        if (filter == null)
            return null;

        return filter;
    }
}