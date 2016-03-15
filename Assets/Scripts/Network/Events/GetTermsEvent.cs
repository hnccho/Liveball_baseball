using UnityEngine;
using System.Collections;

public class GetTermsEvent : BaseEvent {
	GetTermsResponse mResponse;

	public GetTermsEvent(EventDelegate.Callback callback)
	{
		base.eventDelegate = new EventDelegate(callback);

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		mResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<GetTermsResponse>(data);

		eventDelegate.Execute ();
	}

	public GetTermsResponse Response
	{
		get{ return mResponse;}
	}

}
