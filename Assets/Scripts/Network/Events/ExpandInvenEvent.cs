using UnityEngine;
using System.Collections;

public class ExpandInvenEvent : BaseEvent {

	public ExpandInvenEvent(EventDelegate.Callback callback)
	{
		base.eventDelegate = new EventDelegate(callback);

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<ExpandInvenResponse>(data);

		if (checkError ())
			return;

		eventDelegate.Execute ();
	}

	public ExpandInvenResponse Response
	{
		get{ return response as ExpandInvenResponse;}
	}

}
