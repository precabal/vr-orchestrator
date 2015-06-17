using System;
namespace AssemblyCSharp
{
	public struct VectorSpherical
	{
		public float r;
		public float theta;
		public float phi;

		public VectorSpherical(float radius, float elevation, float azimuth)
		{
			r = radius;
			theta = elevation;
			phi = azimuth;
		}
	}
}

