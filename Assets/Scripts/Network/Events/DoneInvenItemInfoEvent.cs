using UnityEngine;
using System.Collections;

public class DoneInvenItemInfoEvent : BaseEvent {

	public DoneInvenItemInfoEvent(EventDelegate eventDelegate)
	{
		base.eventDelegate = eventDelegate;

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		//		response = JsonFx.Json.JsonReader.Deserialize<GetSposTeamInfoResponse>(data);
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<GetDoneInvenItemResponse>(data);
		
		//		if (checkError ())
		//			return;
		
		eventDelegate.Execute ();
	}
	
	public GetDoneInvenItemResponse Response
	{
		get{ return response as GetDoneInvenItemResponse;}
	}

}
