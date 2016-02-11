using UnityEngine;
using System.Collections;

public class UpdateMemberInfoEvent : BaseEvent {

	public UpdateMemberInfoEvent(EventDelegate eventDelegate)
	{
		base.eventDelegate = eventDelegate;

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<BaseResponse>(data);

		if (checkError ())
			return;

		eventDelegate.Execute ();
	}

}
