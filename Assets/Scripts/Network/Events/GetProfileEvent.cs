using UnityEngine;
using System.Collections;

public class GetProfileEvent : BaseEvent {

	public GetProfileEvent(EventDelegate eventDelegate)
	{
		base.eventDelegate = eventDelegate;

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = (GetProfileResponse)Newtonsoft.Json.JsonConvert.DeserializeObject(data, typeof(GetProfileResponse));
//		Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataSet>(data);
//		if (checkError ())
//			return;

		eventDelegate.Execute ();
	}

	public GetProfileResponse Response
	{
		get{ return response as GetProfileResponse;}
	}

}
