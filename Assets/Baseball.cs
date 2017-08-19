using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baseball : MonoBehaviour {
    public AudioSource src;
    public TrailRenderer t;

    private Rigidbody rb;
    private float velocityMax = 200f;

	void Awake () {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * Random.Range(4f, 6f), ForceMode.Impulse);
	}

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.name == "Bat") {
            rb.velocity = Vector3.zero;
            src.Play();
            Physics.IgnoreCollision(collision.gameObject.GetComponent<CapsuleCollider>(), gameObject.GetComponent<SphereCollider>());

            float forceMultiplier = GetBatForce(collision.gameObject.GetComponent<Rigidbody>());
            Vector3 direction = (transform.position - collision.contacts[0].point).normalized;
            rb.AddForce(direction * forceMultiplier, ForceMode.Impulse);
            rb.useGravity = true;

            t.enabled = true;
            Destroy(gameObject, 2f);
        }
    }

    private float GetBatForce(Rigidbody batRB) {
        return batRB.velocity.magnitude / velocityMax * 30f;
    }
}
