using UnityEngine;
using System.Collections;

public class JoinQuizEvent : BaseEvent {

	public JoinQuizEvent(EventDelegate eventDelegate)
	{
		base.eventDelegate = eventDelegate;

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		Debug.Log ("JoinQuizResponse : " + data);
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<GetProfileResponse>(data);

		if (checkError ())
			return;

		eventDelegate.Execute ();
	}

	public GetProfileResponse Response
	{
		get{ return response as GetProfileResponse;}
	}

}
