using UnityEngine;
using AssemblyCSharp;

public class GUIMenu : VRGUI 
{
	public GUISkin skin;

	public bool savedStateMessage;

	GameObject audioSource;

	private new void OnEnable()
	{
		audioSource = GameObject.FindGameObjectWithTag("audioSource");
		base.OnEnable();
		savedStateMessage = false;
	}

	public override void OnVRGUI()
	{
		GUI.skin = skin;

		//TODO relocate nicely




		GUI.Label(new Rect(Screen.width/2 + 200, Screen.height - 300, 600f, 100f), "Time: " + audioSource.GetComponent<AudioSource>().time);

		//TODO position next to crosshair
		GUI.Label( new Rect(Screen.width/2, Screen.height - 100, 800, 100), GetFormattedListOfStrings()); 


		if(savedStateMessage)
		{
			GUI.Label( new Rect(Screen.width/2, Screen.height/2+100, 800, 100), "Positions Saved!"); 
		}

		//TODO add crosshair here
	}
	private string GetFormattedListOfStrings()
	{
		string result = "";
		foreach(string temp in Definitions.selectedObjects)
		{

			result = string.Concat(result,temp,"\n");
		}
		//Debug.Log(result);
		return result;

	}
}
