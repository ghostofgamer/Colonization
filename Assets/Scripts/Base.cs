using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private Score _score;
    [SerializeField] private Scaner _scaner;
    [SerializeField] private UnitMover[] _unitMovers;

    public UnitMover[] UnitMovers => _unitMovers;

    private List<FirstAid> _firstAids = new List<FirstAid>();

    public void AddItem(FirstAid firstAid)
    {
        _firstAids.Add(firstAid);
    }

    public bool TryGetItem(out FirstAid firstAid)
    {
        firstAid = null;

        if (_firstAids.Count > 0)
        {
            var filter = _firstAids.First(p => p.gameObject.activeSelf == true);
            firstAid = filter;
            return true;
        }

        return false;
    }

    public void InitUnit()
    {
        if (TryGetItem(out FirstAid firstAid))
        {
            var unit = _unitMovers.First(p => p._isGo == false);
            unit.Init(firstAid.gameObject.transform.position);
            _firstAids.Remove(firstAid);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out FirstAid firstAid))
        {
            firstAid.GetComponentInParent<UnitMover>().StayBase();
            firstAid.Collect();
            _score.AddScore();
        }
    }
}
