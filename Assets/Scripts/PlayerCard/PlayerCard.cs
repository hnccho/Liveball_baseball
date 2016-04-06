using UnityEngine;
using System.Collections;

public class PlayerCard : MonoBehaviour {

	long mPlayerId;
	bool IsPitcher;
	bool IsCard;
	string mHand;
	CardInfo mCardInfo;
	PlayerInfo mPlayerInfo;
	Texture mPhoto;

	PlayerSeasonInfoEvent mSeasonEvent;
	PlayerNewsInfoEvent mNewsEvent;
	PlayerGameInfoEvent mGameEvent;

	public GameObject mItemGameMonth;
	public GameObject mItemGameArticlesP;
	public GameObject mItemGameArticlesH;
	public GameObject mItemGameSubH;
	public GameObject mItemGameSubP;

	bool IsInactive;

	string[][] DCRate = new string[6][]{
		new string[]{"0.00%",		"0.20%",		"0.40%",		"0.60%",		"0.80%",		"1.00%"},
		new string[]{"1.50%",		"1.80%",		"2.10%",		"2.40%",		"2.70%",		"3.00%"},
		new string[]{"3.50%",		"3.90%",		"4.30%",		"4.70%",		"5.10%",		"5.50%"},
		new string[]{"6.00%",		"6.50%",		"7.00%",		"7.50%",		"8.00%",		"8.50%"},
		new string[]{"9.00%",		"9.50%",		"10.00%",		"10.50%",		"11.00%",		"11.50%"},
		new string[]{"12.50%",		"13.00%",		"13.50%",		"14.00%",		"14.50%",		"15.00%"}
	};

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnClose(){
		transform.localPosition = new Vector3(2000f, 2000f);
		transform.gameObject.SetActive(false);
		UtilMgr.RemoveBackState(UtilMgr.STATE.PlayerCard);
	}

	public void Init(PlayerInfo playerInfo, Texture photo){
		mPlayerInfo = playerInfo;
		mPhoto = photo;
		IsCard = false;
		if(UtilMgr.IsMLB()){
			transform.FindChild("Info").FindChild("KBO").FindChild("Panel").FindChild("Photo")
				.GetComponent<UITexture>().width = 135;
			transform.FindChild("Info").FindChild("KBO").FindChild("Panel").FindChild("Photo")
				.GetComponent<UITexture>().height = 180;

			transform.FindChild("SelectionForPlayer").gameObject.SetActive(true);
			transform.FindChild("SelectionForPlayerKBO").gameObject.SetActive(false);
			transform.FindChild("SelectionForCard").gameObject.SetActive(false);
			transform.FindChild("SelectionForCardKBO").gameObject.SetActive(false);
		} else{
			transform.FindChild("SelectionForPlayer").gameObject.SetActive(false);
			transform.FindChild("SelectionForPlayerKBO").gameObject.SetActive(true);
			transform.FindChild("SelectionForCard").gameObject.SetActive(false);
			transform.FindChild("SelectionForCardKBO").gameObject.SetActive(false);
		}
		mPlayerId = playerInfo.playerId;

		CommonInit();
	}

	public void InitWithCard(CardInfo cardInfo, Texture photo){
		mPhoto = photo;
		IsCard = true;
		mCardInfo = cardInfo;

		if(UtilMgr.IsMLB()){			
			transform.FindChild("Info").FindChild("KBO").FindChild("Panel").FindChild("Photo")
				.GetComponent<UITexture>().width = 135;
			transform.FindChild("Info").FindChild("KBO").FindChild("Panel").FindChild("Photo")
				.GetComponent<UITexture>().height = 180;

			transform.FindChild("SelectionForPlayer").gameObject.SetActive(false);
			transform.FindChild("SelectionForPlayerKBO").gameObject.SetActive(false);
			transform.FindChild("SelectionForCard").gameObject.SetActive(true);
			transform.FindChild("SelectionForCardKBO").gameObject.SetActive(false);
		} else{
			transform.FindChild("SelectionForPlayer").gameObject.SetActive(false);
			transform.FindChild("SelectionForPlayerKBO").gameObject.SetActive(false);
			transform.FindChild("SelectionForCard").gameObject.SetActive(false);
			transform.FindChild("SelectionForCardKBO").gameObject.SetActive(true);
		}

		mPlayerId = cardInfo.playerFK;
		CommonInit();
	}

	void CommonInit(){
		transform.gameObject.SetActive(true);
		IsInactive = false;

		GetInfos();
	}

	void InitGameLog(){
		transform.FindChild("Changeables").FindChild("GameLog").gameObject.SetActive(true);
		UtilMgr.ClearList(
			transform.FindChild("Changeables").FindChild("GameLog").FindChild("Scroll View"));

		string month = "";
		float height = 0;
		int colorIndicator = 0;
		for(int i = 0; i < mGameEvent.Response.data.Count; i++){
			GameObject go = null;
			PlayerGameInfo info = mGameEvent.Response.data[i];
			if(!month.Equals(info.month)){
				month = info.month;
				colorIndicator = 0;
				go = Instantiate(mItemGameMonth);
				go.transform.parent = transform.FindChild("Changeables").FindChild("GameLog").FindChild("Scroll View");
				height -= 30f;
				go.transform.localPosition = new Vector3(0, height);
				height -= 30f;
				go.transform.localScale = new Vector3(1f, 1f, 1f);
				go.transform.FindChild("Label").GetComponent<UILabel>().text = info.month;

				if(IsPitcher)
					go = Instantiate(mItemGameArticlesP);
				else
					go = Instantiate(mItemGameArticlesH);

				go.transform.parent = transform.FindChild("Changeables").FindChild("GameLog").FindChild("Scroll View");
				height -= 25f;
				go.transform.localPosition = new Vector3(0, height);
				height -= 25f;
				go.transform.localScale = new Vector3(1f, 1f, 1f);
			}
			if(IsPitcher)
				go = Instantiate(mItemGameSubP);
			else
				go = Instantiate(mItemGameSubH);
			
			go.transform.parent = transform.FindChild("Changeables").FindChild("GameLog").FindChild("Scroll View");
			height -= 25f;
			go.transform.localPosition = new Vector3(0, height);
			height -= 25f;
			go.transform.localScale = new Vector3(1f, 1f, 1f);

			if(IsPitcher){
				go.transform.FindChild("3").GetComponent<UILabel>().text = info.IP;
				go.transform.FindChild("4").GetComponent<UILabel>().text = info.PH;
				go.transform.FindChild("5").GetComponent<UILabel>().text = info.BB;
				go.transform.FindChild("6").GetComponent<UILabel>().text = info.SO;
				go.transform.FindChild("7").GetComponent<UILabel>().text = info.ER;
				go.transform.FindChild("8").GetComponent<UILabel>().text = info.W;
			} else{
				go.transform.FindChild("3").GetComponent<UILabel>().text = info.AB;
				go.transform.FindChild("4").GetComponent<UILabel>().text = info.H;
				go.transform.FindChild("5").GetComponent<UILabel>().text = info.HR;
				go.transform.FindChild("6").GetComponent<UILabel>().text = info.RBI;
				go.transform.FindChild("7").GetComponent<UILabel>().text = info.R;
				go.transform.FindChild("8").GetComponent<UILabel>().text = info.BB;
			}
			go.transform.FindChild("1").GetComponent<UILabel>().text = info.day;
			go.transform.FindChild("2").GetComponent<UILabel>().text = info.VS;
			go.transform.FindChild("9").GetComponent<UILabel>().text = info.FP;

			if(colorIndicator++ % 2 == 0)
				go.transform.FindChild("BG").GetComponent<UISprite>().color = new Color(1f, 1f, 1f);
			else
				go.transform.FindChild("BG").GetComponent<UISprite>().color = new Color(230f/255f, 230f/255f, 230f/255f);
		}

		transform.FindChild("Changeables").FindChild("GameLog").FindChild("Scroll View")
			.GetComponent<UIScrollView>().ResetPosition();
	}
	
	void InitAnalysis(){
		if(mSeasonEvent.Response.data == null)
			return;

		Transform tf = transform.FindChild("Changeables").FindChild("Analysis");
		tf.gameObject.SetActive(true);

		string[] names;
		string[] values;

		if(IsPitcher){
			names = new string[]{"W", "L", "SV", "IP", "ERA", "PH", "ER", "BB", "SO", "PHR", "WHIP", "PBAA"};
			values = new string[]{
				mSeasonEvent.Response.data.W,
				mSeasonEvent.Response.data.L,
				mSeasonEvent.Response.data.SV,
				mSeasonEvent.Response.data.IP,
				mSeasonEvent.Response.data.ERA,
				mSeasonEvent.Response.data.PH,
				mSeasonEvent.Response.data.ER,
				mSeasonEvent.Response.data.BB,
				mSeasonEvent.Response.data.SO,
				mSeasonEvent.Response.data.PHR,
				mSeasonEvent.Response.data.WHIP,
				mSeasonEvent.Response.data.PBAA};
		} else{
			names = new string[]{"AVG", "HR", "RBI", "R", "H", "OBP", "SLG", "OPS", "SB", "CS", "BB", "HBP"};
			values = new string[]{
				mSeasonEvent.Response.data.AVG,
				mSeasonEvent.Response.data.HR,
				mSeasonEvent.Response.data.RBI,
				mSeasonEvent.Response.data.R,
				mSeasonEvent.Response.data.H,
				mSeasonEvent.Response.data.OBP,
				mSeasonEvent.Response.data.SLG,
				mSeasonEvent.Response.data.OPS,
				mSeasonEvent.Response.data.SB,
				mSeasonEvent.Response.data.CS,
				mSeasonEvent.Response.data.BB,
				mSeasonEvent.Response.data.HBP};
		}

		for(int i = 0; i < 12; i++){
			tf.transform.FindChild("Season").FindChild(""+(i+1)).FindChild("Name").GetComponent<UILabel>().text
				= names[i];
			tf.transform.FindChild("Season").FindChild(""+(i+1)).FindChild("Value").GetComponent<UILabel>().text
				= values[i];
		}

	}
	
	void InitNews(){
		
	}
	
	void InitCardInfo(){
		Transform tf = transform.FindChild("Changeables").FindChild("Card");
		tf.gameObject.SetActive(true);
		for(int i = 0; i < 6; i++){
			tf.FindChild("Level").FindChild("Star").FindChild("Star"+(i+1))
				.GetComponent<UISprite>().color = new Color(100f/255f, 100f/255f, 100f/255f);
		}

		for(int i = 0; i < mCardInfo.cardClass; i++){
			tf.FindChild("Level").FindChild("Star").FindChild("Star"+(i+1))
				.GetComponent<UISprite>().color = new Color(252f/255f, 133f/255f, 53f/255f);
		}
		tf.FindChild("Level").FindChild("Star").FindChild("LblLv").FindChild("LblLVV").GetComponent<UILabel>().text
			= mCardInfo.cardLevel+"";
		tf.FindChild("Level").FindChild("LblDiscount").FindChild("LblDiscountV").GetComponent<UILabel>().text
			= DCRate[mCardInfo.cardClass-1][mCardInfo.cardLevel];
		tf.FindChild("Level").FindChild("LblSalaryB").GetComponent<UILabel>().text = "[s]$"+mCardInfo.salary_org;
		tf.FindChild("Level").FindChild("LblSalaryA").GetComponent<UILabel>().text = "$"+mCardInfo.salary;

		tf.FindChild("Skillset").FindChild("Scroll View").GetComponent<UIScrollView>().ResetPosition();
	}

	void InitPlayerInfo(){
//		if(UtilMgr.IsMLB()){
//			transform.FindChild("Info").FindChild ("MLB").gameObject.SetActive(true);
//			transform.FindChild("Info").FindChild ("KBO").gameObject.SetActive(false);
//
//			transform.FindChild("Info").FindChild ("MLB").FindChild("Panel").FindChild("Photo").GetComponent<UITexture>().mainTexture = mPhoto;
//		} else{
			transform.FindChild("Info").FindChild ("MLB").gameObject.SetActive(false);
			transform.FindChild("Info").FindChild ("KBO").gameObject.SetActive(true);

			transform.FindChild("Info").FindChild ("KBO").FindChild("Panel").FindChild("Photo").GetComponent<UITexture>().mainTexture = mPhoto;
//		}

		mPlayerInfo = null;
		foreach(PlayerInfo info in UserMgr.PlayerList){
			if(info.playerId == mPlayerId){
				if(info.positionNo == 1){
					IsPitcher = true;
//					mHand = info.throwHand.Equals("L") ? UtilMgr.GetLocalText("StrLeft") : UtilMgr.GetLocalText("StrRight");
					if(info.throwHand.Equals("S"))
						mHand = UtilMgr.GetLocalText("StrSwitch");
					else if(info.throwHand.Equals("L"))
						mHand = UtilMgr.GetLocalText("StrLeft");
					else
						mHand = UtilMgr.GetLocalText("StrRight");
				} else{
					IsPitcher = false;
//					mHand = info.batHand.Equals("L") ? UtilMgr.GetLocalText("StrLeft") : UtilMgr.GetLocalText("StrRight");
					if(info.batHand.Equals("S"))
						mHand = UtilMgr.GetLocalText("StrSwitch");
					else if(info.batHand.Equals("L"))
						mHand = UtilMgr.GetLocalText("StrLeft");
					else
						mHand = UtilMgr.GetLocalText("StrRight");
				}
				mPlayerInfo = info;
				break;
			}
		}

		if(mPlayerInfo == null){
			IsInactive = true;
			DialogueMgr.ShowDialogue(UtilMgr.GetLocalText("StrPlayerInfo"), UtilMgr.GetLocalText("StrPlayerInactive")
			                         ,DialogueMgr.DIALOGUE_TYPE.Alert, null);
			return;
		}

		if(mPlayerInfo.injuryYN.Equals("N"))
			transform.FindChild("Info").FindChild("Injury").gameObject.SetActive(false);
		else
			transform.FindChild("Info").FindChild("Injury").gameObject.SetActive(true);

		if(UtilMgr.IsMLB()){
			if(mPlayerInfo.firstName.Length < 1){
				transform.FindChild("Info").FindChild("LblName").GetComponent<UILabel>().text
					= mPlayerInfo.lastName;
			} else{
				transform.FindChild("Info").FindChild("LblName").GetComponent<UILabel>().text
					= mPlayerInfo.firstName.Substring(0, 1) + ". " + mPlayerInfo.lastName;
			}
		} else{
			if(Localization.language.Equals("English")){
				if(mPlayerInfo.firstName.Length < 1){
					transform.FindChild("Info").FindChild("LblName").GetComponent<UILabel>().text
						= mPlayerInfo.lastName;
				} else{
					transform.FindChild("Info").FindChild("LblName").GetComponent<UILabel>().text
						= mPlayerInfo.firstName.Substring(0, 1) + ". " + mPlayerInfo.lastName;
				}
			} else{
				transform.FindChild("Info").FindChild("LblName").GetComponent<UILabel>().text
					= mPlayerInfo.korName;
			}
		}

		transform.FindChild("Info").FindChild("LblSaraly").GetComponent<UILabel>().text
			= IsCard ? "[s]$" + mPlayerInfo.salary : "$" + mPlayerInfo.salary;
		transform.FindChild("Info").FindChild("LblFFPG").FindChild("Label").GetComponent<UILabel>().text
			= "0" + mPlayerInfo.FFPG;
		transform.FindChild("Info").FindChild("LblPlayed").FindChild("Label").GetComponent<UILabel>().text
			= "" + mPlayerInfo.games;

		if(IsCard){
			transform.FindChild("SprGrade").GetComponent<UISprite>().spriteName = "card_top_bg_"+mCardInfo.cardClass;
			transform.FindChild("SprGrade").gameObject.SetActive(true);
		} else
			transform.FindChild("SprGrade").gameObject.SetActive(false);
	}

	void GetInfos(){
		transform.localPosition = new Vector3(2000f, 2000f);
		transform.gameObject.SetActive(true);
		
		mSeasonEvent = new PlayerSeasonInfoEvent(ReceivedSeason);
		NetMgr.PlayerSeasonInfo(mPlayerId, mSeasonEvent);
	}
	
	void ReceivedSeason(){
		mGameEvent = new PlayerGameInfoEvent(ReceivedGame);
		NetMgr.PlayerGameInfo(mPlayerId, mGameEvent);
	}
	
	void ReceivedGame(){
		mNewsEvent = new PlayerNewsInfoEvent(ReceivedNews);
		//		NetMgr.PlayerNewsInfo(mPlayerId, mNewsEvent);
		ReceivedNews();
	}
	
	void ReceivedNews(){
		SetInfos();
	}

	void SetInfos(){		
		InitPlayerInfo();
		if(IsInactive) return;

		InitGameLog();
		InitAnalysis();
		InitNews();
		if(IsCard){
			InitCardInfo ();
			transform.FindChild("SelectionForCard").FindChild("BtnCard")
				.GetComponent<PlayerCardSelectionBtns>().SetCard();				
		} else{
			transform.FindChild("SelectionForPlayer").FindChild("BtnGameLog")
				.GetComponent<PlayerCardSelectionBtns>().SetGameLog();
		}
		
		transform.localPosition = Vector3.zero;
		UtilMgr.AddBackState(UtilMgr.STATE.PlayerCard);
	}
}
