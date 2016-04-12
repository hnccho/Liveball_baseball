using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerCard : MonoBehaviour {

	long mPlayerId;
	bool IsPitcher;
	public bool IsCard;
	string mHand;
	public CardInfo mCardInfo;
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

	List<float> mPlayerGraphData;
	List<float> mAvgGraphData;

//	bool IsInactive;
	const float GraphRatioValue = 645.25148676696743f;
	PlayerCardAnimation mPlayerCardAnimation;

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
		mPlayerCardAnimation = transform.GetComponent<PlayerCardAnimation>();
	}
	
	// Update is called once per frame
	void Update () {
//		Mesh m = new Mesh();
//		
//		m.vertices = new Vector3[3]
//		{
//			new Vector3(-.5f, -.5f, 0f),
//			new Vector3( .5f, -.5f, 0f),
//			new Vector3(  0f,  .5f, 0f)
//		};
//		
//		m.triangles = new int[]
//		{
//			0, 1, 2
//		};
//		
//		m.normals = new Vector3[]
//		{
//			Vector3.forward,
//			Vector3.forward,
//			Vector3.forward
//		};
//		
//		Graphics.DrawMeshNow(m, Vector3.zero, Quaternion.identity);
//		
//		DestroyImmediate(m);


		Transform tf = transform.FindChild("Body").FindChild("Changeables").FindChild("Analysis");
		WMG_Radar_Graph radar = tf.FindChild("Radar").FindChild("Canvas").FindChild("RadarGraph").GetComponent<WMG_Radar_Graph>();

		if(mPlayerGraphData == null || mPlayerGraphData.Count < 5){
			tf.FindChild("Radar").FindChild("Canvas").gameObject.SetActive(false);
			return;
		} else{
			tf.FindChild("Radar").FindChild("Canvas").gameObject.SetActive(true);
		}

		if(tf.gameObject.activeSelf){
			if(radar.lineSeries.Count > 0){
				WMG_Series series = radar.lineSeries[0].GetComponent<WMG_Series>();
				series.pointValues.SetList(radar.GenRadar(mAvgGraphData, radar.offset.x, radar.offset.y, radar.degreeOffset));
				series.lineScale = radar.dataSeriesLineWidth;
				series.linePadding = radar.dataSeriesLineWidth;
				series.lineColor = radar.dataSeriesColors[0];

				series = radar.lineSeries[1].GetComponent<WMG_Series>();
				series.pointValues.SetList(radar.GenRadar(mPlayerGraphData, radar.offset.x, radar.offset.y, radar.degreeOffset));
				series.lineScale = radar.dataSeriesLineWidth;
				series.linePadding = radar.dataSeriesLineWidth;
				series.lineColor = radar.dataSeriesColors[1];

				radar.DataSeriesChanged();

//				Debug.Log ("1x : " +
//				radar.GenRadar(mAvgGraphData, radar.offset.x, radar.offset.y, radar.degreeOffset)[0].x
//				           +"m y : " +
//				           radar.GenRadar(mAvgGraphData, radar.offset.x, radar.offset.y, radar.degreeOffset)[0].y);
//				Debug.Log ("2x : " +
//				           radar.GenRadar(mAvgGraphData, radar.offset.x, radar.offset.y, radar.degreeOffset)[1].x
//				           +"m y : " +
//				           radar.GenRadar(mAvgGraphData, radar.offset.x, radar.offset.y, radar.degreeOffset)[1].y);
//				Debug.Log ("3x : " +
//				           radar.GenRadar(mAvgGraphData, radar.offset.x, radar.offset.y, radar.degreeOffset)[2].x
//				           +"m y : " +
//				           radar.GenRadar(mAvgGraphData, radar.offset.x, radar.offset.y, radar.degreeOffset)[2].y);
//				Debug.Log ("4x : " +
//				           radar.GenRadar(mAvgGraphData, radar.offset.x, radar.offset.y, radar.degreeOffset)[3].x
//				           +"m y : " +
//				           radar.GenRadar(mAvgGraphData, radar.offset.x, radar.offset.y, radar.degreeOffset)[3].y);
//				Debug.Log ("5x : " +
//				           radar.GenRadar(mAvgGraphData, radar.offset.x, radar.offset.y, radar.degreeOffset)[4].x
//				           +"m y : " +
//				           radar.GenRadar(mAvgGraphData, radar.offset.x, radar.offset.y, radar.degreeOffset)[4].y);
			}
		}


	}

	public void OnClose(){
		transform.FindChild("Body").FindChild("Changeables").FindChild("Analysis")
			.FindChild("Radar").FindChild("Canvas").gameObject.SetActive(false);
		mPlayerGraphData = null;

		mPlayerCardAnimation.AnimateDisappear();

		UtilMgr.RemoveBackState(UtilMgr.STATE.PlayerCard);
	}

	public void Init(PlayerInfo playerInfo, Texture photo){
		mPlayerInfo = playerInfo;
		mPhoto = photo;
		IsCard = false;
		if(UtilMgr.IsMLB()){
			transform.FindChild("Body").FindChild("Info").FindChild("KBO").FindChild("Panel").FindChild("Photo")
				.GetComponent<UITexture>().width = 135;
			transform.FindChild("Body").FindChild("Info").FindChild("KBO").FindChild("Panel").FindChild("Photo")
				.GetComponent<UITexture>().height = 180;

			transform.FindChild("Body").FindChild("SelectionForPlayer").gameObject.SetActive(true);
			transform.FindChild("Body").FindChild("SelectionForPlayerKBO").gameObject.SetActive(false);
			transform.FindChild("Body").FindChild("SelectionForCard").gameObject.SetActive(false);
			transform.FindChild("Body").FindChild("SelectionForCardKBO").gameObject.SetActive(false);
		} else{
			transform.FindChild("Body").FindChild("SelectionForPlayer").gameObject.SetActive(false);
			transform.FindChild("Body").FindChild("SelectionForPlayerKBO").gameObject.SetActive(true);
			transform.FindChild("Body").FindChild("SelectionForCard").gameObject.SetActive(false);
			transform.FindChild("Body").FindChild("SelectionForCardKBO").gameObject.SetActive(false);
		}
		mPlayerId = playerInfo.playerId;

		CommonInit();
	}

	public void InitWithCard(CardInfo cardInfo, Texture photo){
		mPhoto = photo;
		IsCard = true;
		mCardInfo = cardInfo;

		if(UtilMgr.IsMLB()){			
			transform.FindChild("Body").FindChild("Info").FindChild("KBO").FindChild("Panel").FindChild("Photo")
				.GetComponent<UITexture>().width = 135;
			transform.FindChild("Body").FindChild("Info").FindChild("KBO").FindChild("Panel").FindChild("Photo")
				.GetComponent<UITexture>().height = 180;

			transform.FindChild("Body").FindChild("SelectionForPlayer").gameObject.SetActive(false);
			transform.FindChild("Body").FindChild("SelectionForPlayerKBO").gameObject.SetActive(false);
			transform.FindChild("Body").FindChild("SelectionForCard").gameObject.SetActive(true);
			transform.FindChild("Body").FindChild("SelectionForCardKBO").gameObject.SetActive(false);
		} else{
			transform.FindChild("Body").FindChild("SelectionForPlayer").gameObject.SetActive(false);
			transform.FindChild("Body").FindChild("SelectionForPlayerKBO").gameObject.SetActive(false);
			transform.FindChild("Body").FindChild("SelectionForCard").gameObject.SetActive(false);
			transform.FindChild("Body").FindChild("SelectionForCardKBO").gameObject.SetActive(true);
		}

		mPlayerId = cardInfo.playerFK;
		CommonInit();
	}

	void CommonInit(){
//		IsInactive = false;
		mSeasonEvent = null;
		mNewsEvent = null;
		mGameEvent = null;

		mPlayerCardAnimation.AppearBack();
//		GetInfos();
		if(InitPlayerInfo()) return;

		InitNewType();
	}

	void InitNewType(){

		if(IsCard){
			if(UtilMgr.IsMLB()){
				transform.FindChild("Body").FindChild("SelectionForCard").FindChild("BtnCard")
					.GetComponent<PlayerCardSelectionBtns>().SetCard();				
			} else
				transform.FindChild("Body").FindChild("SelectionForCardKBO").FindChild("BtnCard")
					.GetComponent<PlayerCardSelectionBtns>().SetCard();				
		} else{
			if(UtilMgr.IsMLB()){
				transform.FindChild("Body").FindChild("SelectionForPlayer").FindChild("BtnGameLog")
					.GetComponent<PlayerCardSelectionBtns>().SetGameLog();
			} else
				transform.FindChild("Body").FindChild("SelectionForPlayerKBO").FindChild("BtnGameLog")
					.GetComponent<PlayerCardSelectionBtns>().SetGameLog();
		}
	}

	public void SetGameLog(){
		if(mGameEvent == null){
			mGameEvent = new PlayerGameInfoEvent(InitGameLog);
			NetMgr.PlayerGameInfo(mPlayerId, mGameEvent);
		} else{
			InitGameLog();
		}
	}

	public void SetAnalysis(){
		if(mSeasonEvent == null){
			mSeasonEvent = new PlayerSeasonInfoEvent(ReceivedSeason2);
			NetMgr.PlayerSeasonInfo(mPlayerId, mSeasonEvent);
		} else{
			InitAnalysis();
		}
	}

	void ReceivedSeason2(){
		if(mGameEvent == null){
			mGameEvent = new PlayerGameInfoEvent(InitAnalysis);
			NetMgr.PlayerGameInfo(mPlayerId, mGameEvent);
		} else{
			InitAnalysis();
		}
	}
	
	public void SetNews(){
		if(mNewsEvent == null){
			mNewsEvent = new PlayerNewsInfoEvent(InitNews);
			NetMgr.PlayerNewsInfo(mPlayerId, mNewsEvent);
		} else{
			InitNews();
		}
	}

	void InitGameLog(){
		transform.FindChild("Body").FindChild("Changeables").FindChild("GameLog").gameObject.SetActive(true);
		UtilMgr.ClearList(
			transform.FindChild("Body").FindChild("Changeables").FindChild("GameLog").FindChild("Scroll View"));

		string month = "";
		float height = 390f;
		int colorIndicator = 0;
		for(int i = 0; i < mGameEvent.Response.data.Count; i++){
			GameObject go = null;
			PlayerGameInfo info = mGameEvent.Response.data[i];
			if(!month.Equals(info.month)){
				month = info.month;
				colorIndicator = 0;
				go = Instantiate(mItemGameMonth);
				go.transform.parent = transform.FindChild("Body").FindChild("Changeables").FindChild("GameLog").FindChild("Scroll View");
				height -= 30f;
				go.transform.localPosition = new Vector3(0, height);
				height -= 30f;
				go.transform.localScale = new Vector3(1f, 1f, 1f);
				go.transform.FindChild("Label").GetComponent<UILabel>().text = info.month;

				if(IsPitcher)
					go = Instantiate(mItemGameArticlesP);
				else
					go = Instantiate(mItemGameArticlesH);

				go.transform.parent = transform.FindChild("Body").FindChild("Changeables").FindChild("GameLog").FindChild("Scroll View");
				height -= 25f;
				go.transform.localPosition = new Vector3(0, height);
				height -= 25f;
				go.transform.localScale = new Vector3(1f, 1f, 1f);
			}
			if(IsPitcher)
				go = Instantiate(mItemGameSubP);
			else
				go = Instantiate(mItemGameSubH);
			
			go.transform.parent = transform.FindChild("Body").FindChild("Changeables").FindChild("GameLog").FindChild("Scroll View");
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
		transform.FindChild("Body").FindChild("Changeables").FindChild("GameLog").FindChild("Scroll View")
			.GetComponent<UIScrollView>().ResetPosition();
	}
	
	void InitAnalysis(){
		if(mSeasonEvent.Response.data == null)
			return;

		Transform tf = transform.FindChild("Body").FindChild("Changeables").FindChild("Analysis");
		tf.gameObject.SetActive(true);

//		MeshFilter meshFilter = this.gameObject.AddComponent<MeshFilter>();		
//		MeshRenderer meshRenderer = this.gameObject.AddComponent<MeshRenderer>();		
//		Mesh mesh = new Mesh();
//		
//		//정점 설정
//		mesh.vertices = new Vector3[]
//		{
//			new Vector3(-1, 0, 0), new Vector3(-0.2f, 0.5f, 0), new Vector3(0.4f, 0.7f, 0),
//			new Vector3(1, 0, 0), new Vector3(0, -0.5f, 0)
//		};
//		
//		//UV 설정
//		mesh.uv = new Vector2[]
//		{
//			new Vector2(0.0f, 1.0f), new Vector2(0.5f, 1.0f), new Vector2(1.0f, 0.5f),
//			new Vector2(0.0f, 0.0f), new Vector2(1.0f, 0.0f)
//		};
//		
//		//삼각형 그리는 순서 설정
//		mesh.triangles = new int[]{0,1,2,2,3,0,0,3,4};
//		mesh.RecalculateNormals();
//		meshFilter.mesh = mesh;
//		tf.FindChild("Radar").FindChild("Canvas").FindChild("LineGraph").FindChild("Serires").FindChild("Series1")
//			.GetComponent<WMG_Series>().pointValues
//		int heightDiff = 1280 - Screen.height;
//		Debug.Log("RatioY is "+ UtilMgr.GetScaledPositionY());
//		float rePos =  * UtilMgr.GetScaledPositionY();
		tf.FindChild("Radar").FindChild("Canvas").FindChild("RadarGraph").GetComponent<RectTransform>()
			.localPosition = new Vector3(0, -(GraphRatioValue*UtilMgr.GetScaledPositionY()), 0);
		tf.FindChild("Radar").FindChild("Canvas").FindChild("LineGraph").GetComponent<RectTransform>()
			.localPosition = new Vector3(171000f, (114000f-(GraphRatioValue*UtilMgr.GetScaledPositionY())), 0);

		tf.FindChild("Radar").FindChild("Canvas").FindChild("LineGraph").FindChild("Series").FindChild("Series1")
			.GetComponent<WMG_Series>().pointValues.Clear();
//		tf.FindChild("Radar").FindChild("Canvas").FindChild("LineGraph").FindChild("Series").FindChild("Series1")
//			.GetComponent<WMG_Series>().pointValues.Insert(0, new Vector2(mPlayerInfo.fppg, 0));

		if(mGameEvent.Response.data != null 
		   && mGameEvent.Response.data.Count > 1){
			int count = 0;
			for(int i = mGameEvent.Response.data.Count-1; i >= 0; i--, count++){
				if(count > 9) break;

				float fp = float.Parse(mGameEvent.Response.data[i].FP);
				float diff = fp - mPlayerInfo.fppg;
				diff = diff > 10f ? 10f : diff < -10f ? -10f : diff;
				tf.FindChild("Radar").FindChild("Canvas").FindChild("LineGraph").FindChild("Series").FindChild("Series1")
					.GetComponent<WMG_Series>().pointValues.Add(new Vector2(0, diff));
			}
		}

		tf.FindChild("Radar").FindChild("Canvas").FindChild("LineGraph").GetComponent<WMG_Axis_Graph>().SeriesChanged(true);

		mPlayerGraphData = null;
		mAvgGraphData = null;
		if(mPlayerInfo.positionNo == 1){
			tf.FindChild("Radar").FindChild("LblContact").GetComponent<UILabel>().text = UtilMgr.GetLocalText("StrStamina");
			tf.FindChild("Radar").FindChild("LblSpeed").GetComponent<UILabel>().text = UtilMgr.GetLocalText("StrBallPower");
			tf.FindChild("Radar").FindChild("LblBattingEye").GetComponent<UILabel>().text = UtilMgr.GetLocalText("StrControl");
			tf.FindChild("Radar").FindChild("LblConcentration").GetComponent<UILabel>().text = UtilMgr.GetLocalText("StrCrisisManagement");
			tf.FindChild("Radar").FindChild("LblPower").GetComponent<UILabel>().text = UtilMgr.GetLocalText("StrGameManagement");
		} else{
			tf.FindChild("Radar").FindChild("LblContact").GetComponent<UILabel>().text = UtilMgr.GetLocalText("LblContact");
			tf.FindChild("Radar").FindChild("LblSpeed").GetComponent<UILabel>().text = UtilMgr.GetLocalText("LblRunningSpeed");
			tf.FindChild("Radar").FindChild("LblBattingEye").GetComponent<UILabel>().text = UtilMgr.GetLocalText("LblBattingEye");
			tf.FindChild("Radar").FindChild("LblConcentration").GetComponent<UILabel>().text = UtilMgr.GetLocalText("LblConcentration");
			tf.FindChild("Radar").FindChild("LblPower").GetComponent<UILabel>().text = UtilMgr.GetLocalText("LblPower");
		}

		mAvgGraphData = GetGraphData(mPlayerInfo, mSeasonEvent.Response.data.statsAvg);
		mPlayerGraphData = GetGraphData(mPlayerInfo, mSeasonEvent.Response.data.graph);
//		float value = 100f;
//		mAvgGraphData = new List<float>();
//		mPlayerGraphData = new List<float>();
//		mAvgGraphData.Add(value);mAvgGraphData.Add(value);mAvgGraphData.Add(value);mAvgGraphData.Add(value);mAvgGraphData.Add(value);
//		mPlayerGraphData.Add(10f);mPlayerGraphData.Add(10f);mPlayerGraphData.Add(10f);mPlayerGraphData.Add(10f);mPlayerGraphData.Add(10f);

		string[] names;
		string[] values;

		if(IsPitcher){
			names = new string[]{"W", "L", "SV", "IP", "ERA", "PH", "ER", "BB", "SO", "PHR", "WHIP", "PBAA"};
			values = new string[]{
				mSeasonEvent.Response.data.stats.W,
				mSeasonEvent.Response.data.stats.L,
				mSeasonEvent.Response.data.stats.SV,
				mSeasonEvent.Response.data.stats.IP,
				mSeasonEvent.Response.data.stats.ERA,
				mSeasonEvent.Response.data.stats.PH,
				mSeasonEvent.Response.data.stats.ER,
				mSeasonEvent.Response.data.stats.BB,
				mSeasonEvent.Response.data.stats.SO,
				mSeasonEvent.Response.data.stats.PHR,
				mSeasonEvent.Response.data.stats.WHIP,
				mSeasonEvent.Response.data.stats.PBAA};
		} else{
			names = new string[]{"AVG", "HR", "RBI", "R", "H", "OBP", "SLG", "OPS", "SB", "CS", "BB", "HBP"};
			values = new string[]{
				mSeasonEvent.Response.data.stats.AVG,
				mSeasonEvent.Response.data.stats.HR,
				mSeasonEvent.Response.data.stats.RBI,
				mSeasonEvent.Response.data.stats.R,
				mSeasonEvent.Response.data.stats.H,
				mSeasonEvent.Response.data.stats.OBP,
				mSeasonEvent.Response.data.stats.SLG,
				mSeasonEvent.Response.data.stats.OPS,
				mSeasonEvent.Response.data.stats.SB,
				mSeasonEvent.Response.data.stats.CS,
				mSeasonEvent.Response.data.stats.BB,
				mSeasonEvent.Response.data.stats.HBP};
		}

		for(int i = 0; i < 12; i++){
			tf.transform.FindChild("Season").FindChild(""+(i+1)).FindChild("Name").GetComponent<UILabel>().text
				= names[i];
			tf.transform.FindChild("Season").FindChild(""+(i+1)).FindChild("Value").GetComponent<UILabel>().text
				= values[i];
		}

	}
	
	public void InitCardInfo(){
		Transform tf = transform.FindChild("Body").FindChild("Changeables").FindChild("Card");
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

		tf.FindChild("Btm").FindChild("Pack").gameObject.SetActive(false);
		tf.FindChild("Btm").FindChild("Upgrade").gameObject.SetActive(true);
	}

	bool InitPlayerInfo(){
//		if(UtilMgr.IsMLB()){
//			transform.FindChild("Info").FindChild ("MLB").gameObject.SetActive(true);
//			transform.FindChild("Info").FindChild ("KBO").gameObject.SetActive(false);
//
//			transform.FindChild("Info").FindChild ("MLB").FindChild("Panel").FindChild("Photo").GetComponent<UITexture>().mainTexture = mPhoto;
//		} else{
			transform.FindChild("Body").FindChild("Info").FindChild ("MLB").gameObject.SetActive(false);
			transform.FindChild("Body").FindChild("Info").FindChild ("KBO").gameObject.SetActive(true);

			transform.FindChild("Body").FindChild("Info").FindChild ("KBO").FindChild("Panel").FindChild("Photo").GetComponent<UITexture>().mainTexture = mPhoto;
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
//			IsInactive = true;
			DialogueMgr.ShowDialogue(UtilMgr.GetLocalText("StrPlayerInfo"), UtilMgr.GetLocalText("StrPlayerInactive")
			                         ,DialogueMgr.DIALOGUE_TYPE.Alert, null);
			return true;
		}

		if(mPlayerInfo.injuryYN.Equals("N"))
			transform.FindChild("Body").FindChild("Info").FindChild("Injury").gameObject.SetActive(false);
		else
			transform.FindChild("Body").FindChild("Info").FindChild("Injury").gameObject.SetActive(true);

		if(UtilMgr.IsMLB()){
			if(mPlayerInfo.firstName.Length < 1){
				transform.FindChild("Body").FindChild("Info").FindChild("LblName").GetComponent<UILabel>().text
					= mPlayerInfo.lastName;
			} else{
				transform.FindChild("Body").FindChild("Info").FindChild("LblName").GetComponent<UILabel>().text
					= mPlayerInfo.firstName.Substring(0, 1) + ". " + mPlayerInfo.lastName;
			}
		} else{
			if(Localization.language.Equals("English")){
				if(mPlayerInfo.firstName.Length < 1){
					transform.FindChild("Body").FindChild("Info").FindChild("LblName").GetComponent<UILabel>().text
						= mPlayerInfo.lastName;
				} else{
					transform.FindChild("Body").FindChild("Info").FindChild("LblName").GetComponent<UILabel>().text
						= mPlayerInfo.firstName.Substring(0, 1) + ". " + mPlayerInfo.lastName;
				}
			} else{
				transform.FindChild("Body").FindChild("Info").FindChild("LblName").GetComponent<UILabel>().text
					= mPlayerInfo.korName;
			}
		}

		transform.FindChild("Body").FindChild("Info").FindChild("LblSaraly").GetComponent<UILabel>().text
			= IsCard ? "[s]$" + mPlayerInfo.salary : "$" + mPlayerInfo.salary;
		transform.FindChild("Body").FindChild("Info").FindChild("LblFPPG").FindChild("Label").GetComponent<UILabel>().text
			= string.Format("{0:F1}", mPlayerInfo.fppg);
		transform.FindChild("Body").FindChild("Info").FindChild("LblPlayed").FindChild("Label").GetComponent<UILabel>().text
			= "" + mPlayerInfo.games;
		transform.FindChild("Body").FindChild("Info").FindChild("SprPos").FindChild("Label").GetComponent<UILabel>().text
			= mPlayerInfo.position;

		if(IsCard){
			transform.FindChild("Body").FindChild("SprGrade").GetComponent<UISprite>().spriteName = "card_top_bg_"+mCardInfo.cardClass;
			transform.FindChild("Body").FindChild("SprGrade").gameObject.SetActive(true);
		} else
			transform.FindChild("Body").FindChild("SprGrade").gameObject.SetActive(false);

		TeamScheduleInfo schedule = null;
		foreach(TeamScheduleInfo info in UserMgr.ScheduleList){
			if(mPlayerInfo.team == info.awayTeamId
			   || mPlayerInfo.team == info.homeTeamId){
				schedule = info;
				break;
			}
		}

		if(schedule != null){
			transform.FindChild("Body").FindChild("Info").FindChild("LblPos").GetComponent<UILabel>().text
				= schedule.awayTeam + "   @   " + schedule.homeTeam;

			int hour = 1;
			string min = "";
			if(UtilMgr.IsMLB()){
				hour = int.Parse(schedule.dateTime.Substring(8, 2));
				min = schedule.dateTime.Substring(10, 2);
				transform.FindChild("Body").FindChild("Info").FindChild("LblTime").GetComponent<UILabel>().text
					= schedule.day + " ET " + UtilMgr.GetAMPM(hour)[0] + ":" + min + " " + UtilMgr.GetAMPM(hour)[1];
			} else{
				hour = int.Parse(schedule.korDateTime.Substring(8, 2));
				min = schedule.korDateTime.Substring(10, 2);
				if(Localization.language.Equals("English")){
					transform.FindChild("Body").FindChild("Info").FindChild("LblTime").GetComponent<UILabel>().text
						= schedule.day + " KST " + UtilMgr.GetAMPM(hour)[0] + ":" + min + " " + UtilMgr.GetAMPM(hour)[1];
				} else{
					transform.FindChild("Body").FindChild("Info").FindChild("LblTime").GetComponent<UILabel>().text
						= "KST " + UtilMgr.GetAMPM(hour)[0] + ":" + min + " " +
							UtilMgr.GetAMPM(hour)[1] +  " (" + UtilMgr.DayToKorean(schedule.day) + ")";
				}
			}

		}

		return false;
	}

	void InitNews(){

	}

	void GetInfos(){		
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
//		if(IsInactive) return;

		InitGameLog();
		InitAnalysis();
		InitNews();
		if(IsCard){
			InitCardInfo ();
			if(UtilMgr.IsMLB()){
				transform.FindChild("Body").FindChild("SelectionForCard").FindChild("BtnCard")
					.GetComponent<PlayerCardSelectionBtns>().SetCard();				
			} else
				transform.FindChild("Body").FindChild("SelectionForCardKBO").FindChild("BtnCard")
					.GetComponent<PlayerCardSelectionBtns>().SetCard();				
		} else{
			if(UtilMgr.IsMLB()){
				transform.FindChild("Body").FindChild("SelectionForPlayer").FindChild("BtnGameLog")
					.GetComponent<PlayerCardSelectionBtns>().SetGameLog();
			} else
				transform.FindChild("Body").FindChild("SelectionForPlayerKBO").FindChild("BtnGameLog")
					.GetComponent<PlayerCardSelectionBtns>().SetGameLog();
		}

//		DisappearBack();
		transform.GetComponent<PlayerCardAnimation>().CanOpen = true;
	}

	List<float> GetGraphData(PlayerInfo player, PlayerSeasonInfo.GraphInfo graphInfo){
		List<float> data = new List<float>();
		float[][] graphArr = null;
		float[] myArr = new float[5];
		if(player.positionNo == 1){
			myArr[0] = float.Parse(graphInfo.stamina);
			myArr[1] = float.Parse(graphInfo.riskMng);
			myArr[2] = float.Parse(graphInfo.ballPower);
			myArr[3] = float.Parse(graphInfo.control);
			myArr[4] = float.Parse(graphInfo.gameMng);

			graphArr = new float[5][]{
				new float[]{0.6f, 1.1f, 1.6f, 2.1f, 3.1f, 4.1f, 5.1f, 5.6f, 6.1f, float.MinValue},
				new float[]{5.5f, 5.0f, 4.5f, 4.0f, 3.6f, 3.2f, 2.9f, 2.6f, 2.4f, float.MaxValue},
				new float[]{0.21f, 0.41f, 0.51f, 0.61f, 0.71f, 0.91f, 1.01f, 1.11f, 1.21f, float.MinValue},
				new float[]{0.601f, 0.611f, 0.621f, 0.631f, 0.641f, 0.651f, 0.661f, 0.671f, 0.681f, float.MinValue},
				new float[]{0.4f, 0.38f, 0.36f, 0.34f, 0.32f, 0.3f, 0.28f, 0.26f, 0.24f, float.MaxValue}
			};
		} else{
			myArr[0] = float.Parse(graphInfo.contact);
			myArr[1] = float.Parse(graphInfo.concentration);
			myArr[2] = float.Parse(graphInfo.runSpeed);
			myArr[3] = float.Parse(graphInfo.battingEye);
			myArr[4] = float.Parse(graphInfo.power);

			graphArr = new float[5][]{
				new float[]{0.101f, 0.151f, 0.201f, 0.241f, 0.261f, 0.281f, 0.291f, 0.301f, 0.311f, float.MinValue},
				new float[]{0.03f, 0.05f, 0.07f, 0.09f, 0.11f, 0.13f, 0.15f, 0.17f, 0.19f, float.MinValue},
				new float[]{0.06f, 0.11f, 0.16f, 0.21f, 0.26f, 0.31f, 0.41f, 0.46f, 0.51f, float.MinValue},
				new float[]{0.101f, 0.151f, 0.201f, 0.241f, 0.281f, 0.321f, 0.351f, 0.381f, 0.401f, float.MinValue},
				new float[]{0.101f, 0.201f, 0.301f, 0.351f, 0.401f, 0.451f, 0.501f, 0.551f, 0.601f, float.MinValue}
			};
		}

		for(int i = 0; i < graphArr.Length; i++){
			bool noHave = true;
			float value = 0;
			if(graphArr[i][graphArr[i].Length-1] == float.MaxValue){
				for(int j = 0; j < graphArr[i].Length; j++){
					if(myArr[i] > graphArr[i][j]){
						value = (float)((j+1)*10);
						noHave = false;
						break;
					}
				}
			} else{
				for(int j = 0; j < graphArr[i].Length; j++){
					if(myArr[i] < graphArr[i][j]){
						value = (float)((j+1)*10);
						noHave = false;
						break;
					}
				}
			}

			if(noHave)
				value = 100f;
			data.Add(value);
		}

		return data;
	}

}
