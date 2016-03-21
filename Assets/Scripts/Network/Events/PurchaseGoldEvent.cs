using UnityEngine;
using System.Collections;

public class PurchaseGoldEvent : BaseEvent {

	public PurchaseGoldEvent(EventDelegate.Callback callback)
	{
		base.eventDelegate = new EventDelegate(callback);

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<PurchaseGoldResponse>(data);

		if (checkError ())
			return;

		eventDelegate.Execute ();
	}

	public PurchaseGoldResponse Response
	{
		get{ return response as PurchaseGoldResponse;}
	}

}
