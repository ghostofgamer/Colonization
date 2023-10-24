using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Scaner : MonoBehaviour
{
    [SerializeField] private Base _base;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out FirstAid firstAid))
        {
            _base.AddItem(firstAid);
        }
    }
}
