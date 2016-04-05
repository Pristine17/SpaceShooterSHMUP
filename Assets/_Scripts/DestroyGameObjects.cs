using UnityEngine;
using System.Collections;

public class DestroyGameObjects : MonoBehaviour {

    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
