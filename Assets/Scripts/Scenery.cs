using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace AssemblyCSharp
{
	public class Scenery
	{
		private List<GameObject> _gameObjects = new List<GameObject>();
		private int _baseNumberOfTiles = 28;
		private System.Random random = new System.Random ();

		public Scenery ()
		{
			InitializeTiles ();
		}

		//works better if it is even. TODO: correct for odd. 
		private void InitializeTiles()
		{
			GameObject tilesContainer = new GameObject ("Tiles");

			GameObject tilePrefab = Resources.Load("tile_prefab") as GameObject;

			float tileDimensionX = tilePrefab.transform.localScale.x;
			float tileDimensionZ = tilePrefab.transform.localScale.z;

			for (int i = 0; i < _baseNumberOfTiles; i++)
			{
				for (int j = 0; j < _baseNumberOfTiles; j++)
				{
					GameObject tile = ObjectFactory.CreateFromPrefab(PrefabType.tile);
					tile.transform.position = new Vector3( tileDimensionX*(i - _baseNumberOfTiles/2), 0, tileDimensionZ*(j - _baseNumberOfTiles/2));
					tile.transform.parent = tilesContainer.transform;

					tagTile(tile, i, j, "random");
					tagTile(tile, i, j, "scatter");

					_gameObjects.Add(tile);

				}
			}

		}


		public List<GameObject> GetObjects(String specifier)
		{
			List<GameObject> selectedObjects = null;
			
			switch(specifier)
			{
			//TODO case "random":
			case "all":
				selectedObjects = _gameObjects;
				break;
			case "tiles":
				selectedObjects = GameObject.FindGameObjectsWithTag("tiles_A").ToList();
				selectedObjects.AddRange(GameObject.FindGameObjectsWithTag("tiles_B").ToList());
				selectedObjects.AddRange(GameObject.FindGameObjectsWithTag("tiles_C").ToList());
				selectedObjects.AddRange(GameObject.FindGameObjectsWithTag("tiles_fixed").ToList());
				break;
			default:
				selectedObjects = GameObject.FindGameObjectsWithTag(specifier).ToList();
				break;
				
			}
			return selectedObjects;	
		}
	

		private void tagTile(GameObject tile, int i, int j, String mode)
		{
			switch(mode)
			{
			case "chessboard":
				if ((i + j) % 2 == 0) {
					tile.tag = "tiles_A";
				} else {
					tile.tag = "tiles_B";
				}
				break;
			case "random":
				
				switch (random.Next (0, 3))
				{
				case 0: 
					tile.tag = "tiles_A";
					break;
				case 1:
					tile.tag = "tiles_B";
					break;
				case 2:
					tile.tag = "tiles_C";
					break;
				}
				
				break;
			case "scatter":
				
				if (random.Next (0, 8) != 1) 
				{
					tile.tag = "tiles_fixed";
				}
				break;
			default:
				break;
			}
			//For keeping the middle tiles still no matter what.
			if( (Math.Abs(i-(_baseNumberOfTiles-1)*0.5f) <= 1) && (Math.Abs(j-(_baseNumberOfTiles-1)*0.5f) <=1 ) )
			{
				tile.tag = "tiles_fixed";
			}
		}
		

		
	}
}

