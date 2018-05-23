using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyHint : MonoBehaviour {

	public GameObject hint;

	// This is telling the text if the player steps inside it it will disapear
	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			hint.SetActive (false);
		}
	}
}
