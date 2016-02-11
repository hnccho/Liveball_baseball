using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CheckMemberPincodeEvent : BaseEvent {

	public CheckMemberPincodeEvent(EventDelegate eventDelegate)
	{
		base.eventDelegate = eventDelegate;

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<CheckMemberPincodeResponse>(data);

		eventDelegate.Execute ();
	}

	public CheckMemberPincodeResponse Response
	{
		get{ return response as CheckMemberPincodeResponse;}
	}

}
