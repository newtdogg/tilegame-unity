using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTile : MonoBehaviour {

	
	public Tile tile;
	public Material tileColour;
	public GameObject highlight;
	Color color;
	public ElementModal1 elementModal;
	public int fireScore;
	public int earthScore;
	public int waterScore;
	public int airScore;
	public int xPosition;
	public int yPosition;
	public string xyCoords;
	public bool selected = false;
	public bool active = false;

	public GameObject nwTile;
	public GameObject neTile;
	public GameObject swTile;
	public GameObject seTile;

	public GameTile comboGameTile;
	public GameTile selectedTile;
	public List<GameObject> allTiles;

	public List<GameObject> adjacentTiles = new List<GameObject>();

	public GameController GameController;

	
	public void initialize () {
		tile = new Tile();
		GameController = GameObject.Find("GameController").GetComponent<GameController>();
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

	public void selectTile(GameTile tile){
		selected=true;
		selectedTile = tile;
	}

	public void deactivateTile(List<GameObject> tiles, int i){
		highlight = tiles[i].transform.GetChild(0).gameObject;
		highlight.SetActive(false);
		tiles[i].GetComponent<GameTile>().selected=false;
	}

	public void cleanAllTiles(){
		for(int i = 0; i < allTiles.Count; i++){
			if(allTiles[i] == null){
				allTiles.RemoveAt(i);
			}
		}
		for(int i = 0; i < adjacentTiles.Count; i++){
			if(adjacentTiles[i] == null){
				adjacentTiles.RemoveAt(i);
			}
		}
	}

	public void OnMouseDown(){
		if(allTiles.Count != 0){
			cleanAllTiles();
			GameController.allTiles = allTiles;
			// print(GameController.allTiles.Count);
		}
		if(selected == false && active == false){
			
			for(int i = 0; i < allTiles.Count; i++){
				deactivateTile(allTiles, i);
			}
			for(int i = 0; i < adjacentTiles.Count; i++){
				if(adjacentTiles[i] != null){
					highlight = adjacentTiles[i].transform.GetChild(0).gameObject;
					highlight.SetActive(true);
					active = true;
					adjacentTiles[i].GetComponent<GameTile>().selectTile(this);
				}
			}
			active = true;
		} else if (selected == false && active == true) {
			for(int i = 0; i < adjacentTiles.Count; i++){
				if(adjacentTiles[i] != null){
					deactivateTile(adjacentTiles, i);
					active = false;
				}
			}
		} else {
			for(int i = 0; i < selectedTile.adjacentTiles.Count; i++){
				if(selectedTile.adjacentTiles[i] != null){
					highlight = selectedTile.adjacentTiles[i].transform.GetChild(0).gameObject;
					highlight.SetActive(false);
					selectedTile.adjacentTiles[i].GetComponent<GameTile>().selected = false; 
				}
		
			}
			if (nwTile != null){
				nwTile.GetComponent<GameTile>().seTile = null;
			}
			if (neTile != null){
				neTile.GetComponent<GameTile>().swTile = null;
			}
			if (swTile != null){
				swTile.GetComponent<GameTile>().neTile = null;
			}
			if (seTile != null){
				seTile.GetComponent<GameTile>().nwTile = null;
			}
			Destroy(this.gameObject);
		}
	}
}

			// comboGameTile = comboTile.GetComponent<GameTile>();
			// this.transform.position = new Vector3(-(comboGameTile.xPosition * 10.2f), 0.1f, -(comboGameTile.yPosition * 10.2f));
			// this.transform.position = new Vector3(-(comboTile.xPosition * 10.2f), 0f, -(comboTile.yPosition * 10.2f));