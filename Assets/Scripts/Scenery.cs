using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace AssemblyCSharp
{
	public class Scenery
	{
		private ObjectFactory _objectFactory = new ObjectFactory();
		private List<GameObject> _gameObjects = new List<GameObject>();
		private int _baseNumberOfTiles = 14;
		private System.Random random = new System.Random ();

		public Scenery ()
		{
			Initialize ();
		}

		private void Initialize()
		{
			InitializeTiles ();
		}

		//works better if it is even. TODO: correct for odd. 
		private void InitializeTiles()
		{
			GameObject tilePrefab = Resources.Load("tile_prefab") as GameObject;

			float tileDimensionX = tilePrefab.transform.localScale.x;
			float tileDimensionZ = tilePrefab.transform.localScale.z;

			for (int i = 0; i < _baseNumberOfTiles; i++)
			{
				for (int j = 0; j < _baseNumberOfTiles; j++)
				{
					GameObject tile = _objectFactory.CreateFromPrefab(tilePrefab);
					tile.transform.position = new Vector3( tileDimensionX*(i - _baseNumberOfTiles/2), 0, tileDimensionZ*(j - _baseNumberOfTiles/2));

					tagTile(tile, i, j, "random");
					tagTile(tile, i, j, "scatter");

					_gameObjects.Add(tile);
				}
			}

		}

		private void tagTile(GameObject tile, int i, int j, String mode)
		{
			switch(mode)
			{
			case "chessboard":
				if ((i + j) % 2 == 0) {
					tile.tag = "tilesA";
				} else {
					tile.tag = "tilesB";
				}
				break;
			case "random":

				switch (random.Next (0, 3))
				{
				case 0: 
					tile.tag = "tilesA";
					break;
				case 1:
					tile.tag = "tilesB";
					break;
				case 2:
					tile.tag = "tiles3_2";
					break;
				}

				break;
			case "scatter":
				
				if (random.Next (0, 8) != 1) 
				{
					tile.tag = "tilesC";
				}
				break;
			default:
				break;
			}
			//For keeping the middle tiles still no matter what.
			if( (Math.Abs(i-(_baseNumberOfTiles-1)*0.5f) <= 1) && (Math.Abs(j-(_baseNumberOfTiles-1)*0.5f) <=1 ) )
			{
				tile.tag = "tilesC";
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
				selectedObjects = GameObject.FindGameObjectsWithTag("tilesA").ToList();
				selectedObjects.AddRange(GameObject.FindGameObjectsWithTag("tilesB").ToList());
				selectedObjects.AddRange(GameObject.FindGameObjectsWithTag("tilesC").ToList());
				break;
			default:
				selectedObjects = GameObject.FindGameObjectsWithTag(specifier).ToList();
				break;
				
			}
			return selectedObjects;	
		}
	
		
	}
}

