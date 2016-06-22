using UnityEngine;
using System.Collections;

public class SkillsetListEvent : BaseEvent {

	public SkillsetListEvent(EventDelegate.Callback callback)
	{
		base.eventDelegate = new EventDelegate(callback);

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = Newtonsoft.Json.JsonConvert.DeserializeObject<SkillsetListResponse>(data);

		if (checkError ())
			return;

		eventDelegate.Execute ();
	}

	public SkillsetListResponse Response
	{
		get{ return response as SkillsetListResponse;}
	}

}
