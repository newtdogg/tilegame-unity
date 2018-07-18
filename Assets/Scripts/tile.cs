using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile {

	public string type;
	public int fireScore;
	public int earthScore;
	public int waterScore;
	public int airScore;
	public int tileslength;
	public int buildCounter;
	public int tier;
	public string queuedType;
	Dictionary<string, string> tilecombos = new Dictionary<string, string>();
	public List<string> tiletypes = new List<string>{
		"sea",
		"land",
		"fissure"
	};
	
	public Tile() {
		tileslength = tiletypes.Count;
		type = tiletypes[GetRandomNumber(0, tileslength)];
		queuedType = type;
		populateTilecombos();
		tier = 1;
		buildCounter = 0;
	}

	public Color generateType(){
		if (type == "sea"){
			return Color.blue;
		} 
		else if (type == "land"){
			return Color.green;
		}
		else if (type == "hotspot") {
			return new Color(.095f, .001f, .001f);
		}
		else if (type == "continent") {
			return new Color(.065f, .111f, 0);
		}
		else if (type == "mud") {
			return new Color(.051f, .013f, 0);
		}
		else if (type == "dust") {
			return Color.gray;
		}
		else if (type == "island") {
			return new Color(.051f, .214f, .198f);
		}
		else if (type == "atmosphere") {
			return new Color(.205f, .250f, .249f);
		}
		else if (type == "vents") {
			return new Color(.117f, .126f, .179f);
		}
		else if (type == "ocean") {
			return new Color(.017f, .026f, .144f);
		}
		else if (type == "fumerole") {
			return new Color(.185f, .160f, .144f);
		}
		else if (type == "lavaflow") {
			return new Color(.139f, .037f, .018f);
		}
		else if (type == "oceanridge") {
			return new Color(.036f, .026f, .111f);
		}
		else if (type == "building") {
			return Color.white;
		}
		return Color.red;
	}

	public void generatePoints(){
		if (type == "sea"){
			waterScore = 1;
		} 
		else if (type == "land"){
			earthScore = 1;
		}
		else {
			fireScore = 1;
			airScore = 1;
		}
	}

	public void setType(string element){
		string combotype = element + type;
		type = "building";
		queuedType = tilecombos[combotype];
		build();
	}

	private void build(){
		buildCounter += tier;
	}

	private static readonly System.Random getrandom = new System.Random();

	public static int GetRandomNumber(int min, int max){
		lock(getrandom) // synchronize
		{
			return getrandom.Next(min, max);
		}
	}
	
	private void populateTilecombos(){
		tilecombos.Add("fireland", "hotspot");
		tilecombos.Add("earthland", "continent");
		tilecombos.Add("waterland", "mud");
		tilecombos.Add("airland", "dust");
		tilecombos.Add("earthsea", "island");
		tilecombos.Add("airsea", "atmosphere");
		tilecombos.Add("firesea", "vents");
		tilecombos.Add("watersea", "ocean");
		tilecombos.Add("earthfissure", "volcano");
		tilecombos.Add("airfissure", "fumerole");
		tilecombos.Add("firefissure", "lavaflow");
		tilecombos.Add("waterfissure", "oceanridge");

	}
	
}
