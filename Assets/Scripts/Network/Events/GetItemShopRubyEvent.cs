using UnityEngine;
using System.Collections;

public class GetItemShopRubyEvent : BaseEvent {

	public GetItemShopRubyEvent(EventDelegate eventDelegate)
	{
		base.eventDelegate = eventDelegate;

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<GetItemShopRubyResponse>(data);

		if (checkError ())
			return;

		eventDelegate.Execute ();
	}

	public GetItemShopRubyResponse Response
	{
		get{ return response as GetItemShopRubyResponse;}
	}

}
