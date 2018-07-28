using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {


	public Text fireScoreText;
	public Text earthScoreText;
	public Text waterScoreText;
	public Text airScoreText;
	public Button endTurn;
	public int fireScore;
	public int earthScore;
	public int waterScore;
	public int airScore;
	public Color materialColour;

	public string tileIndexString;
	public int tileIndexInt;

	public GameObject newTile;
	public GameObject baseTile;
	public GameTile currentTile;
	Dictionary<string, GameObject> tilesIndexes = new Dictionary<string, GameObject>();
	public int rowSize;
	public string coords;
	public int nwCoords;
	public int neCoords;
	public int swCoords;
	public int seCoords;

	public List<GameObject> allTiles = new List<GameObject>();
	public int buildCounter;
	
	void Start () {
		fireScore = 5;
		earthScore = 5;
		waterScore = 5;
		airScore = 5;
		rowSize = 5;
		for(int x = 1; x < rowSize + 1; x++){
			for(int y = 1; y < rowSize + 1; y++){
				tileIndexString = $"{x}{y}";
				baseTile = GameObject.Find("BaseTile");
				newTile = Instantiate(baseTile);
				newTile.AddComponent<GameTile>();
				newTile.GetComponent<GameTile>().xPosition = x;
				newTile.GetComponent<GameTile>().yPosition = y;
				newTile.GetComponent<GameTile>().xyCoords = tileIndexString;
				newTile.GetComponent<GameTile>().initialize();
				newTile.GetComponent<GameTile>().allTiles = allTiles;
				newTile.transform.position = new Vector3(x * 10.2f, 0f, y * 10.2f);
				tilesIndexes.Add(tileIndexString, newTile);
				allTiles.Add(newTile);
			}
		}
		setAdjacentTiles();
		fireScoreText = GameObject.Find("FireScore").GetComponent<Text>(); 
		earthScoreText = GameObject.Find("EarthScore").GetComponent<Text>();
		waterScoreText = GameObject.Find("WaterScore").GetComponent<Text>();
		airScoreText = GameObject.Find("AirScore").GetComponent<Text>();
		endTurn = GameObject.Find("EndTurn").GetComponent<Button>();
		endTurn.onClick.AddListener(EndTurn);
		UpdateAllTiles();
		scoreUpdateUI();
	}

	void EndTurn(){
		// if (tile1script.tile.buildCounter > 1) {
		// 	tile1script.tile.buildCounter -= 1;
		// } else {
		// 	tile1script.tile.type = tile1script.tile.queuedType;
		// }
		UpdateAllTiles();
		updateTileScores();
		scoreUpdateUI();
	}

	void UpdateAllTiles(){
		for(int x = 0; x < allTiles.Count; x++){
			allTiles[x].GetComponent<GameTile>().setColour();
			allTiles[x].GetComponent<GameTile>().updateScore();
		}
	}

	public void setAdjacentTiles(){
		for(int x = 0; x < allTiles.Count; x++){
			currentTile = allTiles[x].GetComponent<GameTile>();
			coords = currentTile.xyCoords;
			nwCoords = int.Parse(coords) + 1;
			if (tilesIndexes.ContainsKey($"{nwCoords}")) {
				currentTile.nwTile = tilesIndexes[$"{nwCoords}"];
				currentTile.adjacentTiles.Add(currentTile.nwTile);
			}
			neCoords = int.Parse(coords) + 10;
			if (tilesIndexes.ContainsKey($"{neCoords}")) {
				currentTile.neTile = tilesIndexes[$"{neCoords}"];
				currentTile.adjacentTiles.Add(currentTile.neTile);
			}
			seCoords = int.Parse(coords) - 1;
			if (tilesIndexes.ContainsKey($"{seCoords}")) {
				currentTile.seTile = tilesIndexes[$"{seCoords}"];
				currentTile.adjacentTiles.Add(currentTile.seTile);
			}
			swCoords = int.Parse(coords) - 10;
			if (tilesIndexes.ContainsKey($"{swCoords}")) {
				currentTile.swTile = tilesIndexes[$"{swCoords}"];
				currentTile.adjacentTiles.Add(currentTile.swTile);
			}
		}
	}
	
	void updateTileScores () {
		for(int x = 0; x < allTiles.Count; x++){
			fireScore += allTiles[x].GetComponent<GameTile>().fireScore;
			waterScore += allTiles[x].GetComponent<GameTile>().waterScore;
			airScore += allTiles[x].GetComponent<GameTile>().airScore;
			earthScore += allTiles[x].GetComponent<GameTile>().earthScore;
		}
	}

	// Update is called once per frame
	void scoreUpdateUI () {
		fireScoreText.text = "Fire: " + fireScore;
		earthScoreText.text = "Earth: " + earthScore;
		waterScoreText.text = "Water: " + waterScore;
		airScoreText.text = "Air: " + airScore;
	}
}
