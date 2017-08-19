using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miss : MonoBehaviour {
    public AudioSource src;

    public void OnTriggerEnter(Collider other) {
        src.Play();
        Destroy(other.gameObject);
    }
}
