using UnityEngine;
using System.Collections;

public class SetSkillEvent : BaseEvent {

	public SetSkillEvent(EventDelegate.Callback callback)
	{
		base.eventDelegate = new EventDelegate(callback);

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<BaseResponse>(data);

		if (checkError ())
			return;

		eventDelegate.Execute ();
	}

	public BaseResponse Response
	{
		get{ return response;}
	}

}
