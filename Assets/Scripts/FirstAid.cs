using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid : MonoBehaviour
{
    public void Collect()
    {     
        transform.parent = null;
        gameObject.SetActive(false);
    }
}
