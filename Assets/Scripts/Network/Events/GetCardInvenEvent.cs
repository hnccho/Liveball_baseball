using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GetCardInvenEvent : BaseEvent {

	public GetCardInvenEvent(EventDelegate eventDelegate)
	{
		base.eventDelegate = eventDelegate;

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
//		JSONObject dd = JSONObject.Create(data);
//		JSONObject cc = dd["data"];
//		JSONObject aa = cc["cardClass"];
//		foreach(JSONObject bb in aa.list){
//			Debug.Log("classCode is "+bb["classCode"].str);
//		}
//		response = new GetCardInvenResponse();
//		response.data = new CardInvenInfo();
//		response = Newtonsoft.Json.JsonConvert.Deserialize<GetCardInvenResponse>(data);

		response = Newtonsoft.Json.JsonConvert.DeserializeObject<GetCardInvenResponse>(data);
//		GetCardInvenResponse resp = Newtonsoft.Json.JsonConvert.Deserialize<GetCardInvenResponse>(data);
//		response = resp;

		if (checkError ())
						return;

		eventDelegate.Execute ();
	}

	public GetCardInvenResponse Response
	{
		get{ return response as GetCardInvenResponse;}
	}

}
