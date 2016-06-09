using UnityEngine;
using System.Collections;

public class NoticeEvent : BaseEvent {

	public NoticeEvent(EventDelegate.Callback callback)
	{
		base.eventDelegate = new EventDelegate(callback);

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<NoticeResponse>(data);

		if (checkError ())
			return;

		eventDelegate.Execute ();
	}

	public NoticeResponse Response
	{
		get{ return response as NoticeResponse;}
	}

}
