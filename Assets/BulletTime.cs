using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTime : MonoBehaviour {

	public void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "projectile") {
            Time.timeScale = 0.25f;
            StartCoroutine(GoToNormalTime());
            Physics.IgnoreCollision(other.gameObject.GetComponent<SphereCollider>(), gameObject.GetComponent<BoxCollider>());
        }
    }

    IEnumerator GoToNormalTime() {
        yield return new WaitForSecondsRealtime(2f);
        Time.timeScale = 1f;
    }
}
