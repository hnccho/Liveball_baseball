using UnityEngine;
using System.Collections;

public class ContestDataEvent : BaseEvent {

	public ContestDataEvent(EventDelegate.Callback callback)
	{
		base.eventDelegate = new EventDelegate(callback);

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<ContestListResponse>(data);

		if (checkError ())
			return;

		eventDelegate.Execute ();
	}

	public ContestListResponse Response
	{
		get{ return response as ContestListResponse;}
	}

}
