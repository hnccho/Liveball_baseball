using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LiveBingo : MonoBehaviour {

	public GameObject mItemBingo;
	Vector3 StartPos = new Vector3(-220f, 220f);
	const float WidthFixed = 146.6f;
	const int RowFixed = 4;
	GetBingoEvent mBingoEvent;
	GetCurrentLineupEvent mLineupEvent;
	int mGameId;
	int mBingoId;
	EventInfo mEventInfo;

	public Dictionary<int, ItemBingo> mItemDic;
	List<PlayerInfo> mSortedLineup;
	PlayerInfo mPitcher;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Init(EventInfo eventInfo){
		mEventInfo = eventInfo;
		mGameId = eventInfo.gameId;
		mLineupEvent = new GetCurrentLineupEvent(ReceivedLineup);
		NetMgr.GetCurrentLineup(mGameId, mLineupEvent);
	}

	void ReceivedLineup(){
		mBingoEvent = new GetBingoEvent(ReceivedBingo);
		NetMgr.GetBingo(mGameId, mBingoEvent);
		
		transform.FindChild("Body").FindChild("Scroll View").FindChild("Board")
			.FindChild("BG").FindChild("Sprite").gameObject.SetActive(false);
		transform.FindChild("Body").FindChild("Scroll View").FindChild("Board")
			.FindChild("BG").FindChild("Sprite").GetComponent<UISprite>().height = 0;
		
		transform.GetComponent<LiveBingoAnimation>().Init();
	}

	void ReceivedBingo(){
		if(mBingoEvent.Response.data.bingoBoard.Count < 16){
			DialogueMgr.ShowDialogue("Sorry", "Sorry", DialogueMgr.DIALOGUE_TYPE.Alert, null);
			return;
		}

		mBingoId = mBingoEvent.Response.data.bingoBoard[0].bingoId;
		mItemDic = new Dictionary<int, ItemBingo>();
		int row = 0, col = -1;
		for(int i = 0; i < 16; i++){
			GameObject item = Instantiate(mItemBingo);
			item.transform.parent = transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("Items");
			item.transform.localScale = new Vector3(1f, 1f, 1f);
			item.name = mBingoEvent.Response.data.bingoBoard[i].tailId+"";
			if(i % 4 == 0){
				col++; row = 0;
			}
			//row col swapped
			item.transform.localPosition = new Vector3(StartPos.x + (WidthFixed * col), StartPos.y - (WidthFixed * row++));

			ItemBingo itemBingo = item.GetComponent<ItemBingo>();
			itemBingo.mBingoBoard = mBingoEvent.Response.data.bingoBoard[i];
			itemBingo.Init();

			mItemDic.Add(mBingoEvent.Response.data.bingoBoard[i].tailId, item.GetComponent<ItemBingo>());
		}
		InitTop();
		InitBtm();

		UtilMgr.AddBackState(UtilMgr.STATE.LiveBingo);
		UtilMgr.AnimatePageToLeft("Lobby", "LiveBingo");
	}

	public void BingoClick(){
		transform.GetComponent<LiveBingoAnimation>().GaugeUp();
	}

	public void ResetClick(){

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
			transform.GetComponent<LiveBingoAnimation>().ShowBingo("11to41");
		if(mItemDic[12].IsCorrected && mItemDic[22].IsCorrected && mItemDic[32].IsCorrected && mItemDic[42].IsCorrected)
			transform.GetComponent<LiveBingoAnimation>().ShowBingo("12to42");
		if(mItemDic[13].IsCorrected && mItemDic[23].IsCorrected && mItemDic[33].IsCorrected && mItemDic[43].IsCorrected)
			transform.GetComponent<LiveBingoAnimation>().ShowBingo("13to43");
		if(mItemDic[14].IsCorrected && mItemDic[24].IsCorrected && mItemDic[34].IsCorrected && mItemDic[44].IsCorrected)
			transform.GetComponent<LiveBingoAnimation>().ShowBingo("14to44");
		if(mItemDic[11].IsCorrected && mItemDic[12].IsCorrected && mItemDic[13].IsCorrected && mItemDic[14].IsCorrected)
			transform.GetComponent<LiveBingoAnimation>().ShowBingo("11to14");
		if(mItemDic[21].IsCorrected && mItemDic[22].IsCorrected && mItemDic[23].IsCorrected && mItemDic[24].IsCorrected)
			transform.GetComponent<LiveBingoAnimation>().ShowBingo("21to24");
		if(mItemDic[31].IsCorrected && mItemDic[32].IsCorrected && mItemDic[33].IsCorrected && mItemDic[34].IsCorrected)
			transform.GetComponent<LiveBingoAnimation>().ShowBingo("31to34");
		if(mItemDic[41].IsCorrected && mItemDic[42].IsCorrected && mItemDic[43].IsCorrected && mItemDic[44].IsCorrected)
			transform.GetComponent<LiveBingoAnimation>().ShowBingo("41to44");
		if(mItemDic[11].IsCorrected && mItemDic[22].IsCorrected && mItemDic[33].IsCorrected && mItemDic[44].IsCorrected)
			transform.GetComponent<LiveBingoAnimation>().ShowBingo("11to44");
		if(mItemDic[14].IsCorrected && mItemDic[23].IsCorrected && mItemDic[32].IsCorrected && mItemDic[41].IsCorrected)
			transform.GetComponent<LiveBingoAnimation>().ShowBingo("14to41");
	}

	void InitTop(){
		Transform score = transform.FindChild("Top").FindChild("Score");
		score.FindChild("AwayScore").GetComponent<UILabel>().text = mLineupEvent.Response.data.awayTeamRuns+"";
		score.FindChild("HomeScore").GetComponent<UILabel>().text = mLineupEvent.Response.data.homeTeamRuns+"";
		score.FindChild("AwayName").GetComponent<UILabel>().text = mEventInfo.awayTeam;
		score.FindChild("HomeName").GetComponent<UILabel>().text = mEventInfo.homeTeam;
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
		if(mLineupEvent.Response.data.inningHalf.Equals("T")){
			mPitcher = mLineupEvent.Response.data.home.pit;
			for(int i = 0; i < mLineupEvent.Response.data.away.hit.Count; i++){
				if(mLineupEvent.Response.data.away.hit[i].lastBatter > 0){
					for(int j = 0; j < mLineupEvent.Response.data.away.hit.Count; j++){
						if(++i >= mLineupEvent.Response.data.away.hit.Count) i = 0;
						mSortedLineup.Add(mLineupEvent.Response.data.away.hit[i]);
					}
					break;
				}
			}
		} else{
			mPitcher = mLineupEvent.Response.data.away.pit;
			for(int i = 0; i < mLineupEvent.Response.data.home.hit.Count; i++){
				if(mLineupEvent.Response.data.home.hit[i].lastBatter > 0){
					for(int j = 0; j < mLineupEvent.Response.data.home.hit.Count; j++){
						if(++i >= mLineupEvent.Response.data.home.hit.Count) i = 0;
						mSortedLineup.Add(mLineupEvent.Response.data.home.hit[i]);
					}
					break;
				}
			}
		}

		if(Localization.language.Equals("English")){
			string roundStr = mLineupEvent.Response.data.inningHalf.Equals("T") ? "Top" : "Bot";
			roundStr += " "+mLineupEvent.Response.data.inningNumber + UtilMgr.GetRoundString(mLineupEvent.Response.data.inningNumber);
			btm.FindChild("Info").FindChild("BG").FindChild("LblRound").GetComponent<UILabel>().text = roundStr;

			btm.FindChild("Info").FindChild("BG").FindChild("LblName").GetComponent<UILabel>().text = mPitcher.playerName;
		} else{

		}

		int width = btm.FindChild("Info").FindChild("BG").FindChild("LblName").GetComponent<UILabel>().width;
		btm.FindChild("Info").FindChild("BG").FindChild("LblName").FindChild("Label").localPosition = new Vector3(width+16f, -3f);
		btm.FindChild("Info").FindChild("BG").FindChild("LblName").FindChild("Label").GetComponent<UILabel>()
			.text = "#" + mPitcher.backNumber + " ERA " + mPitcher.ERA;
		btm.FindChild("Info").FindChild("SprCircle").FindChild("Hand").FindChild("Label").GetComponent<UILabel>()
			.text = mPitcher.throwHand;
		btm.FindChild("Info").FindChild("SprCircle").FindChild("Photo").FindChild("Panel")
			.FindChild("Texture").GetComponent<UITexture>().width = 65;
		btm.FindChild("Info").FindChild("SprCircle").FindChild("Photo").FindChild("Panel")
			.FindChild("Texture").GetComponent<UITexture>().height = 90;
				UtilMgr.LoadImage(mPitcher.photoUrl,
		                  btm.FindChild("Info").FindChild("SprCircle").FindChild("Photo").FindChild("Panel")
		                  .FindChild("Texture").GetComponent<UITexture>());
				
		btm.FindChild("Draggable").GetComponent<UIDraggablePanel2>().RemoveAll();
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
			button.FindChild("Photo").FindChild("Panel").FindChild("Texture").GetComponent<UITexture>().width = 65;
			button.FindChild("Photo").FindChild("Panel").FindChild("Texture").GetComponent<UITexture>().height = 90;
			UtilMgr.LoadImage(mSortedLineup[index].photoUrl,
			                  button.FindChild("Photo").FindChild("Panel").FindChild("Texture").GetComponent<UITexture>());

			JoinQuizInfo joinInfo = new JoinQuizInfo();
			joinInfo.gameId = mGameId;
			joinInfo.bingoId = mBingoId;
			joinInfo.inningNumber = mLineupEvent.Response.data.inningNumber;
			joinInfo.inningHalf = mLineupEvent.Response.data.inningHalf;
			joinInfo.battingOrder = mSortedLineup[index].battingOrder;
			joinInfo.playerId = mSortedLineup[index].playerId;
			item.Target.GetComponent<ItemBingoList>().Init(joinInfo);

		});
		btm.FindChild("Draggable").GetComponent<UIDraggablePanel2>().ResetPosition();
	}

}
