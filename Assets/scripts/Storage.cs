using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour {

	public Transform station;

	public GameObject spot0;
	public GameObject spot1;
	public GameObject spot2;
	public GameObject spot3;
	public GameObject spot4;
	public GameObject spot5;
	public GameObject spot6;

	public List<GameObject> spotLst;
	public List<Transform> stationStorage;

	//create new station in spot i 
	Transform createNewStation(int i) {
		return 
			(Transform)Instantiate(station, (spotLst[i]).transform.position, Quaternion.identity);
	}

	// Use this for initialization
	void Start () {
		spotLst = new List<GameObject> ();
		stationStorage = new List<Transform> ();

		spotLst.Add (spot0);
		spotLst.Add (spot1);
		spotLst.Add (spot2);
		spotLst.Add (spot3);
		spotLst.Add (spot4);
		spotLst.Add (spot5);
		spotLst.Add (spot6);


		for (int i = 0; i <7;i++) {
			Transform station = createNewStation (i);
			stationStorage.Add(station);
		}
	}
	

	// Update is called once per frame
	void FixedUpdate () {
		for (int i = 6; i >= 0; i--) {
			
			if (stationStorage [i] != null) {
				if ((stationStorage [i]).transform.position.y > -1.3 
					&& (stationStorage [i]).GetComponent<Stations>().placed ) {
					// if station no longer in spot -> mark station as empty
					stationStorage [i] = null;
				}
			} else {
				// station is empty -> shift right
				if (i == 0) {
					// spawn new station
					Transform station = createNewStation(0);
					stationStorage [0] = station;
				} else {
					stationStorage [i] = stationStorage [i - 1];
					stationStorage [i - 1] = null;
					if (stationStorage [i] != null) {
						(stationStorage [i]).transform.position = (spotLst [i]).transform.position;
					}
				}
			} 
		}
	}
}