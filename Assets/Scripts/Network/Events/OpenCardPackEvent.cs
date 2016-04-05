using UnityEngine;
using System.Collections;

public class OpenCardPackEvent : BaseEvent {

	public OpenCardPackEvent(EventDelegate.Callback callback)
	{
		base.eventDelegate = new EventDelegate(callback);

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<OpenCardPackResponse>(data);

		if (checkError ())
			return;

		eventDelegate.Execute ();
	}

	public OpenCardPackResponse Response
	{
		get{ return response as OpenCardPackResponse;}
	}

}
