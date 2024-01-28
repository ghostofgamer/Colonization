using UnityEngine;

public class Marker : MonoBehaviour
{
    [SerializeField] private Unit _unit;
    [SerializeField] private Construction _construction;

    private void Update()
    {
        if (_unit == null)
            return;

        if (Vector3.Distance(transform.position, _unit.transform.position) < 3)
        {
            BildBase();
            _unit = null;
        }
    }

    public void SetConstruction(Construction construction)
    {
        _construction = construction;
    }

    public void Init(Unit unit)
    {
        _unit = unit;
    }

    private void BildBase()
    {
        if (_unit != null)
            _construction.BildBase(_unit);
    }
}