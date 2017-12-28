using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour {

	public GameObject myParent;
	public int color;

	public List<Color> colorLst;
	public List<Vector3> deltas;
	public Transform line;


	// Use this for initialization
	void Start () {
		colorLst = new List<Color>();
		deltas = new List<Vector3>();

		color = myParent.GetComponent<Stations> ().color;
		GetComponent<CircleCollider2D> ().enabled = false;

		colorLst.Add (Color.red);
		colorLst.Add (Color.green);
		colorLst.Add (Color.blue);
		colorLst.Add (Color.cyan);

		deltas.Add (new Vector3 (-0.15f,-0.15f,3f));
		deltas.Add (new Vector3 (-0.05f,-0.05f,3f));
		deltas.Add (new Vector3 (0.05f,0.05f,3f));
		deltas.Add (new Vector3 (0.15f,0.15f,3f));
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
	}

	void drawLine(Vector3 start, Vector3 end, Color color){
		LineRenderer lr = (Instantiate(line, start, Quaternion.identity)).GetComponent<LineRenderer>();
		lr.SetColors(color, color);
		lr.SetWidth(0.1f, 0.1f);
		lr.SetPosition(0, start);
		lr.SetPosition(1, end);
	}


	void OnTriggerEnter2D (Collider2D other) {
		Vector3 delta = deltas[color];
		if (other.tag == "stationCol" && color == other.GetComponent<ColliderScript>().color){
			drawLine (gameObject.transform.position+delta, other.transform.position+delta, colorLst [color]);
			myParent.GetComponent<Stations>().connected = true;
			other.GetComponent<ColliderScript>().myParent.GetComponent<Stations>().connected = true;
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (!myParent.GetComponent<Stations>().placed) {
			myParent.GetComponent<Stations>().connected = false;
		}
	}

}
