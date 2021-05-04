using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        Destroy(other.transform.root.gameObject);
    }
}
