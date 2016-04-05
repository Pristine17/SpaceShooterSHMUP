using UnityEngine;
using System.Collections;

public class RemoveAsteroidExplosionObjects : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
