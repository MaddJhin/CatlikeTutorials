using UnityEngine;
using System;

public class ClockManager : MonoBehaviour {

	public Transform hourHand, minuteHand, secondHand;
	public bool analog;

	private const float 
		hoursToDegrees = 360f/12f,
		minutesToDegrees = 360f/60f,
		secondsToDegrees = 360f/60f;
	
	void Update(){

		if (analog)
		{
			TimeSpan timespan = DateTime.Now.TimeOfDay;
			hourHand.localRotation =
				Quaternion.Euler(0f,0f,(float)timespan.TotalHours * -hoursToDegrees);
			minuteHand.localRotation =
				Quaternion.Euler(0f,0f,(float)timespan.TotalMinutes * -minutesToDegrees);
			secondHand.localRotation =
				Quaternion.Euler(0f,0f,(float)timespan.TotalSeconds * -secondsToDegrees);
		}
		else
		{
			DateTime time = DateTime.Now;
			hourHand.localRotation = Quaternion.Euler (0f, 0f, time.Hour * -hoursToDegrees);
			minuteHand.localRotation = Quaternion.Euler (0f, 0f, time.Minute * -minutesToDegrees);
			secondHand.localRotation = Quaternion.Euler (0f, 0f, time.Second * -secondsToDegrees);
		}
	}

}
