using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField] private GameObject destructible;

    void OnMouseDown() {
        Instantiate(destructible, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }
}
