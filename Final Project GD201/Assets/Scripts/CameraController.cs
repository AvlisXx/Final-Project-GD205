using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform target;
	public Vector3 offset;
	public bool useOffsetValues;
	public float rotateSpeed;
	public Transform pivot;
	public float maxView;
	public float minView;

	// Use this for initialization
	void Start () {

		if (!useOffsetValues) {
			offset = target.position - transform.position;
		}

		pivot.transform.position = target.transform.position;
		//pivot.transform.parent = target.transform;
		pivot.transform.parent = null;

		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {

		//move the camera based on the current  rotation of the target and the original offset
		float desiredYAngle = pivot.eulerAngles.y;
		float desiredXAngle = pivot.eulerAngles.x;

		pivot.transform.position = target.transform.position;

		//get the X and Y position of the mouse and use it to rotate the camera

		float horizontal = Input.GetAxis ("Mouse X") * rotateSpeed;
		pivot.Rotate (0, horizontal, 0);

		//get the Y position of the mouse and rotate the pivot
		float vertical = Input.GetAxis ("Mouse Y") * rotateSpeed;
		pivot.Rotate (-vertical, 0, 0);

		//Limit the up/down camera rotation
		if (pivot.rotation.eulerAngles.x > maxView && pivot.rotation.eulerAngles.x < 180f) {
			pivot.rotation = Quaternion.Euler (maxView, desiredYAngle, 0);
		}

		if (pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < 360f + minView) {
			pivot.rotation = Quaternion.Euler (360f + minView, desiredYAngle, 0);
		}

		Quaternion rotation = Quaternion.Euler (desiredXAngle, desiredYAngle, 0);
		transform.position = target.position - (rotation * offset); 

		//transform.position = target.position - offset;

		if (transform.position.y < target.position.y) {

			transform.position = new Vector3 (transform.position.x, target.position.y - .5f, transform.position.z);
		}
		transform.LookAt (target);
	}
}
