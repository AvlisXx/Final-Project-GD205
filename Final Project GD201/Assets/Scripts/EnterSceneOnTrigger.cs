using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterSceneOnTrigger : MonoBehaviour {

    public GameObject guiObject;
    public string levelToLoad;

	// Use this for initialization
	void Start () {
        guiObject.SetActive(false);
	}

	// Update is called once per frame
	void OnTriggerStay(Collider other)
	{
        if (other.gameObject.tag == "Player")
        {
            guiObject.SetActive(true);
            if (guiObject.activeInHierarchy == true && Input.GetButtonDown("Use"))
            {
                Application.LoadLevel(levelToLoad);
            }

        }
	}

	void OnTriggerExit(Collider other)
	{
        guiObject.SetActive(false);
	}
}
