using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace AssemblyCSharp
{
	public class Orchestra
	{
		private List<GameObject> _performers = new List<GameObject>();
		//TODO: unify these two
		private List<Track> _tracks = new List<Track>();
		private List<NonTrack> _nonTracks = new List<NonTrack>();
		private List<TrackForPrefab> _tracksForPrefabs = new List<TrackForPrefab>();

		public Orchestra ()
		{
			//InitializeTracksProcedurally ();
			InitializeNonTracksProcedurally ();
			//InitializeTracksFromPrefabs ();
			InitializeTrackFlare ();
		}


		public void InitializeNonTracksProcedurally()
		{
			//add non tracks manually
			_nonTracks.Add (new Swarm_A ());

		}

		//TODO: fix so these can be initiated. Alt 1: don't inherit from mono behavior. Alt 2: create alternate track object for this purpose. 
		public void InitializeTracksProcedurally()
		{
			//add tracks manually
			//_tracks.Add (new StaticSpeakerSource_L ());


			//_tracks.Add (new StaticSpeakerSource_R ());
			_tracks.Add (new LeadSynth_L ());
			_tracks.Add (new LeadSynth_R ());
		

			foreach (Track track in _tracks) 
			{
				_performers.Add (track.SoundSource);
			}

		}
		public void InitializeTracksFromPrefabs()
		{
		//TODO: fill here
			List<GameObject> trackPrefafsOnStage = GameObject.FindGameObjectsWithTag("audioTrack").ToList();

			foreach(GameObject trackPrefab in trackPrefafsOnStage)
			{
				trackPrefab.GetComponent<TrackForPrefab>().CenterPosition = trackPrefab.transform.position;

				_tracksForPrefabs.Add(trackPrefab.GetComponent<TrackForPrefab>());
				_performers.Add (trackPrefab);

			}

		}

		public void InitializeTrackFlare()
		{
			//TODO: unify
			//add Every object in the hierarchy
			foreach (Track track in _tracks) 
			{

				_performers.AddRange (InitializePerformersAssociatedToTrack (track));
			}
			foreach (NonTrack nonTrack in _nonTracks) 
			{

				_performers.AddRange (InitializePerformersAssociatedToTrack (nonTrack));
			}

			foreach (TrackForPrefab track in _tracksForPrefabs) 
			{
				_performers.AddRange (InitializePerformersAssociatedToTrack (track));
			}
			
		}

		private List<GameObject> InitializePerformersAssociatedToTrack (Track track)	{

			List<GameObject> associatedObjects = new List<GameObject> ();
			if (track.hasAssociatedObjects)
			{

				//TODO: declaration of these objects and the hierarchy should be done in the track initialization?
				associatedObjects.AddRange( ObjectFactory.InitializeRandomPrefabsInSphere(track.associatedObjectsPrefabType, track.CenterPosition, 20, track.WidthOfAssociatedObjects, 360.0f, 180.0f) );

				foreach (GameObject associatedObject in associatedObjects) 
				{
					associatedObject.tag = String.Concat(track.GetTag (),"_group");
					associatedObject.transform.parent = track.GetTransform();
				}
			}

			return associatedObjects;

		}
		private List<GameObject> InitializePerformersAssociatedToTrack (NonTrack nonTrack)	{

			List<GameObject> associatedObjects = new List<GameObject> ();
			if (nonTrack.hasAssociatedObjects)
			{

				//TODO: declaration of these objects and the hierarchy should be done in the track initialization?
				associatedObjects.AddRange( ObjectFactory.InitializeRandomPrefabsInSphere(nonTrack.associatedObjectsPrefabType, nonTrack.CenterPosition, 500, nonTrack.WidthOfAssociatedObjects, 360.0f, 180.0f) );

				foreach (GameObject associatedObject in associatedObjects) 
				{
					associatedObject.tag = String.Concat(nonTrack.GetTag (),"_group");
					associatedObject.transform.parent = nonTrack.GetTransform();
				}
			}

			return associatedObjects;

		}

		private List<GameObject> InitializePerformersAssociatedToTrack (TrackForPrefab track)	{
			
			List<GameObject> associatedObjects = new List<GameObject> ();
			if (track.hasAssociatedObjects)
			{
				
				//TODO: declaration of these objects and the hierarchy should be done in the track initialization?
				associatedObjects.AddRange( ObjectFactory.InitializeRandomPrefabsInSphere(track.associatedObjectsPrefabType, track.CenterPosition, 20, track.WidthOfAssociatedObjects, 360.0f, 180.0f) );
				
				foreach (GameObject associatedObject in associatedObjects) 
				{
					associatedObject.tag = String.Concat(track.GetTag (),"_group");
					associatedObject.transform.parent = track.GetTransform();
				}
			}
			
			return associatedObjects;
			
		}

		public List<GameObject> GetObjects(String specifier, bool includeGroupedObjects = true)
		{
			List<GameObject> selectedObjects = null;

			switch(specifier)
			{
			case "all":
				selectedObjects = _performers;
				break;
			case "staticObjects":
				selectedObjects = GameObject.FindGameObjectsWithTag("staticSpeakerSource_L").ToList();

				//_performers.FindAll(FindComputer(specifier));

				selectedObjects.AddRange( GameObject.FindGameObjectsWithTag("staticSpeakerSource_R").ToList() );
				break;
			default:
				selectedObjects = GameObject.FindGameObjectsWithTag(specifier).ToList();
				if(includeGroupedObjects)
				{
					selectedObjects.AddRange( GameObject.FindGameObjectsWithTag( String.Concat(specifier,"_group")).ToList() );
				}

				break;
				
			}
			return selectedObjects;	
		}

		/*
		private bool FindComputer(GameObject gO, String tag)
		{
			
			if (gO.tag == tag)
			{
				return true;
			}
			else
			{
				return false;
			}
			
		}*/


		public void DestroyObjects()
		{
			foreach (GameObject obj in _performers)
			{
				MonoBehaviour.Destroy(obj);
			}
		}
	}
}

