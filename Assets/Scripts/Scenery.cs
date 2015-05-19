using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace AssemblyCSharp
{
	public class Scenery
	{
		private ObjectFactory _objectFactory = new ObjectFactory();
		private List<GameObject> _tiles = new List<GameObject>();

		public Scenery ()
		{
			Initialize ();
		}

		private void Initialize()
		{
			InitializeTiles ();
		}

		private void InitializeTiles()
		{
			GameObject tilePrefab = Resources.Load("tile_prefab") as GameObject;

			for (int i = 0; i < 10; i++)
			{
				for (int j = 0; j < 10; j++)
				{
					GameObject tile = _objectFactory.CreateFromPrefab(tilePrefab);
					tile.transform.position = new Vector3(i - 5, 2, j - 5);
					tile.tag = "tiles";
					
					_tiles.Add(tile);
				}
			}

		}

		public List<GameObject> GetObjects(String specifier)
		{
			List<GameObject> selectedObjects = null;
			
			switch(specifier)
			{
			case "tiles":
				selectedObjects = GameObject.FindGameObjectsWithTag("tiles").ToList();
				break;
			default:
				//TODO igual que all
				break;
				
			}
			return selectedObjects;	
		}

	}
}

