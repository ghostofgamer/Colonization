using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class UnitMover : MonoBehaviour
{
    [SerializeField] private Transform _base;
    [SerializeField] private GameObject _resource;

    private NavMeshAgent _navMeshAgent;
    private Vector3 _bildPosition;
    private bool _goBild = false;
    private float _minDistance = 3f;

    public bool _isGo { get; private set; } = false;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (_resource != null)
        {
            if (Vector3.Distance(transform.position, _resource.transform.position) < _minDistance)
            {
                _resource.transform.SetParent(transform);
                _navMeshAgent.destination = _base.position;
            }
        }
        else
        {
            _isGo = false;
        }

        if (_goBild)
        {
            _navMeshAgent.destination = _bildPosition;
        }
    }

    public void Init(Vector3 target, GameObject resource)
    {
        _resource = resource;
        _navMeshAgent.destination = target;
        _isGo = true;
    }

    public void Init(Transform target)
    {
        _base = target;
    }

    public void StayBase()
    {
        _isGo = false;
    }

    public void GoBildBase(Vector3 target)
    {
        _bildPosition = target;
        _goBild = true;
    }
}