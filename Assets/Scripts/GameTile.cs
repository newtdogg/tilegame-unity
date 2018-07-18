using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTile : MonoBehaviour {

	
	public Tile tile;
	Material tileColour;
	Color color;
	public ElementModal1 elementModal;
	public int fireScore;
	public int earthScore;
	public int waterScore;
	public int airScore;
	public int xPosition;
	public int yPosition;
	public string xyCoords;

	public GameObject nwTile;
	public GameObject neTile;
	public GameObject swTile;
	public GameObject seTile;
	
	public void initialize () {
		tile = new Tile();
		elementModal = GameObject.Find("ElementModal1").GetComponent<ElementModal1>();
	}

	public void setColour(){
		tileColour = GetComponent<Renderer>().material;
		color = tile.generateType();
		tileColour.SetColor("_Color", color);
	}

	public void updateScore(){
		tile.generatePoints();
		fireScore = tile.fireScore;
		earthScore = tile.earthScore;
		waterScore = tile.waterScore;
		airScore = tile.airScore;
	}

	void OnMouseDown(){
		elementModal.transform.position = new Vector3(1.42f, 4.5f, 1.42f);
		elementModal.selection(tile);
	}
}
