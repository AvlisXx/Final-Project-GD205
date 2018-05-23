using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	public GameObject guiObject;
	public Animator ragdoll;

	// Use this for initialization
	void Start () {
		guiObject.SetActive(false);
		ragdoll = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void OnTriggerStay(Collider other)
	{
		//this will turn off the animator for the guard making him ragdoll/dead.
		if (other.gameObject.tag == "Player")
		{
			guiObject.SetActive(true);
			if (guiObject.activeInHierarchy == true && Input.GetButtonDown("Use"))
			{
				ragdoll.enabled = false;
				other.GetComponent<PlayerMovement> ().hasKey++;
			}

		}
	}

	void OnTriggerExit(Collider other)
	{
		guiObject.SetActive(false);
	}
}
