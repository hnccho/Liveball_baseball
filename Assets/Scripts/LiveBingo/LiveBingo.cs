using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LiveBingo : MonoBehaviour {

	public GameObject mItemBingo;
	public GameObject mItemBingoList;
	Vector3 StartPos = new Vector3(-220f, 220f);
	const float WidthFixed = 146.6f;
	const int RowFixed = 4;
	GetBingoEvent mBingoEvent;
	public GetCurrentLineupEvent mLineupEvent;
	CallBingoEvent mCallEvent;
	int mBingoId;
	bool IsReload;
	int mCanGet;

	public Dictionary<int, ItemBingo> mItemDic;
	List<PlayerInfo> mSortedLineup;
	PlayerInfo mPitcher;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Init(){
		IsReload = false;
		ClearBoard();
		mItemDic = new Dictionary<int, ItemBingo>();
		transform.GetComponent<LiveBingoAnimation>().Init();
		transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("Sprite")
			.FindChild("NotReady").gameObject.SetActive(false);

		NetMgr.JoinGame();

		mBingoEvent = new GetBingoEvent(ReceivedBingo);
		NetMgr.GetBingo(UserMgr.eventJoined.gameId, mBingoEvent);
	}

	void ReceivedBingo(){
		if(mBingoEvent.Response.data.bingo == null){
			SetNotReady();
			return;
		}
		mCanGet = mBingoEvent.Response.data.bingo.bingos - mBingoEvent.Response.data.bingo.rewardedCount;

		mLineupEvent = new GetCurrentLineupEvent(ReceivedLineup);
		NetMgr.GetCurrentLineup(UserMgr.eventJoined.gameId, UserMgr.eventJoined.inning,
		                        mBingoEvent.Response.data.bingo.bingoId, mLineupEvent);
	}

	void ReceivedLineup(){

		mLineupEvent.Response.data.forecast.Sort(
			delegate(CurrentLineupInfo.ForecastInfo x, CurrentLineupInfo.ForecastInfo y) {
			return x.inningNumber.CompareTo(y.inningNumber);
		});

		if(!IsReload){
			transform.FindChild("Body").FindChild("Scroll View").FindChild("Board")
				.FindChild("BG").FindChild("Sprite").gameObject.SetActive(false);
			transform.FindChild("Body").FindChild("Scroll View").FindChild("Board")
				.FindChild("BG").FindChild("Sprite").GetComponent<UISprite>().height = 0;
		}

		transform.GetComponent<LiveBingoAnimation>().SetGauge(mLineupEvent.Response.data.powerGauge, IsReload);

		if(mBingoEvent.Response.data.bingoBoard.Count < 16){
			DialogueMgr.ShowDialogue("Error", "Bingo has less than 16 tiles", DialogueMgr.DIALOGUE_TYPE.Alert, null);
			return;
		}

		mBingoId = mBingoEvent.Response.data.bingoBoard[0].bingoId;

		int row = 0, col = -1;
		for(int i = 0; i < 16; i++){
			//row col swapped
			if(i % 4 == 0){
				col++; row = -1;
			}
			row++;

			if(IsReload){
				ItemBingo tile = transform.FindChild("Body").FindChild("Scroll View").FindChild("Board")
					.FindChild("Items").GetChild(i).GetComponent<ItemBingo>();
				tile.mNewBingoBoard = mBingoEvent.Response.data.bingoBoard[i];
				tile.Init(IsReload);
				continue;
			}

			GameObject item = Instantiate(mItemBingo);
			item.transform.parent = transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("Items");
			item.transform.localScale = new Vector3(1f, 1f, 1f);
			item.name = mBingoEvent.Response.data.bingoBoard[i].tailId+"";

			item.transform.localPosition = new Vector3(StartPos.x + (WidthFixed * col), StartPos.y - (WidthFixed * row));

			ItemBingo itemBingo = item.GetComponent<ItemBingo>();
			itemBingo.mNewBingoBoard = mBingoEvent.Response.data.bingoBoard[i];
			itemBingo.Init(IsReload);

//			if(!IsReload)
				mItemDic.Add(mBingoEvent.Response.data.bingoBoard[i].tailId, item.GetComponent<ItemBingo>());
		}
		InitTop();
		InitBtm();
		InitBingoBtn();
		InitResetBtn();

		ShowNext();
	}

	public void BingoClick(){
		mCallEvent = new CallBingoEvent(ReceivedCall);
		NetMgr.CallBingo(UserMgr.eventJoined.gameId, mBingoEvent.Response.data.bingo.bingoId
		                 ,mLineupEvent.Response.data.inningNumber, mCallEvent);
	}

	void ReceivedCall(){
		int total = mCallEvent.Response.data.totalRewardGold + mCallEvent.Response.data.userBlackBingoReward;
		DialogueMgr.ShowDialogue("Bingo", "You received compensation of "+total+"gold!"
		                         , DialogueMgr.DIALOGUE_TYPE.Alert, null);
		Reload();
	}

	public void ResetClick(){
//		Reload();
	}

	public void CheckBingo(){
		bool isBlack = true;
		
		foreach(ItemBingo item in mItemDic.Values){
			if(!item.IsCorrected){
				isBlack = false;
				break;
			}
		}
		
		if(isBlack){
			transform.GetComponent<LiveBingoAnimation>().ShowBlackBingo();
			return;
		}
		
		if(mItemDic[11].IsCorrected && mItemDic[21].IsCorrected && mItemDic[31].IsCorrected && mItemDic[41].IsCorrected)
			transform.GetComponent<LiveBingoAnimation>().ShowBingoAni("11to41");
		if(mItemDic[12].IsCorrected && mItemDic[22].IsCorrected && mItemDic[32].IsCorrected && mItemDic[42].IsCorrected)
			transform.GetComponent<LiveBingoAnimation>().ShowBingoAni("12to42");
		if(mItemDic[13].IsCorrected && mItemDic[23].IsCorrected && mItemDic[33].IsCorrected && mItemDic[43].IsCorrected)
			transform.GetComponent<LiveBingoAnimation>().ShowBingoAni("13to43");
		if(mItemDic[14].IsCorrected && mItemDic[24].IsCorrected && mItemDic[34].IsCorrected && mItemDic[44].IsCorrected)
			transform.GetComponent<LiveBingoAnimation>().ShowBingoAni("14to44");
		if(mItemDic[11].IsCorrected && mItemDic[12].IsCorrected && mItemDic[13].IsCorrected && mItemDic[14].IsCorrected)
			transform.GetComponent<LiveBingoAnimation>().ShowBingoAni("11to14");
		if(mItemDic[21].IsCorrected && mItemDic[22].IsCorrected && mItemDic[23].IsCorrected && mItemDic[24].IsCorrected)
			transform.GetComponent<LiveBingoAnimation>().ShowBingoAni("21to24");
		if(mItemDic[31].IsCorrected && mItemDic[32].IsCorrected && mItemDic[33].IsCorrected && mItemDic[34].IsCorrected)
			transform.GetComponent<LiveBingoAnimation>().ShowBingoAni("31to34");
		if(mItemDic[41].IsCorrected && mItemDic[42].IsCorrected && mItemDic[43].IsCorrected && mItemDic[44].IsCorrected)
			transform.GetComponent<LiveBingoAnimation>().ShowBingoAni("41to44");
		if(mItemDic[11].IsCorrected && mItemDic[22].IsCorrected && mItemDic[33].IsCorrected && mItemDic[44].IsCorrected)
			transform.GetComponent<LiveBingoAnimation>().ShowBingoAni("11to44");
		if(mItemDic[14].IsCorrected && mItemDic[23].IsCorrected && mItemDic[32].IsCorrected && mItemDic[41].IsCorrected)
			transform.GetComponent<LiveBingoAnimation>().ShowBingoAni("14to41");
	}

	void InitTop(){
		Transform score = transform.FindChild("Top").FindChild("Score");
		score.FindChild("AwayScore").GetComponent<UILabel>().text = mLineupEvent.Response.data.awayTeamRuns+"";
		score.FindChild("HomeScore").GetComponent<UILabel>().text = mLineupEvent.Response.data.homeTeamRuns+"";
		score.FindChild("AwayName").GetComponent<UILabel>().text = UserMgr.eventJoined.awayTeam;
		score.FindChild("HomeName").GetComponent<UILabel>().text = UserMgr.eventJoined.homeTeam;
		if(mLineupEvent.Response.data.inningHalf.Equals("T")){
			score.FindChild("AwayName").FindChild("Sprite").gameObject.SetActive(true);
			score.FindChild("HomeName").FindChild("Sprite").gameObject.SetActive(false);
			int width = score.FindChild("AwayName").GetComponent<UILabel>().width;
			score.FindChild("AwayName").FindChild("Sprite").localPosition = new Vector3(-(width+20), 0, 0);
		} else{
			score.FindChild("AwayName").FindChild("Sprite").gameObject.SetActive(false);
			score.FindChild("HomeName").FindChild("Sprite").gameObject.SetActive(true);
			int width = score.FindChild("HomeName").GetComponent<UILabel>().width;
			score.FindChild("HomeName").FindChild("Sprite").localPosition = new Vector3((width+20), 0, 0);
		}

	}

	void InitBtm(){
		Transform btm = transform.FindChild("Body").FindChild("Scroll View").FindChild("Btm");

		mSortedLineup = new List<PlayerInfo>();
		bool foundLast = false;
		if(mLineupEvent.Response.data.inningHalf.Equals("T")){
			mPitcher = mLineupEvent.Response.data.home.pit;
			for(int i = 0; i < mLineupEvent.Response.data.away.hit.Count; i++){
				if(mLineupEvent.Response.data.away.hit[i].lastBatter > 0){
					foundLast = true;
					for(int j = 0; j < mLineupEvent.Response.data.away.hit.Count; j++){
//						if(++i >= mLineupEvent.Response.data.away.hit.Count) i = 0;
						if(i >= mLineupEvent.Response.data.away.hit.Count) i = 0;
						mSortedLineup.Add(mLineupEvent.Response.data.away.hit[i]);
						i++;
					}
					break;
				}
			}
			if(!foundLast){
				for(int j = 0; j < mLineupEvent.Response.data.away.hit.Count; j++){
					mSortedLineup.Add(mLineupEvent.Response.data.away.hit[j]);
				}
			}
		} else{
			mPitcher = mLineupEvent.Response.data.away.pit;
			for(int i = 0; i < mLineupEvent.Response.data.home.hit.Count; i++){
				if(mLineupEvent.Response.data.home.hit[i].lastBatter > 0){
					foundLast = true;
					for(int j = 0; j < mLineupEvent.Response.data.home.hit.Count; j++){
//						if(++i >= mLineupEvent.Response.data.home.hit.Count) i = 0;
						if(i >= mLineupEvent.Response.data.home.hit.Count) i = 0;
						mSortedLineup.Add(mLineupEvent.Response.data.home.hit[i]);
						i++;
					}
					break;
				}
			}
			if(!foundLast){
				for(int j = 0; j < mLineupEvent.Response.data.home.hit.Count; j++){
					mSortedLineup.Add(mLineupEvent.Response.data.home.hit[j]);
				}
			}
		}

		btm.FindChild("Info").FindChild("BG").FindChild("LblRound").gameObject.SetActive(true);
		btm.FindChild("Info").FindChild("BG").FindChild("LblName").gameObject.SetActive(true);
		if(Localization.language.Equals("English")){
			string roundStr = mLineupEvent.Response.data.inningHalf.Equals("T") ? "Top" : "Bot";
			roundStr += " "+mLineupEvent.Response.data.inningNumber + UtilMgr.GetRoundString(mLineupEvent.Response.data.inningNumber);
			btm.FindChild("Info").FindChild("BG").FindChild("LblRound").GetComponent<UILabel>().text = roundStr;
			btm.FindChild("Info").FindChild("BG").FindChild("LblName").GetComponent<UILabel>().text
				= mPitcher.playerName;
		} else{
			string roundStr = mLineupEvent.Response.data.inningNumber
					+ (mLineupEvent.Response.data.inningHalf.Equals("T") ? "회초" : "회말");
			btm.FindChild("Info").FindChild("BG").FindChild("LblRound").GetComponent<UILabel>().text = roundStr;			
			btm.FindChild("Info").FindChild("BG").FindChild("LblName").GetComponent<UILabel>().text
				= mPitcher.korName;
		}

		int width = btm.FindChild("Info").FindChild("BG").FindChild("LblName").GetComponent<UILabel>().width;
		btm.FindChild("Info").FindChild("BG").FindChild("LblName").FindChild("Label").localPosition = new Vector3(width+16f, -3f);
		btm.FindChild("Info").FindChild("BG").FindChild("LblName").FindChild("Label").GetComponent<UILabel>()
			.text = "#" + mPitcher.backNumber + " ERA " + mPitcher.ERA;
		btm.FindChild("Info").FindChild("SprCircle").FindChild("Hand").FindChild("Label").GetComponent<UILabel>()
			.text = mPitcher.throwHand;
		btm.FindChild("Info").FindChild("SprCircle").FindChild("Photo").FindChild("Panel")
			.FindChild("Texture").GetComponent<UITexture>().width = 72;
		btm.FindChild("Info").FindChild("SprCircle").FindChild("Photo").FindChild("Panel")
			.FindChild("Texture").GetComponent<UITexture>().height = 90;
				UtilMgr.LoadImage(mPitcher.photoUrl,
		                  btm.FindChild("Info").FindChild("SprCircle").FindChild("Photo").FindChild("Panel")
		                  .FindChild("Texture").GetComponent<UITexture>());
				
		btm.FindChild("Draggable").GetComponent<UIDraggablePanel2>().RemoveAll();
//		UtilMgr.ClearList(btm.FindChild("Draggable"));
		btm.FindChild("Draggable").GetComponent<UIPanel>().clipOffset = new Vector2(0, 50f);
		btm.FindChild("Draggable").localPosition = new Vector3(0, -283f);
		btm.FindChild("Draggable").GetComponent<UIDraggablePanel2>().Init (mSortedLineup.Count, delegate(UIListItem item, int index) {
			Transform button = item.Target.transform.FindChild("Scroll View").FindChild("Button");
			button.FindChild("Photo").FindChild("Hand").FindChild("Label").GetComponent<UILabel>()
				.text = mSortedLineup[index].batHand;
			button.FindChild("Label").GetComponent<UILabel>()
				.text = "#" + mSortedLineup[index].backNumber + " AVG " + mSortedLineup[index].AVG;
			
			if(Localization.language.Equals("English")){
				button.FindChild("LblName").GetComponent<UILabel>()
					.text = mSortedLineup[index].playerName;
			} else{
				button.FindChild("LblName").GetComponent<UILabel>()
					.text = mSortedLineup[index].korName;
			}
			button.FindChild("Photo").FindChild("Panel").FindChild("Texture").GetComponent<UITexture>().mainTexture
				= UtilMgr.GetTextureDefault();
			button.FindChild("Photo").FindChild("Panel").FindChild("Texture").GetComponent<UITexture>().width = 72;
			button.FindChild("Photo").FindChild("Panel").FindChild("Texture").GetComponent<UITexture>().height = 90;
			UtilMgr.LoadImage(mSortedLineup[index].photoUrl,
			                  button.FindChild("Photo").FindChild("Panel").FindChild("Texture").GetComponent<UITexture>());

			JoinQuizInfo joinInfo = new JoinQuizInfo();
			joinInfo.gameId = UserMgr.eventJoined.gameId;
			joinInfo.bingoId = mBingoId;
			joinInfo.inningNumber = mLineupEvent.Response.data.inningNumber;
			joinInfo.inningHalf = mLineupEvent.Response.data.inningHalf;
			joinInfo.battingOrder = mSortedLineup[index].battingOrder;
			joinInfo.playerId = mSortedLineup[index].playerId;
			//
//			joinInfo.checkValue = -1;
//			foreach(CurrentLineupInfo.ForecastInfo forecast in mLineupEvent.Response.data.forecast){
//				if(forecast.battingOrder == joinInfo.battingOrder){
//					joinInfo.checkValue = forecast.myValue;
//					break;
//				}
//			}
			//
			item.Target.GetComponent<ItemBingoList>().Init(joinInfo);

			if(index < 2)
				item.Target.GetComponent<ItemBingoList>().SetToLocking();
		});
		btm.FindChild("Draggable").GetComponent<UIDraggablePanel2>().ResetPosition();

//		UtilMgr.ClearList(btm.FindChild("Draggable"));
//		float height = 90f;
//		for(int index = 0; index < mSortedLineup.Count; index++){
//			GameObject go = Instantiate(mItemBingoList);
//			go.transform.parent = btm.FindChild("Draggable");
//			go.transform.localScale = new Vector3(1f, 1f, 1f);
//			go.transform.localPosition = new Vector3(0, height);
//			height -= 120f;
//			Transform button = go.transform.FindChild("Scroll View").FindChild("Button");
//			button.FindChild("Photo").FindChild("Hand").FindChild("Label").GetComponent<UILabel>()
//				.text = mSortedLineup[index].batHand;
//			button.FindChild("Label").GetComponent<UILabel>()
//				.text = "#" + mSortedLineup[index].backNumber + " AVG " + mSortedLineup[index].AVG;
//			
//			if(Localization.language.Equals("English")){
//				button.FindChild("LblName").GetComponent<UILabel>()
//					.text = mSortedLineup[index].playerName;
//			} else{
//				button.FindChild("LblName").GetComponent<UILabel>()
//					.text = mSortedLineup[index].korName;
//			}
//			button.FindChild("Photo").FindChild("Panel").FindChild("Texture").GetComponent<UITexture>().mainTexture
//				= UtilMgr.GetTextureDefault();
//			button.FindChild("Photo").FindChild("Panel").FindChild("Texture").GetComponent<UITexture>().width = 72;
//			button.FindChild("Photo").FindChild("Panel").FindChild("Texture").GetComponent<UITexture>().height = 90;
//			UtilMgr.LoadImage(mSortedLineup[index].photoUrl,
//			                  button.FindChild("Photo").FindChild("Panel").FindChild("Texture").GetComponent<UITexture>());
//			
//			JoinQuizInfo joinInfo = new JoinQuizInfo();
//			joinInfo.gameId = UserMgr.eventJoined.gameId;
//			joinInfo.bingoId = mBingoId;
//			joinInfo.inningNumber = mLineupEvent.Response.data.inningNumber;
//			joinInfo.inningHalf = mLineupEvent.Response.data.inningHalf;
//			joinInfo.battingOrder = mSortedLineup[index].battingOrder;
//			joinInfo.playerId = mSortedLineup[index].playerId;
//			go.GetComponent<ItemBingoList>().Init(joinInfo);
//
//			if(index < 2)
//				go.GetComponent<ItemBingoList>().SetToLocking();
//		}
//		btm.FindChild("Draggable").GetComponent<UIScrollView>().ResetPosition();
	}

	void ClearBoard(){
		Transform tf = transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("Items");
		GameObject[] gos = new GameObject[tf.childCount];
		for(int i = 0; i < gos.Length; i++){
			gos[i] = tf.GetChild(i).gameObject;
			gos[i].SetActive(false);
		}
//		tf.DetachChildren();
		for(int i = 0; i < gos.Length; i++){
			Destroy(gos[i]);
			//			DestroyImmediate(gos[i]);
		}
	}

	public void ReceivedResult(SocketMsgInfo info){
		transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("Result")
			.GetComponent<BingoResult>().SocketResult(info);
	}

	public void Reload(){
		IsReload = true;
		mBingoEvent = new GetBingoEvent(ReceivedBingo);
		NetMgr.GetBingo(UserMgr.eventJoined.gameId, mBingoEvent);
	}

	public void ChangeInning(SocketMsgInfo info){
		IsReload = true;
		mLineupEvent = new GetCurrentLineupEvent(ReceivedLineup);
		NetMgr.GetCurrentLineup(UserMgr.eventJoined.gameId, int.Parse(info.data.inning),
		                        mBingoEvent.Response.data.bingo.bingoId, mLineupEvent);
	}

	public void InitBingoBtn(){
		transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("BtnBingo").FindChild("Sprite")
			.gameObject.SetActive(false);
		transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("BtnBingo")
			.GetComponent<UIButton>().isEnabled = false;
		if(mCanGet > 0){
			transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("BtnBingo")
				.GetComponent<UIButton>().isEnabled = true;
			transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("BtnBingo").FindChild("Sprite")
				.gameObject.SetActive(true);
			transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("BtnBingo").FindChild("Sprite")
				.FindChild("Label").GetComponent<UILabel>().text = mCanGet+"";
		}

//		if(IsReload){
//
//		} else{
//
//		}

	}

	void InitResetBtn(){
		transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("BtnReset").
			GetComponent<UIButton>().isEnabled = true;
		transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("BtnReset").FindChild("Sprite2")
			.GetComponent<UISprite>().color = new Color(0, 106f/255f, 216f/255f);
	}

	void SetNotReady(){
//	dateTime: "20160426053000",
		string dateTime = UtilMgr.IsMLB() ? UserMgr.eventJoined.dateTime : UserMgr.eventJoined.korDateTime;
		string timeZone = UtilMgr.IsMLB() ? "ET" : "KST";
		int month = int.Parse(dateTime.Substring(4, 2));
		int date = int.Parse(dateTime.Substring(6, 2));
		int hour = int.Parse(dateTime.Substring(8, 2));
		string min = dateTime.Substring(10, 2);
		string strTime = Localization.language.Equals("English") ?
			UtilMgr.GetMonthString(month) + " " + date + ", " + timeZone + " " 
				+ UtilMgr.GetAMPM(hour)[0] + ":" + min + " " + UtilMgr.GetAMPM(hour)[1] :
				month + "월 " + date +"일, " + timeZone + " "
				+ UtilMgr.GetAMPM(hour)[0] + ":" + min + " " + UtilMgr.GetAMPM(hour)[1] ;

		transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("Sprite")
			.FindChild("NotReady").FindChild("Label1").GetComponent<UILabel>().text
				= string.Format(UtilMgr.GetLocalText("StrBingoSub1"), strTime);

		transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("Sprite")
			.FindChild("NotReady").FindChild("Label2").GetComponent<UILabel>().text
				= UtilMgr.GetLocalText("StrBingoSub2");

		transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("Sprite")
			.FindChild("NotReady").gameObject.SetActive(true);

		Transform score = transform.FindChild("Top").FindChild("Score");
		score.FindChild("AwayScore").GetComponent<UILabel>().text = "0";
		score.FindChild("HomeScore").GetComponent<UILabel>().text = "0";
		score.FindChild("AwayName").GetComponent<UILabel>().text = UserMgr.eventJoined.awayTeam;
		score.FindChild("HomeName").GetComponent<UILabel>().text = UserMgr.eventJoined.homeTeam;
		score.FindChild("AwayName").FindChild("Sprite").gameObject.SetActive(false);
		score.FindChild("HomeName").FindChild("Sprite").gameObject.SetActive(false);

		Transform btm = transform.FindChild("Body").FindChild("Scroll View").FindChild("Btm");

		btm.FindChild("Info").FindChild("BG").FindChild("LblRound").GetComponent<UILabel>()
			.text = "";
		btm.FindChild("Info").FindChild("BG").FindChild("LblName").FindChild("Label").GetComponent<UILabel>()
			.text = "";
		btm.FindChild("Info").FindChild("BG").FindChild("LblName").GetComponent<UILabel>()
			.text = "";
		btm.FindChild("Info").FindChild("SprCircle").FindChild("Hand").FindChild("Label").GetComponent<UILabel>()
			.text = "";

		transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("BtnBingo").FindChild("Sprite")
			.gameObject.SetActive(false);
		transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("BtnBingo")
			.GetComponent<UIButton>().isEnabled = false;

		transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("BtnReset").
			GetComponent<UIButton>().isEnabled = false;
		transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("BtnReset").FindChild("Sprite2")
			.GetComponent<UISprite>().color = new Color(128f/255f, 128f/255f, 128f/255f);

		ShowNext();
	}

	void ShowNext(){
		if(!IsReload){
			UtilMgr.AddBackState(UtilMgr.STATE.LiveBingo);
			UtilMgr.AnimatePageToLeft("Lobby", "LiveBingo");
		}
	}
}
