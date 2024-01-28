using UnityEngine;

public class BuyBot : MonoBehaviour
{
    [SerializeField] private Score _score;
    [SerializeField] private Unit _unit;
    [SerializeField] private Transform _startPosition;
    [SerializeField] private Base _base;

    private int _priceBot = 3;
    private float _spawnRadius = 5f;

    public void Buy()
    {
        if (_score.ScoreAmount < _priceBot)
            return;

        Vector3 spawnPosition = _startPosition.position + (Vector3.forward * _spawnRadius);
        var unit = Instantiate(_unit, spawnPosition, Quaternion.identity);
        unit.GetComponent<UnitMover>().Init(_startPosition);
        _base.AddUnit(unit);
    }
}