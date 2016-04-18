using UnityEngine;
using System.Collections;

public class LiveBingo : MonoBehaviour {

	public GameObject mItemBingo;
	Vector3 StartPos = new Vector3(-220f, 220f);
	const float WidthFixed = 146.6f;
	const int RowFixed = 4;
	GetBingoEvent mBingoEvent;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Init(int gameId){
		mBingoEvent = new GetBingoEvent(ReceivedBingo);
		NetMgr.GetBingo(gameId, mBingoEvent);
	}

	void ReceivedBingo(){
		int row = 0, col = -1;
		for(int i = 0; i < 16; i++){
			GameObject item = Instantiate(mItemBingo);
			item.transform.parent = transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("Items");
			item.transform.localScale = new Vector3(1f, 1f, 1f);
			if(i % 4 == 0){
				col++; row = 0;
			}
			item.transform.localPosition = new Vector3(StartPos.x + (WidthFixed * row++), StartPos.y - (WidthFixed * col));

			ItemBingo itemBingo = item.GetComponent<ItemBingo>();
			itemBingo.mBingoBoard = mBingoEvent.Response.data.bingoBoard[i];
			itemBingo.Init();
		}

		UtilMgr.AddBackState(UtilMgr.STATE.LiveBingo);
		UtilMgr.AnimatePageToLeft("Lobby", "LiveBingo");
	}
}
