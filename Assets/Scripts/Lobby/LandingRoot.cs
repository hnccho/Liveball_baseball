﻿using UnityEngine;
using System.Collections;

public class LandingRoot : SuperRoot {

	GetProfileEvent mProfileEvent;
	GetEventsEvent mRTEvent;

	// Use this for initialization
	new void Start () {
		base.Start();

		transform.FindChild("Lobby").GetComponent<Lobby>().Init();
	}
	
	new void Awake(){
		base.Awake();
	}
	
	// Update is called once per frame
	new void Update () {
		base.Update();
	}

	public void BtnMenuClick(){
		mProfileEvent = new GetProfileEvent(new EventDelegate(ReceivedProfile));
		NetMgr.GetProfile(UserMgr.UserInfo.memSeq, mProfileEvent);
	}

	void ReceivedProfile(){
		UtilMgr.AddBackState(UtilMgr.STATE.Profile);
		transform.FindChild("Profile").gameObject.SetActive(true);
		transform.FindChild("Profile").localPosition = new Vector3(720f, 0, 0);
		TweenPosition.Begin(transform.FindChild("Profile").gameObject, 1f, new Vector3(132f, 0, 0), false);
		transform.FindChild("Profile").GetComponent<UITweener>().method = UITweener.Method.EaseOut;
		transform.FindChild("Profile").GetComponent<Profile>().Init(mProfileEvent);
	}
}