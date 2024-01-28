using UnityEngine;

public class FirstAid : MonoBehaviour
{
    public bool Reserved { get; private set; } = false;

    private void OnEnable()
    {
        Reserved = false;
        transform.parent = null;
    }

    public void Collect()
    {
        gameObject.SetActive(false);
    }

    public void Reservation()
    {
        Reserved = true;
    }
}