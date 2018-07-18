using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirModal : MonoBehaviour {

	public ElementModal1 elementModal;
	// Use this for initialization
	void Start () {
		elementModal = GameObject.Find("ElementModal1").GetComponent<ElementModal1>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseDown(){
		elementModal.tilenum.setType("air");
		elementModal.transform.position = new Vector3(1.42f, -14.5f, 1.42f);
	}
}
