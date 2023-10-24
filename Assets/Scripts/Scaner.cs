using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Scaner : MonoBehaviour
{
    private List<FirstAid> _firstAids = new List<FirstAid>();

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out FirstAid firstAid))
        {
            _firstAids.Add(firstAid);
        }
    }
}
