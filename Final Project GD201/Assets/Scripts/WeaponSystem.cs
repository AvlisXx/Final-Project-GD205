using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour {

	public GameObject prefab;
	// Use this for initialization
	void Start () {
	}
	// Update is called once per frame
	void Update () {

		Ray beam = Camera.main.ScreenPointToRay (Input.mousePosition);

		Debug.DrawRay (beam.origin, beam.direction * 1000f);

		RaycastHit beamHit = new RaycastHit ();

			if (Input.GetMouseButtonDown (0)) {
				Instantiate(prefab,beamHit.point,Quaternion.identity);				
			}
			if (Input.GetMouseButtonDown (1)) {
				Destroy (beamHit.collider.gameObject);
			}
		}
	}
