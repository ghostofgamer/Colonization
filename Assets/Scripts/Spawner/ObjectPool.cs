using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _container;

    private int _count = 15;

    protected List<GameObject> _pool;

    private void Awake()
    {
        Initialization();
    }

    protected void Initialization()
    {
        _pool = new List<GameObject>();

        for (int i = 0; i < _count; i++)
        {
            GameObject item = Instantiate(_prefab, _container);
            item.SetActive(false);
            _pool.Add(item);
        }
    }

    protected GameObject TryGetObject()
    {
        var filterItem = _pool.First(p => p.activeSelf==false);
        return filterItem;
    }
}