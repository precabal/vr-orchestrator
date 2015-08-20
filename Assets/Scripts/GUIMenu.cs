using UnityEngine;
using AssemblyCSharp;

public class GUIMenu : VRGUI 
{
	public GUISkin skin;

	GameObject audioSource;

	private new void OnEnable()
	{
		audioSource = GameObject.FindGameObjectWithTag("audioSource");
		base.OnEnable();
	}

	public override void OnVRGUI()
	{
		GUI.skin = skin;

		//TODO relocate nicely



		//TODO replace for song time
		GUI.Label(new Rect(Screen.width/2, Screen.height - 50, 600f, 100f), "Time: " + audioSource.GetComponent<AudioSource>().time);

		//TODO position next to crosshair
		GUI.Label( new Rect(Screen.width/2, Screen.height - 100, 800, 100), GetFormattedListOfStrings()); 


		//TODO add crosshair here
	}
	private string GetFormattedListOfStrings()
	{
		string result = "";
		foreach(string temp in Definitions.selectedObjects)
		{

			result = string.Concat(result,temp,"\n");
		}
		Debug.Log(result);
		return result;

	}
}
