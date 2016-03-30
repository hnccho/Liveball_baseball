using UnityEngine;
using System.Collections;

public class GetPlayerRankEvent : BaseEvent {

	public GetPlayerRankEvent(EventDelegate.Callback callback)
	{
		base.eventDelegate = new EventDelegate(callback);

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<EntryListResponse>(data);

		if (checkError ())
			return;

		eventDelegate.Execute ();
	}

	public EntryListResponse Response
	{
		get{ return response as EntryListResponse;}
	}

}
