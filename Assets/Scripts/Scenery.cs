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
		private int _baseNumberOfTiles = 20;

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

			for (int i = 0; i < _baseNumberOfTiles; i++)
			{
				for (int j = 0; j < _baseNumberOfTiles; j++)
				{
					GameObject tile = _objectFactory.CreateFromPrefab(tilePrefab);
					tile.transform.position = new Vector3(i - _baseNumberOfTiles/2, 0, j - _baseNumberOfTiles/2);

					tagTile(tile, i, j, true);

					_gameObjects.Add(tile);
				}
			}

		}

		private void tagTile(GameObject tile, int i, int j, Boolean scatter)
		{
			if (scatter) {
				System.Random random = new System.Random ();
				if (random.Next (0, 2) == 1) {
					if ((i + j) % 2 == 0) {
						tile.tag = "tilesA";
					} else {
						tile.tag = "tilesB";
					}
				}
			}
			else
			{
				if ((i + j) % 2 == 0) {
					tile.tag = "tilesA";
				} else {
					tile.tag = "tilesB";
				}
			}


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

