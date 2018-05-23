using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLabs : MonoBehaviour {

	public GameObject guiObject;
	public GameObject guiWarning;
	public string levelToLoad;

	// Use this for initialization
	void Start () {
		guiObject.SetActive(false);
		guiWarning.SetActive (false);
	}

	// this script says that if the player is within the box collider it will display a gui message telling the player
	//to enter the scene by pressing E if and only if the player has the key for the door. If they do not they will see a 
	//message saying to find the key before being able to enter. this script will be refernced by the playerScript for
	//the collectibles.

	void OnTriggerStay(Collider other)
	{

		//this script says that if the player is in the box colider of the door that if they collected all the rats they can leave the area if and only if all rats are collected
		if (other.gameObject.tag == "Player") {
			guiObject.SetActive (true);
			if (guiObject.activeInHierarchy == true && Input.GetButtonDown ("Use") && other.GetComponent<PlayerMovement> ().ratsRemaining == 0) {
				Application.LoadLevel (levelToLoad);
			}

			if (guiObject.activeInHierarchy == true && Input.GetButtonDown ("Use") &&other.GetComponent<PlayerMovement> ().ratsRemaining == 4) {
				guiWarning.SetActive (true);
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		guiObject.SetActive(false);
		guiWarning.SetActive (false);
	}
}
