using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squares : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void FixedUpdate () {
	}

	void OnTriggerStay2D (Collider2D other) {
		if (other.tag == "station" && other.GetComponent<Stations>().placed) {
			float deltaX = Mathf.Abs (other.transform.position.x - gameObject.transform.position.x);
			float deltaY = Mathf.Abs (other.transform.position.y - gameObject.transform.position.y);
			if (deltaX < 0.3f && deltaY < 0.6f) {
				other.transform.position = gameObject.transform.position;
			}
		}
	}
}
	