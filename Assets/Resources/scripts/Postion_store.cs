using UnityEngine;
using System.Collections;
using Leap;
using Leap.Unity;

public class Postion_store : MonoBehaviour {

	LeapProvider provider;
	// Use this for initialization
	void Start () {
		provider = FindObjectOfType<LeapProvider>() as LeapProvider;
	}
	
	// Update is called once per frame
	void Update () {
		Frame frame = provider.CurrentFrame;
		foreach (Hand hand in frame.Hands)
		{
			foreach(Finger f in hand.Fingers)
				print ( f.Type +" : " + f.TipPosition);
		}
	}
}
