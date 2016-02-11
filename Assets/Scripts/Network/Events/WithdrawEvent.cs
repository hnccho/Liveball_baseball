using UnityEngine;
using System.Collections;

public class WithdrawEvent : BaseEvent {

	public WithdrawEvent(EventDelegate eventDelegate)
	{
		base.eventDelegate = eventDelegate;

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<BaseResponse>(data);

//		if (checkError ())
//			return;

		eventDelegate.Execute ();
	}

	public BaseResponse Response
	{
		get{ return response;}
	}

}
