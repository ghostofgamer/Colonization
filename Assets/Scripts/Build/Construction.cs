using UnityEngine;

public class Construction : MonoBehaviour
{
    [SerializeField] private GameObject _marker;
    [SerializeField] private GameObject _basePrefab;
    [SerializeField] private BasePriority _basePriority;
    [SerializeField] private Base _base;

    private GameObject _currentMarker;
    private bool _canPlaceMarker = false;
    private int _setMarker = 1;
    private int _bildBase = 0;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.GetComponent<Base>())
                    _canPlaceMarker = true;

                if (_currentMarker != null)
                    Destroy(_currentMarker);

                if (_canPlaceMarker && hit.transform.gameObject.GetComponent<Floor>())
                    SetMarker(hit);
            }
        }
    }

    public void BildBase(Unit unit)
    {
        var newBase = Instantiate(_basePrefab, _currentMarker.transform.position, Quaternion.identity);
        Destroy(_currentMarker);
        _currentMarker = null;
        _basePriority.SetMarker(_bildBase);
        newBase.GetComponent<Base>().AddUnit(unit);
    }

    private void SetMarker(RaycastHit hit)
    {
        _currentMarker = Instantiate(_marker, hit.point, Quaternion.identity);
        _base.SetMarker(_currentMarker);
        _basePriority.SetMarker(_setMarker);
        _currentMarker.GetComponent<Marker>().SetConstruction(transform.GetComponent<Construction>());
    }
}