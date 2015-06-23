using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public class Utils
	{
		public Utils ()
		{
		}
		public static Vector3 SphericalToCartesian(VectorSpherical pointInShperical)
		{
			float x = pointInShperical.r * (float) Math.Cos (pointInShperical.theta) * (float) Math.Cos (pointInShperical.phi);
			float y = pointInShperical.r * (float) Math.Sin (pointInShperical.theta);
			float z = pointInShperical.r * (float) Math.Cos (pointInShperical.theta) * (float) Math.Sin (pointInShperical.phi);

			return new Vector3 (x, y, z);

		}

		public static VectorSpherical CartesianToSpherical(Vector3 pointInCartesian)
		{
			float elevation = (float) Math.Asin (pointInCartesian.y / pointInCartesian.magnitude);	
			float azimuth = (float)  Math.Atan2 (pointInCartesian.x, pointInCartesian.z);



			return new VectorSpherical(pointInCartesian.magnitude, elevation, azimuth);
		}

		public static Vector3 AddSphericalToCartesian (Vector3 inputCartesian, VectorSpherical inputSpherical)
		{
			VectorSpherical sphericalPosition = Utils.CartesianToSpherical (inputCartesian);
			
			sphericalPosition.r += inputSpherical.r;
			sphericalPosition.theta += inputSpherical.theta;
			sphericalPosition.phi += inputSpherical.phi;
			
			return SphericalToCartesian(sphericalPosition);


//			Vector3 cartesianToAdd = Utils.SphericalToCartesian (inputSpherical);

//			return inputCartesian + cartesianToAdd;

		}
		//returns cartesianA - cartesianB in spherical coordinates
		public static VectorSpherical GetDeltaFromCartesianInSpherical(Vector3 cartesianA, Vector3 cartesianB)
		{
			VectorSpherical sphericalA = Utils.CartesianToSpherical (cartesianA);
			VectorSpherical sphericalB = Utils.CartesianToSpherical (cartesianB);
			
			VectorSpherical delta;
			delta.r = sphericalA.r - sphericalB.r;
			delta.theta = sphericalA.theta - sphericalB.theta;
			delta.phi = sphericalA.phi - sphericalB.phi;

			return delta;
		}

	}
}

