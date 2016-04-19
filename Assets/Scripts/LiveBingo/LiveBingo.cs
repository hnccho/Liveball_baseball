using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LiveBingo : MonoBehaviour {

	public GameObject mItemBingo;
	Vector3 StartPos = new Vector3(-220f, 220f);
	const float WidthFixed = 146.6f;
	const int RowFixed = 4;
	GetBingoEvent mBingoEvent;

	public Dictionary<int, ItemBingo> mItemDic;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Init(int gameId){
		mBingoEvent = new GetBingoEvent(ReceivedBingo);
		NetMgr.GetBingo(gameId, mBingoEvent);

		transform.FindChild("Body").FindChild("Scroll View").FindChild("Board")
			.FindChild("BG").FindChild("Sprite").gameObject.SetActive(false);
		transform.FindChild("Body").FindChild("Scroll View").FindChild("Board")
			.FindChild("BG").FindChild("Sprite").GetComponent<UISprite>().height = 0;

		transform.GetComponent<LiveBingoAnimation>().Init();
	}

	void ReceivedBingo(){
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

}
