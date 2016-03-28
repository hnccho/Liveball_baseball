using UnityEngine;
using System.Collections;

public class ContestMyTeamEvent : BaseEvent {

	public ContestMyTeamEvent(EventDelegate.Callback callback)
	{
		base.eventDelegate = new EventDelegate(callback);

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<ContestMyTeamResponse>(data);

		if (checkError ())
			return;

		eventDelegate.Execute ();
	}

	public ContestMyTeamResponse Response
	{
		get{ return response as ContestMyTeamResponse;}
	}

}
