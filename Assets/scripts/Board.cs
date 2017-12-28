using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour {

	public int level = 0;
	//public int score;
	public List<int> numStations;
	public List<int> reqNum;
	public List<GameObject> onBoard;

	//public Text displayScore;
	public Text displayTimer;
	public Text displayRed;
	public Text displayGreen;
	public Text displayBlue;
	public Text displayCyan;

	// Use this for initialization
	void Start () {
		//score = 0;
		numStations = new List<int> ();
		numStations.Add (0);
		numStations.Add (0);
		numStations.Add (0);
		numStations.Add (0);

		reqNum = new List<int> ();
		int range = 9;
		reqNum.Add (Random.Range(1,range+(level*2)));
		reqNum.Add (Random.Range(1,range+(level*2)));
		reqNum.Add (Random.Range(1,range+(level*2)));
		reqNum.Add (Random.Range(1,range+(level*2)));

	}

	int numConn(int i) {
		int res = 0;
		foreach (GameObject station in onBoard) {
			if (station.GetComponent<Stations> ().color == i && 
				station.GetComponent<Stations>().connected) {
				res++;
			}
		}
		return res;
	}

	int numNot(int i) {
		int res = 0;
		foreach (GameObject station in onBoard) {
			if (station.GetComponent<Stations> ().color == i &&
				!(station.GetComponent<Stations>().connected )) {
				res++;
			}
		}
		return res;
	}

	bool check(int i) {
		return (numConn(i) == reqNum [i]);
	}

	void Update () {
		if (check (0) && check (1) && check (2) && check (3)) {
			level++;
			//displayScore.text = "Score : " + score.ToString();
			Application.LoadLevel ("win");
		}

		for (int i = 0; i < 4; i++) {
			int num = numConn (i);
			if (num == 0 && numNot (i) > 0) {
				num = 1;
			}
			numStations [i] = num;
		}

		//display timer
		int timeAllowed = 60;
		int timePassed = (int)Time.timeSinceLevelLoad;
		displayTimer.text = (timeAllowed - timePassed).ToString();

		if (timeAllowed - timePassed < 0) {
			//displayScore.text = "Score : " + score.ToString();
			Application.LoadLevel ("lost");
		}

		//display text
		//displayScore.text = score.ToString();
		displayRed.text = (numStations [0]).ToString () + "/" + (reqNum [0]).ToString ();
		displayGreen.text = (numStations [1]).ToString () + "/" + (reqNum [1]).ToString ();
		displayBlue.text = (numStations [2]).ToString () + "/" + (reqNum [2]).ToString ();
		displayCyan.text = (numStations [3]).ToString () + "/" + (reqNum [3]).ToString ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "station") {
			onBoard.Add ((GameObject)other.gameObject);
		}
	}
}
