using UnityEngine;
using System.Collections;

public class GetMailEvent : BaseEvent {

	public GetMailEvent(EventDelegate.Callback callback)
	{
		base.eventDelegate = new EventDelegate(callback);

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<GetMailResponse>(data);

		if (checkError ())
			return;

		eventDelegate.Execute ();
	}

	public GetMailResponse Response
	{
		get{ return response as GetMailResponse;}
	}

}
