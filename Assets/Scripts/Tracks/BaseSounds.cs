using UnityEngine;

namespace AssemblyCSharp
{
	public class BaseSounds : Track
	{

		public BaseSounds () : base ()
		{
			audioClip = Resources.Load("Binaries/audioTracks/base") as AudioClip;
			soundSource = ObjectFactory.CreateFromPrefab(PrefabType.looseSoundSource);
			soundSource.name = "Base Sounds";
			soundSource.GetComponent<AudioSource> ().clip = audioClip;
			soundSource.GetComponent<AudioSource> ().spatialBlend = 0;
			soundSource.GetComponent<AudioSource> ().volume = 0.1f;
			soundSource.GetComponent<OSPAudioSource> ().Bypass = true;
			hasAssociatedObjects = false;

		}
		
	}
}


