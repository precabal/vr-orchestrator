using UnityEngine;
using System.Collections;

/// <summary>
/// Forces Unity to change the sample rate on Android/iOS
/// Unity by default runs at a sample rate of 24KHz on Android and iOS.
/// 
/// This script must be placed on an object in an empty scene/level and should
/// be loaded first, before any other scenes.
/// It changes the sample rate of the application and then loads the next scene in your game.
/// Make sure this empty scene does not have any 3Dception componenets loaded!
/// </summary>
public class TBE_SRChange : MonoBehaviour {
	
	public int SampleRate = 44100;
	public int LevelNumber = 1;
	
	void Start () 
	{
		
		// The below code will have no effect on desktops/editor
		#if UNITY_ANDROID || UNITY_IOS

			#if UNITY_5_0
			
			var AudioConfig = AudioSettings.GetConfiguration();
			AudioConfig.sampleRate = SampleRate;
			AudioSettings.Reset(AudioConfig);

			#else
			
			// For Unity 4.x 
			AudioSettings.outputSampleRate = SampleRate;

			#endif // UNITY_5_0

		#endif // UNITY_ANDROID || UNITY_IOS

		Debug.Log ( "Audio Sample Rate Set To: " + AudioSettings.outputSampleRate );
		Application.LoadLevel (LevelNumber);
		
	}
	
}