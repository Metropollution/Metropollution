
using UnityEngine;
using System.Collections;

public class GridLayout : MonoBehaviour {
	
	private int board_size_x = 100;
	private int board_size_z = 100;
	
	private NodeClick clickedNodes;
	
	public Transform tile_prefab;
	
	GameObject[,] tileList;
	GameObject currentTile;
	
	
	GameObject grid;
	
	
	void Start(){
		/*Initialize 2D grid tracker with grid size
		tileList = new GameObject[board_size_x,board_size_z];
		
		currentTile = new GameObject();
		currentTile.AddComponent("NodeClick");
		*/
		
		
		//Use NodeClick Class
		clickedNodes = GameObject.FindGameObjectsWithTag("NodeClick").GetComponent<NodeClick>();
		
		grid = new GameObject();
		grid.AddComponent("GuiBehavior"); //Attaches Script to ParentGrid
		grid.layer = 8;
		grid.name = "ParentGrid";
		 
		for ( int x = 0; x < board_size_x; x++ ) 
		{
			for ( int z = 0; z < board_size_z; z++ ) 
			{
				Transform tiles = (Transform)Instantiate(tile_prefab, new Vector3(x,0,z),Quaternion.identity);
				tiles.name = "GridTile " + x + z;
				tiles.parent = grid.transform;
				/*currentTile.setTransform(tiles);
				tileList[x,z] = currentTile;*/				
			}
		}
		

	}
}

	
	
	/*
	 * In the works addition after switching to terrain use rather than plane
	 * 
	 * 
	public Terrain myTerrain;
	public TerrainData myTerrainData;
	public float heightAdjust = 0.1f;
	
	// Use this for initialization
	void Start () {
		if( !myTerrain){
			myTerrain = Terrain.activeTerrain;	
		}
		
		myTerrainData = myTerrain.terrainData;
		
		ApplyGrid();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void ApplyGrid(){
		
		float[,] heights = myTerrainData.GetHeights(0,0, myTerrainData.heightmapWidth, myTerrainData.heightmapHeight);
		
		for(float y = 0; y < myTerrainData.heightmapHeight;y++)
		{
			for(float x = 0; x < myTerrainData.heightmapWidth;x++)
			{
				if(x % 20 == 0 && y % 20 == 0)
				{
					float a = heights[y][x];
					float b = myTerrainData.size.y;
					
					GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
					
					cube.transform.position = new Vector3(x, actualHeight, y);
				}
			}
		}
		
	}
	*/

