﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class RegisterEntry : MonoBehaviour {

	public GameObject mRegItem;
//	int mContestSeq;
	ContestListInfo mContestInfo;
	DateTime mContestTime;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(mContestTime.Year < 2016)
			return;

		TimeSpan ts = mContestTime.AddHours(13d) - DateTime.Now.AddTicks(UserMgr.DiffTicks);

		transform.FindChild("InfoTop").FindChild("Time").FindChild("LblRight").GetComponent<UILabel>().text
			= UtilMgr.GetDateTime(ts);
	}

	public void InitRegisterEntry(ContestListInfo contestInfo){
//		mContestSeq = contestSeq;
		mContestInfo = contestInfo;
		int year = int.Parse(mContestInfo.startTime.Substring(0, 4));
		int mon = int.Parse(mContestInfo.startTime.Substring(4, 2));
		int day = int.Parse(mContestInfo.startTime.Substring(6, 2));
		int hour = int.Parse(mContestInfo.startTime.Substring(8, 2));
		int min = int.Parse(mContestInfo.startTime.Substring(10, 2));
		int sec = int.Parse(mContestInfo.startTime.Substring(12, 2));
		mContestTime = new DateTime(year, mon, day, hour, min, sec);

		string strMin = ""+min;
		if(min < 10)
			strMin = "0"+min;
		transform.FindChild("InfoTop").FindChild("Time").FindChild("LblLeft").GetComponent<UILabel>().text
			= "ET " + UtilMgr.GetAMPM(hour)[0] + ":" + strMin + " " + UtilMgr.GetAMPM(hour)[1] + " Start";

		Initialize ();
	}

	public void Initialize(){
		UtilMgr.ClearList(transform.FindChild("List").FindChild("Scroll View"));
		
		float height = 136f*8f;
		for(int i = 0; i < transform.FindChild("Ground").FindChild("BtnPosition").childCount; i++){
			transform.FindChild("Ground").FindChild("BtnPosition")
				.GetChild(i).GetComponent<BtnPosition>().SetUndesignated();
			
			GameObject go = Instantiate(mRegItem);
			go.transform.parent = transform.FindChild("List").FindChild("Scroll View");
			go.transform.localPosition = new Vector3(0, height - (136f * i), 0);
			go.transform.localScale = new Vector3(1f, 1f, 1f);
			go.transform.FindChild("Label").GetComponent<UILabel>().text = (i+1)+"";
			go.transform.GetComponent<ItemPosition>().SetUndesignated();
		}
		transform.FindChild("List").FindChild("Scroll View").GetComponent<UIScrollView>().ResetPosition();

		transform.FindChild("Btm").GetComponent<BtmInfo>()
			.SetBtmInfo(transform.FindChild("List").FindChild("Scroll View"));
	}

	public void SetDesignated(PlayerInfo info){
		switch(transform.root.FindChild("SelectPlayer").GetComponent<SelectPlayer>().mSelectedNo){
		case 1: transform.FindChild("Ground").FindChild("BtnPosition")
			.FindChild("BtnP").GetComponent<BtnPosition>().SetDesignated(info);	break;
		case 2: transform.FindChild("Ground").FindChild("BtnPosition")
			.FindChild("BtnC").GetComponent<BtnPosition>().SetDesignated(info);	break;
		case 3: transform.FindChild("Ground").FindChild("BtnPosition")
			.FindChild("Btn1B").GetComponent<BtnPosition>().SetDesignated(info);	break;
		case 4: transform.FindChild("Ground").FindChild("BtnPosition")
			.FindChild("Btn2B").GetComponent<BtnPosition>().SetDesignated(info);	break;
		case 5: transform.FindChild("Ground").FindChild("BtnPosition")
			.FindChild("Btn3B").GetComponent<BtnPosition>().SetDesignated(info);	break;
		case 6: transform.FindChild("Ground").FindChild("BtnPosition")
			.FindChild("BtnSS").GetComponent<BtnPosition>().SetDesignated(info);	break;
		case 7: transform.FindChild("Ground").FindChild("BtnPosition")
			.FindChild("BtnLF").GetComponent<BtnPosition>().SetDesignated(info);	break;
		case 8: transform.FindChild("Ground").FindChild("BtnPosition")
			.FindChild("BtnCF").GetComponent<BtnPosition>().SetDesignated(info);	break;
		case 9: transform.FindChild("Ground").FindChild("BtnPosition")
			.FindChild("BtnRF").GetComponent<BtnPosition>().SetDesignated(info);	break;
		}

		for(int i = 0; i < transform.FindChild("List").FindChild("Scroll View").childCount; i++){
			int pos = int.Parse(transform.FindChild("List").FindChild("Scroll View")
			                    .GetChild(i).FindChild("Label").GetComponent<UILabel>().text);
			if(pos == transform.root.FindChild("SelectPlayer").GetComponent<SelectPlayer>().mSelectedNo){
				transform.FindChild("List").FindChild("Scroll View")
					.GetChild(i).GetComponent<ItemPosition>().SetDesignated(info);
				break;
			}
		}

		transform.FindChild("Btm").GetComponent<BtmInfo>()
			.SetBtmInfo(transform.FindChild("List").FindChild("Scroll View"));
	}

	public long[][] GetSlots(){
		long[][] slots = new long[9][];
		for(int i = 0; i < transform.FindChild("List").FindChild("Scroll View").childCount; i++){
			slots[i] = new long[9];
			PlayerInfo info = transform.FindChild("List").FindChild("Scroll View")
				.GetChild(i).GetComponent<ItemPosition>().GetPlayerInfo();
			slots[i][0] = info.playerId;
			slots[i][1] = info.itemSeq;
		}
		return slots;
	}

	public int GetContestSeq(){
//		return mContestSeq;
		return mContestInfo.contestSeq;
	}

	public void Randomize(){
		UtilMgr.ShowLoading();

		StartCoroutine(EnumRand());
	}

	IEnumerator EnumRand(){
		yield return null;

		bool incorrect = true;
		for(int i = 0; i < 9; i++){
			incorrect = true;
			do{
				transform.root.FindChild("SelectPlayer").GetComponent<SelectPlayer>().mSelectedNo = (i+1);
				int rand = UnityEngine.Random.Range(0, UserMgr.PlayerList.Count-1);
				if(UserMgr.PlayerList[rand].positionNo == (i+1)){
					SetDesignated(UserMgr.PlayerList[rand]);
					incorrect = false;
				}
			}while(incorrect);
		}

		
		UtilMgr.DismissLoading();
	}
}