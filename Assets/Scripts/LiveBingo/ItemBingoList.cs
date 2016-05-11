using UnityEngine;
using System.Collections;

public class ItemBingoList : MonoBehaviour {

	public enum Choice{
		None,
		Base,
		Out
	}

	Choice mChoice = Choice.None;
	bool IsChosen;
	bool IsLock;
	JoinQuizEvent mJoinEvent;
	JoinQuizInfo mJoinInfo;

	// Use this for initialization
	void Start () {
		UIDragScrollView[] drag = transform.FindChild("Scroll View").FindChild("Button").GetComponents<UIDragScrollView>();
		drag[0].scrollView = transform.parent.GetComponent<UIScrollView>();
		drag[1].scrollView = transform.FindChild("Scroll View").GetComponent<UIScrollView>();
	}
	
	// Update is called once per frame
	void Update () {
//		if(!transform.root.FindChild("LiveBingo").GetComponent<LiveBingo>().IsMouseDown){
//			if(!IsLock)
//				transform.FindChild("Scroll View").GetComponent<UIScrollView>().enabled = true;
//		}
//		if(Input.touchCount < 1){
//			if(!IsLock)
//				transform.FindChild("Scroll View").GetComponent<UIScrollView>().enabled = true;
//		}
//		float x = transform.FindChild("Scroll View").FindChild("Button").localPosition.x;
//		if(x < -100) mChoice = Choice.Base;
//		else if(x > 100) mChoice = Choice.Out;
	}

	public void Init(JoinQuizInfo joinInfo){
//		UIDragScrollView[] drag = transform.FindChild("Scroll View").FindChild("Button").GetComponents<UIDragScrollView>();
//		drag[0].scrollView = transform.parent.GetComponent<UIScrollView>();
//		drag[1].scrollView = transform.FindChild("Scroll View").GetComponent<UIScrollView>();
//		drag[1].scrollView = null;
//		transform.localPosition = Vector3.zero;


		IsLock = false;
		IsChosen = false;
		mJoinInfo = joinInfo;
		mJoinInfo.checkValue = -1;
		SetToNone();
		Choice mChoice = Choice.None;

		transform.FindChild("Scroll View").GetComponent<UICenterOnChild>().onCenter = OnCenter;

		foreach(CurrentLineupInfo.ForecastInfo forecast in 
		        transform.root.FindChild("LiveBingo").GetComponent<LiveBingo>().mLineupResponse.data.forecast){
			if(mJoinInfo.playerId == forecast.playerId){
				if(forecast.myValue == 0){
					mJoinInfo.checkValue = 0;
					SetToBase();
				} else if(forecast.myValue == 1){
					mJoinInfo.checkValue = 1;
					SetToOut();
				}
				break;
			}
		}

	}

	void OnCenter(GameObject obj){
		if(IsLock || IsChosen) return;

		mChoice = obj.GetComponentInParent<UIScrollView>().transform.localPosition.x > 150f ? Choice.Out
			: obj.GetComponentInParent<UIScrollView>().transform.localPosition.x < -150f ? Choice.Base : Choice.None;

		if(mChoice == Choice.None) return;

		if(mJoinInfo.checkValue == 0){
			if(mChoice == Choice.Base) return;
		} else if(mJoinInfo.checkValue == 1){
			if(mChoice == Choice.Out) return;
		}

		IsChosen = true;
		mJoinInfo.checkValue = mChoice == Choice.Base ? 0 : 1;

		mJoinEvent = new JoinQuizEvent(ReceivedChoice);
		NetMgr.JoinQuiz(mJoinInfo, mJoinEvent);
	}

	public void ReceivedChoice(){
		IsChosen = false;
		CurrentLineupInfo.ForecastInfo forecastInfo = new CurrentLineupInfo.ForecastInfo();
//		forecastInfo.battingOrder = mJoinInfo.battingOrder;
		forecastInfo.myValue = mChoice == Choice.Base ? 0 : 1;
		forecastInfo.playerId = mJoinInfo.playerId;
		forecastInfo.inningNumber = mJoinInfo.inningNumber;
		transform.root.FindChild("LiveBingo").GetComponent<LiveBingo>().mLineupResponse.data.forecast.Insert
			(0, forecastInfo);
		Init (mJoinInfo);

		mChoice = Choice.None;

	}

	void SetToBase(){
		transform.FindChild("BG").FindChild("Left").gameObject.SetActive(true);
		transform.FindChild("BG").FindChild("Right").gameObject.SetActive(false);
		transform.FindChild("StrOut").GetComponent<UILabel>().alpha = 0.2f;
		transform.FindChild("StrGetOnBase").GetComponent<UILabel>().alpha = 1f;
		SetBoardGuess(0);
	}

	void SetToOut(){
		transform.FindChild("BG").FindChild("Left").gameObject.SetActive(false);
		transform.FindChild("BG").FindChild("Right").gameObject.SetActive(true);
		transform.FindChild("StrOut").GetComponent<UILabel>().alpha = 1f;
		transform.FindChild("StrGetOnBase").GetComponent<UILabel>().alpha = 0.2f;
		SetBoardGuess(1);
	}

	void SetToNone(){
		transform.FindChild("BG").FindChild("Left").gameObject.SetActive(false);
		transform.FindChild("BG").FindChild("Right").gameObject.SetActive(false);
		transform.FindChild("StrOut").GetComponent<UILabel>().alpha = 1f;
		transform.FindChild("StrGetOnBase").GetComponent<UILabel>().alpha = 1f;

		transform.FindChild("Scroll View").FindChild("Button").FindChild("Photo").FindChild("Panel").FindChild("SprLock")
			.gameObject.SetActive(false);
		transform.FindChild("Scroll View").FindChild("Button").FindChild("Photo").FindChild("Panel").FindChild("Texture")
			.gameObject.SetActive(true);
		transform.FindChild("BG").FindChild("Sprite").GetComponent<UISprite>().color = new Color(153f/255f, 153f/255f, 153f/255f);
		transform.FindChild("BG").FindChild("Left").GetComponent<UISprite>().color = new Color(153f/255f, 153f/255f, 153f/255f);
		transform.FindChild("BG").FindChild("Left").FindChild("Sprite").GetComponent<UISprite>().color = new Color(153f/255f, 153f/255f, 153f/255f);
		transform.FindChild("BG").FindChild("Right").GetComponent<UISprite>().color = new Color(153f/255f, 153f/255f, 153f/255f);
		transform.FindChild("BG").FindChild("Right").FindChild("Sprite").GetComponent<UISprite>().color = new Color(153f/255f, 153f/255f, 153f/255f);
		transform.FindChild("Scroll View").GetComponent<UIScrollView>().enabled = true;
	}

	void SetBoardGuess(int checkValue){
		if(transform.root.FindChild("LiveBingo").GetComponent<LiveBingo>().mItemDic == null) return;

		foreach(ItemBingo item in transform.root.FindChild("LiveBingo").GetComponent<LiveBingo>().mItemDic.Values){
			if(item.mBingoBoard.playerId == mJoinInfo.playerId){
				item.SetGuess(checkValue);
				break;
			}
		}
	}

	public void SetToLocking(){
		IsLock = true;
		transform.FindChild("Scroll View").FindChild("Button").FindChild("Photo").FindChild("Panel").FindChild("SprLock")
			.gameObject.SetActive(true);
		transform.FindChild("Scroll View").FindChild("Button").FindChild("Photo").FindChild("Panel").FindChild("Texture")
			.gameObject.SetActive(false);
		transform.FindChild("BG").FindChild("Sprite").GetComponent<UISprite>().color = new Color(0, 160f/255f, 233f/255f);

		transform.FindChild("BG").FindChild("Left").GetComponent<UISprite>().color = new Color(0, 106f/255f, 126f/255f);
		transform.FindChild("BG").FindChild("Left").FindChild("Sprite").GetComponent<UISprite>().color = new Color(0, 106f/255f, 126f/255f);
		transform.FindChild("BG").FindChild("Right").GetComponent<UISprite>().color = new Color(0, 106f/255f, 126f/255f);
		transform.FindChild("BG").FindChild("Right").FindChild("Sprite").GetComponent<UISprite>().color = new Color(0, 106f/255f, 126f/255f);
		transform.FindChild("Scroll View").GetComponent<UIScrollView>().enabled = false;


	}

	public void OnClick(){
		PlayerInfo player = null;
		try{
			player = UserMgr.PlayerDic[mJoinInfo.playerId];
		} catch{
			DialogueMgr.ShowDialogue("Error", "Failed to find the information of that player."
			                         , DialogueMgr.DIALOGUE_TYPE.Alert, null);
		}

		if(player == null) return;
		transform.root.FindChild("PlayerCard").GetComponent<PlayerCard>().Init(player, null);
	}

	public void OnDragOut(){
//		Debug.Log("OnDragOut");
//		transform.FindChild("Scroll View").FindChild("Button").GetComponent<BoxCollider2D>().enabled = false;
//		transform.FindChild("Scroll View").GetComponent<UIScrollView>().enabled = false;
	}

	public void OnDragOver(){
//		Debug.Log("OnDragOver");
	}

	public void OnSelect(){
//		Debug.Log("OnSelect");
	}

	public void OnPress(){
//		Debug.Log("OnPress");
//		UIDragScrollView[] drag = transform.FindChild("Scroll View").FindChild("Button").GetComponents<UIDragScrollView>();
//		drag[1].scrollView = transform.FindChild("Scroll View").GetComponent<UIScrollView>();
	}

	public void OnRelease(){
//		Debug.Log("OnRelease");
	}
}
