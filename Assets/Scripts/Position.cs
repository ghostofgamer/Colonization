using UnityEngine;

public class Position : MonoBehaviour
{
    public bool IsStay { get; private set; } = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out FirstAid firstAid))
            IsStay = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out FirstAid firstAid))
            IsStay = false;
    }
}