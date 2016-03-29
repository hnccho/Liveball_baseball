using UnityEngine;
using System.Collections;

public class GetMyLineupEvent : BaseEvent {

	/// <summary>
	/// used with MyLineupData n MyEntryData both
	/// </summary>
	public GetMyLineupEvent(EventDelegate.Callback callback)
	{
		base.eventDelegate = new EventDelegate(callback);

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<GetMyLineupResponse>(data);

		if (checkError ())
			return;

		eventDelegate.Execute ();
	}

	public GetMyLineupResponse Response
	{
		get{ return response as GetMyLineupResponse;}
	}

}
