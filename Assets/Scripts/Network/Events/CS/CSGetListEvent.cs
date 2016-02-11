using UnityEngine;
using System.Collections;

public class CSGetListEvent : BaseCSEvent {
	CSGetListResponse response;

	public CSGetListEvent(EventDelegate eventDelegate)
	{
		base.eventDelegate = eventDelegate;

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = new CSGetListResponse(data);

		eventDelegate.Execute ();
	}

	public CSGetListResponse Response
	{
		get{ return response;}
	}

}
