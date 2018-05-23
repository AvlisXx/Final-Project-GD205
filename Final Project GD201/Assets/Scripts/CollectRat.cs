using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectRat : MonoBehaviour {

	public GameObject guiObject;
	public GameObject rat;
	public AudioSource source;
	public AudioClip ratSound;

	// Use this for initialization
	void Start () {
		guiObject.SetActive(false);
		source = GetComponent<AudioSource> ();

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
				other.GetComponent<PlayerMovement> ().ratsRemaining--;
				Destroy (rat);
				source.PlayOneShot (ratSound);
			}

		}
	}

	void OnTriggerExit(Collider other)
	{
		guiObject.SetActive(false);
	}
}
