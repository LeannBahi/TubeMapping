using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handheld.Vibrate
// reference : http://unity.grogansoft.com/drag-and-drop/


public class Stations : MonoBehaviour {

	public int color;

	public bool placed = false;
	public bool connected = false;
	public GameObject myChild;

	private bool draggingItem = false;
	private GameObject draggedObject = null;
	private Vector2 touchOffset;
	Vector2 inputPosition;


	Collider2D stationSquare;


	// Use this for initialization
	void Start () {
		color = Random.Range (0, 4);
		if (color == 0) {
			GetComponent<SpriteRenderer> ().color = Color.red;
		} else if (color == 1) {
			GetComponent<SpriteRenderer> ().color = Color.green;
		} else if (color == 2) {
			GetComponent<SpriteRenderer> ().color = Color.blue;
		} else if (color == 3) {
			GetComponent<SpriteRenderer> ().color = Color.cyan;
		}
		myChild.GetComponent<ColliderScript> ().color = color;
	}


	void FixedUpdate() {
		if (placed && connected) {
			GetComponent<SpriteRenderer> ().color = new Color (1f,1f,1f,0f);
		}
		if (placed) {
			myChild.GetComponent<CircleCollider2D> ().enabled = true;
		}
		if (Input.GetMouseButton(0)) {
			DragOrPickUp();
		} else {
			if (draggingItem) DropItem();
		}
	}


	private void DragOrPickUp() {
		inputPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			//CurrentTouchPosition;
		if (draggingItem) {
			float xPos = draggedObject.transform.position.x;
			float yPos = Camera.main.ScreenToWorldPoint (Input.mousePosition).y;
			if (yPos > 3.65f) {
				yPos = 3.65f;
			} else if (yPos < -0.18f) {
				yPos = -0.18f;
			}
			if (draggedObject.GetComponent<Stations> ().placed == false) {
				draggedObject.transform.position = new Vector3 (xPos, yPos, 0.0f);
			}
		} else {
			RaycastHit2D[] touches = Physics2D.RaycastAll(inputPosition, inputPosition, 0.5f);
			if (touches.Length > 0) {
				var hit = touches[0];
				if (hit.transform != null && hit.transform.gameObject.tag == "station") {
					draggingItem = true;
					draggedObject = hit.transform.gameObject;
					draggedObject.transform.localScale = new Vector3(1.2f,1.2f,1.2f);
				}
			}
		} 
	}

	void DropItem() {
		draggingItem = false;
		draggedObject.transform.localScale = new Vector3(1f,1f,1f);
	}

	void OnMouseUp() {
		if (draggedObject == gameObject) {
			myChild.GetComponent<CircleCollider2D> ().enabled = true;
			placed = true;
			float yPos = transform.position.y;
			if (yPos > 3.38f) {
				transform.position = 
					new Vector3 (transform.position.x, 3.7f, transform.position.z);
				placed = true;
			} else if (yPos > 2.73f) {
				transform.position = 
					new Vector3 (transform.position.x, 3.05f, transform.position.z);
				placed = true;
			} else if (yPos > 2.1f) {
				transform.position = 
					new Vector3 (transform.position.x, 2.41f, transform.position.z);
				placed = true;
			} else if (yPos > 1.45f) {
				transform.position = 
					new Vector3 (transform.position.x, 1.76f, transform.position.z);
				placed = true;
			} else if (yPos > 0.8f) {
				transform.position = 
					new Vector3 (transform.position.x, 1.11f, transform.position.z);
				placed = true;
			} else if (yPos > 0.14f) {
				transform.position = 
					new Vector3 (transform.position.x, 0.46f, transform.position.z);
				placed = true;
			} else {
				transform.position = 
					new Vector3 (transform.position.x, -0.18f, transform.position.z);
				placed = true;
			}
		}
	} 

	void OnTriggerStay2D (Collider2D other) {
		if (other.tag == "squa") {
			Vector3 pos = new Vector3 (transform.position.x, other.transform.position.y, transform.position.z);
			transform.position = pos;
		}
	} 
}
