using UnityEngine;
using System.Collections;

public class GetGoldShopEvent : BaseEvent {

	public GetGoldShopEvent(EventDelegate.Callback callback)
	{
		base.eventDelegate = new EventDelegate(callback);

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<GetGoldShopResponse>(data);

		if (checkError ())
			return;

		eventDelegate.Execute ();
	}

	public GetGoldShopResponse Response
	{
		get{ return response as GetGoldShopResponse;}
	}

}
