using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour {
    public float timeBetweenPitches;
    public GameObject ball;
    public float launchAngle;

    void Start () {
        StartCoroutine(Pitch());
	}
	
	private IEnumerator Pitch() {
        while (true) {
            yield return new WaitForSeconds(timeBetweenPitches);
            Vector3 launchDirection = GetLaunchDirection();
            Quaternion q = Quaternion.Euler(launchDirection);

            Instantiate(ball, transform.position, q);
        }
    }

    private Vector3 GetLaunchDirection() {
        return new Vector3(
            Random.Range(-launchAngle, launchAngle), 180, Random.Range(0f, 180f));
    }
}
