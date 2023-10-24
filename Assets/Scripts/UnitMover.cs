using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class UnitMover : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _base;

    private NavMeshAgent _navMeshAgent;
    private Vector3 _go;

    public bool _isGo { get; private set; } = false;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        Move(_go);
    }

    public void Init(Vector3 target)
    {
        _go = target;
        _isGo = true;
    }

    public void ChangeTarget()
    {
        _target = _base;
    }

    public void StayBase()
    {
        _isGo = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<FirstAid>(out FirstAid firstAid))
        {
            firstAid.transform.SetParent(transform);
            _go = _base.position;
        }
    }

    private void Move(Vector3 position)
    {
        _navMeshAgent.SetDestination(position);
    }
}
