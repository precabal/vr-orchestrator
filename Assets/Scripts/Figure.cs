using System;
using System.Collections.Generic;
using UnityEngine;

using System.IO;


namespace AssemblyCSharp
{
	public class Figure
	{
		public List<Vector3> points = new List<Vector3>();

		//define the offset for the images as half of the image side (150px)
		private float _offset_z =  246.5f; //437.5f; //246f; //75f;
		private float _offset_y = 437.5f; //246.5f; //246f; //75f;

		private Vector3 figureCenter;

		public Figure ()
		{
			//these are the default value used when loading the figures. 
			figureCenter = new Vector3 (0, 0, 200);

		}

		public Figure (String path) : this()
		{
			FileInfo theSourceFile = null;
			StreamReader reader = null;

			theSourceFile = new FileInfo (Application.dataPath + path);
			if ( theSourceFile != null && theSourceFile.Exists )
				reader = theSourceFile.OpenText();

			if ( reader == null )
			{ 
				Debug.Log(path + " not found or not readable");
			}
			else
			{
				string txt;
				// Read each line from the file
				while ( ( txt = reader.ReadLine()) != null ){
					//parse the line
					String[] result = txt.Split(',');
					this.Add2DPoint( float.Parse(result[0]) , float.Parse(result[1]) );
				}

			}
		}

		public void AddPoint(Vector3 point)
		{
			points.Add(point);
		}

		public void Add2DPoint(float x, float y)
		{
			//we set the point on an arbitrary plane facing the user
			Vector3 arbitraryCenter = new Vector3 (200, 0, 0);
			Vector3 pointInArbitraryPlane = arbitraryCenter + new Vector3 (0, y - _offset_y, -x + _offset_z);

			VectorSpherical delta = Utils.GetDeltaFromCartesianInSpherical (figureCenter, arbitraryCenter);

			points.Add( Utils.AddSphericalToCartesian (pointInArbitraryPlane, delta) );

		}

		public void Add2DPointInFlatPlane(float x, float y)
		{

			points.Add( new Vector3 (999, y - _offset_y, x - _offset_z));

		}


		public void SetImageCenter(Vector3 targetCenter)
		{
			VectorSpherical delta = Utils.GetDeltaFromCartesianInSpherical (targetCenter, figureCenter);

			for (int i = 0; i < NumberOfPoints(); i++) {
				points [i] = Utils.AddSphericalToCartesian (points [i], delta);
			}

			figureCenter = targetCenter;

		}

		public int NumberOfPoints()
		{
			return points.Count;
		}
		public Vector3 getPoint(int index)
		{
			return points[index];
		}
	}
}

