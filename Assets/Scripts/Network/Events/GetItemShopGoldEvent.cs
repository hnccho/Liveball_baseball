using UnityEngine;
using System.Collections;

public class GetItemShopGoldEvent : BaseEvent {

	public GetItemShopGoldEvent(EventDelegate eventDelegate)
	{
		base.eventDelegate = eventDelegate;

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<GetItemShopGoldResponse>(data);

		if (checkError ())
			return;

		eventDelegate.Execute ();
	}

	public GetItemShopGoldResponse Response
	{
		get{ return response as GetItemShopGoldResponse;}
	}

}
