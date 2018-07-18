using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FireModal : MonoBehaviour {
	public ElementModal1 elementModal;
	public GameController gameController;
	public Text infoText; 
	// Use this for initialization
	void Start () {
		elementModal = GameObject.Find("ElementModal1").GetComponent<ElementModal1>();
		gameController = GameObject.Find("GameController").GetComponent<GameController>();
		infoText = GameObject.Find("Info").GetComponent<Text>(); 
		infoText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseDown(){
		if(elementModal.tilenum.tier == 1){
			if(gameController.fireScore >= 20){
				infoText.text = "Fire combined with " + elementModal.tilenum.type;
				elementModal.tilenum.setType("fire");
			} else {
				infoText.text = "Not enough of this resource...";
			}
		}
		elementModal.transform.position = new Vector3(1.42f, -14.5f, 1.42f);
	}
}
