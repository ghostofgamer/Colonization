using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private Score _score;
    [SerializeField] private Scaner _scaner;
    [SerializeField] private UnitMover[] _unitMovers;

    public UnitMover[] UnitMovers => _unitMovers;

    public void InitUnit()
    {
        if (_scaner.TryGetItem(out FirstAid firstAid))
            _unitMovers[0].Init(firstAid.gameObject.transform.position);
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
