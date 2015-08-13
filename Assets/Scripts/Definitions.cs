using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public class Definitions
	{
		private static float speakerHeight = 0.554f;
		private static float speakerDistance = 6.5f;
		public static Vector3 speakerPositionLeft = GetPositionWithAngle(45f);
		public static Vector3 speakerPositionRight = GetPositionWithAngle(-45f);

		public static float minLight = 0.6f;
		public static float maxLight = 6.9f;

		public static float songStart = 6.0f;


		private static Vector3 GetPositionWithAngle(float angle)
		{
			VectorSpherical groundPosition = new VectorSpherical (speakerDistance, 0, (float)Math.PI * angle / 180f);
			Vector3 speakerPosition = Utils.SphericalToCartesian (groundPosition);
			speakerPosition.y += speakerHeight;

			return speakerPosition;

		}
	}
}
