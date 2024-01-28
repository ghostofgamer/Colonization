using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private Score _score;
    [SerializeField] private List<UnitMover> _unitMovers;
    [SerializeField] private BasePriority _basePriority;

    private List<FirstAid> _firstAids = new List<FirstAid>();
    private GameObject _currentMarker;
    private int _priceBase = 5;

    public List<UnitMover> UnitMovers => _unitMovers;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out FirstAid firstAid))
        {
            firstAid.GetComponentInParent<UnitMover>().StayBase();
            firstAid.Collect();
            _score.AddScore();
        }
    }

    public void SetMarker(GameObject marker)
    {
        _currentMarker = marker;
    }

    public void AddUnit(Unit unit)
    {
        _unitMovers.Add(unit.GetComponent<UnitMover>());
    }

    public void DeleteUnit(Unit unit)
    {
        _unitMovers.Remove(unit.GetComponent<UnitMover>());
    }

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
        Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position, new Vector3(600f, 600f, 600f), Quaternion.identity);
        List<FirstAid> _aids = new List<FirstAid>();

        foreach (var hit in hitColliders)
        {
            if (hit.TryGetComponent(out FirstAid firstAid) && !firstAid.Reserved)
                _aids.Add(firstAid);
        }

        var unit = _unitMovers.FirstOrDefault(p => p._isGo == false);
        FirstAid aid = _aids.FirstOrDefault(p => p.GetComponent<FirstAid>());

        if (aid != null)
        {
            aid.Reservation();
            unit.Init(aid.gameObject.transform.position, aid.gameObject);
        }
    }

    public void GoUnitBildBase()
    {
        if (_score.ScoreAmount >= _priceBase && _basePriority.Priority > 0)
        {
            var unit = _unitMovers.FirstOrDefault(p => p._isGo == false);
            unit.GoBildBase(_currentMarker.transform.position);
            _currentMarker.GetComponent<Marker>().Init(unit.GetComponent<Unit>());
            DeleteUnit(unit.GetComponent<Unit>());
            _score.DecreaseScore(_priceBase);
        }
    }
}