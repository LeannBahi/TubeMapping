using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class winSplash : MonoBehaviour {

	int rotateSpeed = 2;
	int counter = 0;

	void Start () {
	}

	void Update () {	
		if (counter > 30) {
			rotateSpeed = -rotateSpeed;
			counter = 0;
		}
		transform.Rotate (0, rotateSpeed, 0);	
		counter++;
	}
}
