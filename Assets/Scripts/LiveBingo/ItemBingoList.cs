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
	JoinQuizEvent mJoinEvent;
	JoinQuizInfo mJoinInfo;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		float x = transform.FindChild("Scroll View").FindChild("Button").localPosition.x;
		if(x < -100) mChoice = Choice.Base;
		else if(x > 100) mChoice = Choice.Out;
	}

	public void Init(JoinQuizInfo joinInfo){
		IsChosen = false;
		mJoinInfo = joinInfo;
		SetToNone();
		Choice mChoice = Choice.None;

		transform.FindChild("Scroll View").GetComponent<UICenterOnChild>().onCenter = Oncenter;

		foreach(CurrentLineupInfo.ForecastInfo forecast in 
		        transform.root.FindChild("LiveBingo").GetComponent<LiveBingo>().mLineupEvent.Response.data.forecast){
			if(mJoinInfo.playerId == forecast.playerId){
				if(forecast.myValue == 0){
					SetToBase();
				} else if(forecast.myValue == 1){
					SetToOut();
				}
				break;
			}
		}

	}

	void Oncenter(GameObject obj){
		mChoice = obj.GetComponentInParent<UIScrollView>().transform.localPosition.x > 100f ? Choice.Out
			: obj.GetComponentInParent<UIScrollView>().transform.localPosition.x < -100f ? Choice.Base : Choice.None;

		if(mChoice != Choice.None && !IsChosen){
			IsChosen = true;

			mJoinInfo.checkValue = mChoice == Choice.Base ? 0 : 1;

			mJoinEvent = new JoinQuizEvent(ReceivedChoice);
			NetMgr.JoinQuiz(mJoinInfo, mJoinEvent);

//			obj.GetComponent<UIDragScrollView>().enabled = false;
		}
	}

	public void ReceivedChoice(){
		IsChosen = false;
		CurrentLineupInfo.ForecastInfo forecastInfo = new CurrentLineupInfo.ForecastInfo();
//		forecastInfo.battingOrder = mJoinInfo.battingOrder;
		forecastInfo.myValue = mChoice == Choice.Base ? 0 : 1;
		forecastInfo.playerId = mJoinInfo.playerId;
		forecastInfo.inningNumber = mJoinInfo.inningNumber;
		transform.root.FindChild("LiveBingo").GetComponent<LiveBingo>().mLineupEvent.Response.data.forecast.Insert
			(0, forecastInfo);
//		foreach(CurrentLineupInfo.ForecastInfo forecast in 
//		        transform.root.FindChild("LiveBingo").GetComponent<LiveBingo>().mLineupEvent.Response.data.forecast){
//			Debug.Log("mJoinInfo.battingOrder : "+mJoinInfo.battingOrder+", forecast.battingOrder : "+forecast.battingOrder);
//			if(forecast.battingOrder == mJoinInfo.battingOrder){
//				if(mChoice == Choice.Base){
//					forecast.myValue = 0;
//				} else{
//					forecast.myValue = 1;
//				}
//				Debug.Log("forecast.myValue : "+forecast.myValue);
//				break;
//			}

//		}
		Init (mJoinInfo);

//		if(mChoice == Choice.Base)
		//			SetToBase();battingO
//		else
//			SetToOut();

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
		transform.FindChild("Scroll View").FindChild("Button").GetComponent<UIButton>().isEnabled = true;
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
		transform.FindChild("Scroll View").FindChild("Button").FindChild("Photo").FindChild("Panel").FindChild("SprLock")
			.gameObject.SetActive(true);
		transform.FindChild("Scroll View").FindChild("Button").FindChild("Photo").FindChild("Panel").FindChild("Texture")
			.gameObject.SetActive(false);
		transform.FindChild("BG").FindChild("Sprite").GetComponent<UISprite>().color = new Color(0, 160f/255f, 233f/255f);
		transform.FindChild("BG").FindChild("Left").GetComponent<UISprite>().color = new Color(0, 106f/255f, 126f/255f);
		transform.FindChild("BG").FindChild("Left").FindChild("Sprite").GetComponent<UISprite>().color = new Color(0, 106f/255f, 126f/255f);
		transform.FindChild("Scroll View").FindChild("Button").GetComponent<UIButton>().isEnabled = false;
	}
}
