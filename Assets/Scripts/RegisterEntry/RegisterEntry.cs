using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class RegisterEntry : MonoBehaviour {

	public GameObject mRegItem;
//	int mContestSeq;
	public ContestListInfo mContestInfo;
	DateTime mContestTime;
	public LineupInfo mLineup;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(mContestTime.Year < 2016)
			return;

		if(UtilMgr.IsMLB()){
			TimeSpan ts = mContestTime.AddHours(13d) - DateTime.Now.AddTicks(UserMgr.DiffTicks);

			transform.FindChild("InfoTop").FindChild("Time").FindChild("LblRight").GetComponent<UILabel>().text
				= UtilMgr.GetDateTime(ts);
		} else{
			TimeSpan ts = mContestTime - DateTime.Now.AddTicks(UserMgr.DiffTicks);

			transform.FindChild("InfoTop").FindChild("Time").FindChild("LblRight").GetComponent<UILabel>().text
			= UtilMgr.GetDateTime(ts);
		}
	}

	PlayerInfo MakePlayerCard(PlayerInfo info){
		CardInfo cardInfo = null;
		foreach(CardInfo card in UserMgr.CardList){
			if(info.playerId == card.playerFK){
				cardInfo = card;
			}
		}
		PlayerInfo playerInfo = new PlayerInfo();
		playerInfo.playerId = info.playerId;
		playerInfo.IsCard = true;
		playerInfo.firstName = info.firstName;
		playerInfo.lastName = info.lastName;
		playerInfo.level = cardInfo.cardLevel;
		playerInfo.grade = cardInfo.cardClass;
		playerInfo.salary = cardInfo.salary;
		playerInfo.salary_org = cardInfo.salary_org;
		playerInfo.position = info.position;
		playerInfo.itemSeq = cardInfo.itemSeq;
		playerInfo.photoUrl = info.photoUrl;
		return playerInfo;
	}

	public void InitRegisterEntry(ContestListInfo contestInfo, LineupInfo lineup){
		InitRegisterEntry(contestInfo);

		if(lineup == null)
			return;

		long [][] lineupArr = new long[2][]{
			new long[]{lineup.slot1, lineup.slot2, lineup.slot3, lineup.slot4, lineup.slot5,
				lineup.slot6, lineup.slot7, lineup.slot8, lineup.slot9 },
			new long[]{lineup.item1, lineup.item2, lineup.item3, lineup.item4, lineup.item5,
				lineup.item6, lineup.item7, lineup.item8, lineup.item9 },
		};

		for(int i = 0; i < lineupArr[0].Length; i++){
			PlayerInfo playerInfo = null;
			foreach(PlayerInfo info in UserMgr.PlayerList){
				if(info.playerId == lineupArr[0][i]){
					playerInfo = info;
					break;
				}
			}

			if(lineupArr[1][i] > 0){
				playerInfo = MakePlayerCard(playerInfo);
			}

			transform.root.FindChild("SelectPlayer").GetComponent<SelectPlayer>().mSelectedNo = i+1;
			SetDesignated(playerInfo);
		}

		if(lineup.name == null || lineup.name.Length < 1)
			transform.FindChild("InfoTop").FindChild("NewEntry").FindChild("Input").GetComponent<UIInput>()
				.value = lineup.lineupName;
		else
			transform.FindChild("InfoTop").FindChild("NewEntry").FindChild("Input").GetComponent<UIInput>()
				.value = lineup.name;

		mLineup = lineup;
	}

	public void InitRegisterEntry(ContestListInfo contestInfo){
//		mContestSeq = contestSeq;
		mContestInfo = contestInfo;

		int year = 0, mon = 0, day = 0, hour = 0, min = 0, sec = 0;
		if(mContestInfo.startTime == null || mContestInfo.startTime.Length < 13){
			mContestTime = new DateTime(2016, 1, 1, 1, 1, 1);
		} else{
			year = int.Parse(mContestInfo.startTime.Substring(0, 4));
			mon = int.Parse(mContestInfo.startTime.Substring(4, 2));
			day = int.Parse(mContestInfo.startTime.Substring(6, 2));
			hour = int.Parse(mContestInfo.startTime.Substring(8, 2));
			min = int.Parse(mContestInfo.startTime.Substring(10, 2));
			sec = int.Parse(mContestInfo.startTime.Substring(12, 2));
		}
		mContestTime = new DateTime(year, mon, day, hour, min, sec);


		string strMin = ""+min;
		if(min < 10)
			strMin = "0"+min;

		if(UtilMgr.IsMLB())
			transform.FindChild("InfoTop").FindChild("Time").FindChild("LblLeft").GetComponent<UILabel>().text
			= "ET " + UtilMgr.GetAMPM(hour)[0] + ":" + strMin + " " + UtilMgr.GetAMPM(hour)[1] + UtilMgr.GetLocalText("StrStart");
		else
			transform.FindChild("InfoTop").FindChild("Time").FindChild("LblLeft").GetComponent<UILabel>().text
			= "KST " + UtilMgr.GetAMPM(hour)[0] + ":" + strMin + " " + UtilMgr.GetAMPM(hour)[1] + UtilMgr.GetLocalText("StrStart");

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

		transform.FindChild("InfoTop").FindChild("NewEntry").FindChild("Input").GetComponent<UIInput>().value = 
			transform.FindChild("InfoTop").FindChild("NewEntry").FindChild("Input").GetComponent<UIInput>().defaultText;
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

		mLineup = null;
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

	public string GetLineupName(){
		if(transform.FindChild("InfoTop").FindChild("NewEntry").FindChild("Input").GetComponent<UIInput>()
			.value.Length < 1)
			return transform.FindChild("InfoTop").FindChild("NewEntry").FindChild("Input").GetComponent<UIInput>()
				.defaultText;
		else
			return transform.FindChild("InfoTop").FindChild("NewEntry").FindChild("Input").GetComponent<UIInput>()
				.value;
	}
}
