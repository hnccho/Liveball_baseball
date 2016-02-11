using UnityEngine;
using System.Collections;

public class DeleteInvenItemInfoEvent : BaseEvent {

	public DeleteInvenItemInfoEvent(EventDelegate eventDelegate)
	{
		base.eventDelegate = eventDelegate;

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		//		response = JsonFx.Json.JsonReader.Deserialize<GetSposTeamInfoResponse>(data);
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<GetDeleteResponse>(data);
		
		//		if (checkError ())
		//			return;
		
		eventDelegate.Execute ();
	}
	
	public GetDeleteResponse Response
	{
		get{ return response as GetDeleteResponse;}
	}

}
