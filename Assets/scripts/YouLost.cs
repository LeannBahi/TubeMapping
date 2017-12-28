using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouLost : MonoBehaviour {
	float rotateSpeed = 0.5f;
	int counter = -70;

	void Start () {
	}

	void Update () {	
		if (counter < 0) {
			transform.Rotate (-rotateSpeed, 0, 0);	
			counter++;
		} else if (counter < 20) {
			transform.Rotate (0, -rotateSpeed, 0);
			counter++;
		} else {
			if (counter > 50) {
				rotateSpeed = -rotateSpeed;
				counter = 0;
			}
			transform.Rotate (0, rotateSpeed, 0);	
			counter++;
		}
	}
}
