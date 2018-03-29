using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelectPlayer : MonoBehaviour {

	List<PlayerInfo> mPlayerList;
	public int mSelectedNo;
//	static Texture2D mDefaultTxt;
	string mName;

	// Use this for initialization
	void Start () {
//		mDefaultTxt = Resources.Load<Texture2D>("images/man_default_b");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Search(string name){
		mName = name;
		Init(mSelectedNo);
	}

	public void Init(int positionNo){
		transform.FindChild("Top").FindChild("Input").gameObject.SetActive(false);
		transform.FindChild("Top").FindChild("BtnConfirm").gameObject.SetActive(false);
		transform.FindChild("Top").FindChild("LblTitle").gameObject.SetActive(true);
		transform.FindChild("Top").FindChild("BtnSearch").gameObject.SetActive(true);
		transform.FindChild("Top").FindChild("Input").GetComponent<UIInput>().defaultText
		= UtilMgr.GetLocalText("StrInputPlayerName");
		transform.FindChild("Top").FindChild("Input").GetComponent<UIInput>().value = "";

		mSelectedNo = positionNo;
		string title = "";
		switch(positionNo){
		case 1: title = UtilMgr.GetLocalText("StrPitcher"); break;
		case 2: title = UtilMgr.GetLocalText("StrCatcher"); break;
		case 3: title = UtilMgr.GetLocalText("StrFirstBaseman"); break;
		case 4: title = UtilMgr.GetLocalText("StrSecondBaseman"); break;
		case 5: title = UtilMgr.GetLocalText("StrThirdBaseman"); break;
		case 6: title = UtilMgr.GetLocalText("StrShortstop"); break;
		case 7: title = UtilMgr.GetLocalText("StrLeftFielder"); break;
		case 8: title = UtilMgr.GetLocalText("StrCenterFielder"); break;
		case 9: title = UtilMgr.GetLocalText("StrRightFielder"); break;
		}
		transform.FindChild("Top").FindChild("LblTitle").GetComponent<UILabel>()
			.text = UtilMgr.GetLocalText("StrSelect") + " " + title;

		mPlayerList = new List<PlayerInfo>();
		List<int> posList = new List<int>();
		if(positionNo == 3){
			posList.Add(10);
			posList.Add(12);
		} else if((positionNo > 2) && (positionNo < 7)){
			posList.Add(12);
		} else if(positionNo > 6){
			posList.Add(11);
		}
		posList.Add(positionNo);
		foreach(PlayerInfo info in UserMgr.PlayerList){
			foreach(int no in posList){
				if(mName == null || mName.Length < 1){
					if(info.positionNo == no){
						mPlayerList.Add(info);
						//get CardInvenInfo then add them
					}	
				} else{
					if(info.positionNo == no){
						if(Localization.language.Equals("English")){
							if(info.lastName.ToLower().IndexOf(mName.ToLower()) >= 0){
								mPlayerList.Add(info);	
							} else if(info.firstName.ToLower().IndexOf(mName.ToLower()) >= 0){
								mPlayerList.Add(info);
							}
						} else{
							if(info.korName.IndexOf(mName) >= 0){
								mPlayerList.Add(info);
							}
						}
					}
				}

			}
		}

		for(int i = 0; i < mPlayerList.Count; i++){
			PlayerInfo info = mPlayerList[i];
			foreach(CardInfo card in UserMgr.CardList){
				if(info.playerId == card.playerFK){
					PlayerInfo playerInfo = new PlayerInfo();
					playerInfo.playerId = info.playerId;
					playerInfo.firstName = info.firstName;
					playerInfo.lastName = info.lastName;
					playerInfo.playerName = info.playerName;
					playerInfo.korName = info.korName;
					playerInfo.position = info.position;
					playerInfo.photoUrl = info.photoUrl;
					playerInfo.team = info.team;
					playerInfo.teamCode = info.teamCode;
					playerInfo.korTeamName = info.korTeamName;
					playerInfo.teamName = info.teamName;
					
					playerInfo.IsCard = true;
					playerInfo.level = card.cardLevel;
					playerInfo.grade = card.cardClass;
					playerInfo.salary = card.salary;
					playerInfo.salary_org = card.salary_org;
					playerInfo.itemSeq = card.itemSeq;

					i++;
					mPlayerList.Insert(i, playerInfo);
				}
			}
		}
		transform.FindChild("Body").FindChild("Scroll").GetComponent<UIDraggablePanel2>().onDragStarted = OnDragStarted;
		transform.FindChild("Body").FindChild("Scroll").GetComponent<UIDraggablePanel2>().onDragFinished = OnDragFinished;
		transform.FindChild("Body").FindChild("Scroll").GetComponent<UIDraggablePanel2>()
			.Init(mPlayerList.Count, delegate(UIListItem item, int index) {
				InitItem(item, index);
			});
		transform.FindChild("Body").FindChild("Scroll").GetComponent<UIDraggablePanel2>().ResetPosition();
		OnDragFinished();

		mName = "";
	}

	void InitItem(UIListItem item, int index){
		PlayerInfo info = mPlayerList[index];
		if(info.IsCard){
			item.Target.transform.FindChild("Main").gameObject.SetActive(false);
			item.Target.transform.FindChild("Sub").gameObject.SetActive(true);

			Transform tf = item.Target.transform.FindChild("Sub");
			Debug.Log("korname is "+info.korName);
			tf.GetComponent<ItemSelectPlayerSub>().mPlayerInfo = info;

			tf.FindChild("LblSalaryB").GetComponent<UILabel>().text
			= "[s]$ "+UtilMgr.AddsThousandsSeparator(info.salary_org+"");
			tf.FindChild("LblSalary").GetComponent<UILabel>().text
			= "$ "+UtilMgr.AddsThousandsSeparator(info.salary+"");
			tf.FindChild("Level").FindChild("LblLV").FindChild("Label").GetComponent<UILabel>().text
			= info.level+"";
			tf.FindChild("LblSkill").FindChild("Label").GetComponent<UILabel>().text
			= "1";
			tf.FindChild("SprPhoto").GetComponent<UISprite>().spriteName = "starcard_" + info.grade;

			for(int i = 0; i < 6; i++){
				tf.FindChild("Level").FindChild("Star"+(i+1)).GetComponent<UISprite>()
					.color = new Color(102f/255f, 102f/255f, 102f/255f);
			}

			for(int i = 0; i <info.grade; i++){
				tf.FindChild("Level").FindChild("Star"+(i+1)).GetComponent<UISprite>()
					.color = new Color(252f/255f, 133f/255f, 53f/255f);
			}
		} else{
			item.Target.transform.FindChild("Main").gameObject.SetActive(true);
			item.Target.transform.FindChild("Sub").gameObject.SetActive(false);

			Transform tf = item.Target.transform.FindChild("Main");

			tf.GetComponent<ItemSelectPlayerMain>().mPlayerInfo = info;
			tf.FindChild("LblPosition").GetComponent<UILabel>().text = info.position;
			if(Localization.language.Equals("English")){
				tf.FindChild("LblName").GetComponent<UILabel>().text = info.firstName + " " + info.lastName;
				if(tf.FindChild("LblName").GetComponent<UILabel>().width > 232)
					tf.FindChild("LblName").GetComponent<UILabel>().text = info.firstName.Substring(0, 1) + ". " +info.lastName;
				tf.FindChild("LblTeam").GetComponent<UILabel>().text = info.city + " " + info.teamName;	
			} else{
				tf.FindChild("LblName").GetComponent<UILabel>().text = info.korName;
				tf.FindChild("LblTeam").GetComponent<UILabel>().text = info.korTeamName;
			}

			tf.FindChild("LblFPPG").FindChild("LblFPPGV").GetComponent<UILabel>().text
				= string.Format("{0:F1}", info.fppg);
			tf.FindChild("LblPlayed").FindChild("LblPlayedV").GetComponent<UILabel>().text
				= info.games+"";

//			tf.FindChild("LblYear").GetComponent<UILabel>().gameObject.SetActive(false);
			tf.FindChild("LblSalary").GetComponent<UILabel>().text = "$ "+UtilMgr.AddsThousandsSeparator(info.salary);


			item.Target.transform.FindChild("Main").FindChild("MLB").gameObject.SetActive(false);
			item.Target.transform.FindChild("Main").FindChild("KBO").gameObject.SetActive(true);
			tf = item.Target.transform.FindChild("Main").FindChild("KBO");

			if((info.injuryYN != null) && (info.injuryYN.Equals("Y")))
				tf.FindChild("BtnPhoto").FindChild("Panel").FindChild("SprInjury").gameObject.SetActive(true);
			else
				tf.FindChild("BtnPhoto").FindChild("Panel").FindChild("SprInjury").gameObject.SetActive(false);

			TeamScheduleInfo schedule = null;
			foreach(TeamScheduleInfo team in UserMgr.ScheduleList){
				if(info.team == team.awayTeamId
				   || info.team == team.homeTeamId){
					if(team.dateTime.Equals(
						transform.root.FindChild("RegisterEntry").GetComponent<RegisterEntry>().mContestInfo.startTime)){
						schedule = team;
						break;
					}
				}
			}

			if(schedule != null){
				item.Target.transform.FindChild("Main").FindChild("LblYear").GetComponent<UILabel>().text			
					= schedule.awayTeam + "  @  " + schedule.homeTeam;
			} else
				item.Target.transform.FindChild("Main").FindChild("LblYear").gameObject.SetActive(false);

			tf.FindChild("BtnPhoto")
				.FindChild("Panel").FindChild("TxtPlayer").GetComponent<UITexture>().mainTexture
					= UtilMgr.GetTextureDefault();
			tf.FindChild("BtnPhoto")
				.FindChild("Panel").FindChild("TxtPlayer").GetComponent<UITexture>().color
				= new Color(1f, 1f, 1f, 50f/255f);

			UtilMgr.LoadImage(info.playerId
				, tf.FindChild("BtnPhoto")
				.FindChild("Panel").FindChild("TxtPlayer").GetComponent<UITexture>());


		}
	}

	void OnDragStarted(){
//		UtilMgr.StopAllCoroutine();
	}

	void OnDragFinished(){
//		ItemSelectPlayerMain[] items 
//			= transform.FindChild("Body").FindChild("Scroll").GetComponentsInChildren<ItemSelectPlayerMain>();
//		foreach(ItemSelectPlayerMain item in items)
//			item.LoadImage();
	}

//	IEnumerator LoadImage(string url, UITexture texture){
//		WWW www = new WWW(url);
//		yield return www;
//
//		Texture2D temp = new Texture2D(0, 0, TextureFormat.ARGB4444, false);
//		www.LoadImageIntoTexture(temp);
//		texture.mainTexture = temp;
//		texture.width = 130;
//		www.Dispose();
//	}
}
