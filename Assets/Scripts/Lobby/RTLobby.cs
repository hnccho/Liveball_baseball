using UnityEngine;
using System.Collections;

public class RTLobby : MonoBehaviour {

	GetEventsEvent mRTEvent;
	public GameObject mItemRT;
//	Texture2D mDefaultTxt;

	int mMatchCnt;

	// Use this for initialization
	void Start () {
//		mDefaultTxt = Resources.Load<Texture2D>("images/man_default_b");
		mNow = System.DateTime.Now;
	}

	System.DateTime mNow;
	// Update is called once per frame
	void Update () {
		System.TimeSpan ts = System.DateTime.Now - mNow;
		transform.root.FindChild("Lobby").FindChild("Top").FindChild("Label").GetComponent<UILabel>()
			.text = ts.Seconds+"";



		GameObject go = transform.FindChild("ScrollRT").GetComponent<UICenterOnChild>().centeredObject;
		if((mRTEvent == null) || (mRTEvent.Response == null) ||(mRTEvent.Response.data == null) || (go == null)) return;
//		Debug.Log("centered : "+go.transform.FindChild("Label").GetComponent<UILabel>().text);
		int page = int.Parse(go.transform.FindChild("Label").GetComponent<UILabel>().text)+1;
		transform.FindChild("SprRT").FindChild("LblRTRight").GetComponent<UILabel>().text
			= page + " / " + mRTEvent.Response.data.Count + " " + UtilMgr.GetLocalText("LblGames");
	}

	void OnEnable(){
		Debug.Log("Start Coroutine");
		StartCoroutine(ReloadRT());
	}

	void OnDisable(){
		Debug.Log("Stop Coroutine");
		StopCoroutine(ReloadRT());
	}

	public void Init(){
		mRTEvent = new GetEventsEvent(ReceivedRT);
		NetMgr.GetEvents(mRTEvent);
	}

	bool mStop;
	IEnumerator ReloadRT(){
		while(true){
			yield return new WaitForSeconds(30f);
			if(mRTEvent.Response == null || mRTEvent.Response.data == null)
				mMatchCnt = 0;
			else
				mMatchCnt = mRTEvent.Response.data.Count;
			mRTEvent = new GetEventsEvent(ReceivedRT);
			NetMgr.GetEventsBack(mRTEvent);
			mStop = false;
			Debug.Log("Refresh"); mNow = System.DateTime.Now;
		}
	}

//	IEnumerator WriteTimer(){
//		System.DateTime now = System.DateTime.Now;
//		while(mStop){
//
//		}
//
//		yield return 0;
//	}

	void ReceivedRT(){
		bool DonotDelete = false;
		if(mMatchCnt == mRTEvent.Response.data.Count)
			DonotDelete = true;

		if(!DonotDelete)
			UtilMgr.ClearList(transform.FindChild("ScrollRT"));
		
		float width = 720f;
		for(int i = 0; i < mRTEvent.Response.data.Count; i++){
			Transform item = null;
			if(!DonotDelete){
				item = Instantiate(mItemRT).transform;
				item.parent = transform.FindChild("ScrollRT");
				item.localPosition = new Vector3(width * i, 1f, 1f);
				item.localScale = new Vector3(1f, 1f, 1f);
			} else{				
				item = transform.FindChild("ScrollRT").GetChild(i);
			}

			EventInfo data = mRTEvent.Response.data[i];
			item.GetComponent<ItemRT>().mEventInfo = data;

			item.FindChild("Label").GetComponent<UILabel>().text = i+"";
			if(i == 0){
				item.FindChild("SprBG").FindChild("BtnLeft").GetComponent<BoxCollider2D>().size = Vector2.zero;
				item.FindChild("SprBG").FindChild("BtnLeft").FindChild("Background")
					.GetComponent<UISprite>().color = new Color(0f, 0f, 0f, 0f);
				item.FindChild("SprBG").FindChild("BtnLeft").FindChild("Background (1)")
					.GetComponent<UISprite>().color = new Color(0f, 0f, 0f, 0f);
			} else if(i == mRTEvent.Response.data.Count-1){
				item.FindChild("SprBG").FindChild("BtnRight").GetComponent<BoxCollider2D>().size = Vector2.zero;
				item.FindChild("SprBG").FindChild("BtnRight").FindChild("Background")
					.GetComponent<UISprite>().color = new Color(0f, 0f, 0f, 0f);
				item.FindChild("SprBG").FindChild("BtnRight").FindChild("Background (1)")
					.GetComponent<UISprite>().color = new Color(0f, 0f, 0f, 0f);
			}

			if(Localization.language.Equals("English"))
				item.FindChild("Top").FindChild("LblStadium").GetComponent<UILabel>().text = data.stadiumName;
			else
				item.FindChild("Top").FindChild("LblStadium").GetComponent<UILabel>().text = data.korStadiumName;
			
			item.FindChild("Top").FindChild("LblStadium").FindChild("Sprite").localPosition = new Vector3(
				-((((float)item.FindChild("Top").FindChild("LblStadium").GetComponent<UILabel>().width) / 2f) +25f), 1f);

			item.FindChild("Score").FindChild("Left").FindChild("LblScore").GetComponent<UILabel>().text
				= data.awayTeamRuns+"";
			item.FindChild("Score").FindChild("Right").FindChild("LblScore").GetComponent<UILabel>().text
				= data.homeTeamRuns+"";
			item.FindChild("Score").FindChild("Left").FindChild("LblTeam").GetComponent<UILabel>().text
				= data.awayTeam;
			item.FindChild("Score").FindChild("Right").FindChild("LblTeam").GetComponent<UILabel>().text
				= data.homeTeam;
			item.FindChild("Score").FindChild("Left").FindChild("SprEmblem").GetComponent<UISprite>().spriteName
				= data.awayTeamId+"";
			item.FindChild("Score").FindChild("Right").FindChild("SprEmblem").GetComponent<UISprite>().spriteName
				= data.homeTeamId+"";

			if(!UtilMgr.IsMLB()){
				item.FindChild("Score").FindChild("Left").FindChild("SprEmblem").GetComponent<UISprite>().width = 74;
				item.FindChild("Score").FindChild("Left").FindChild("SprEmblem").GetComponent<UISprite>().height = 60;
				item.FindChild("Score").FindChild("Right").FindChild("SprEmblem").GetComponent<UISprite>().width = 74;
				item.FindChild("Score").FindChild("Right").FindChild("SprEmblem").GetComponent<UISprite>().height = 60;
			}

			if(data.inningHalf.Equals("T")){
				item.FindChild("Score").FindChild("Left").FindChild("SprStar").gameObject.SetActive(true);
				item.FindChild("Score").FindChild("Right").FindChild("SprStar").gameObject.SetActive(false);

				if(data.inning < 1){
					item.FindChild("Players").GetComponent<UILabel>().text = "";
				} else{
					if(Localization.language.Equals("English"))
						item.FindChild("Players").GetComponent<UILabel>().text
						= UtilMgr.GetLocalText("StrTop") + " " + data.inning + UtilMgr.GetRoundString(data.inning);
					else
						item.FindChild("Players").GetComponent<UILabel>().text
						= data.inning + UtilMgr.GetRoundString(data.inning) + " " + UtilMgr.GetLocalText("StrTop");
				}

				item.FindChild("Players").FindChild("Left").FindChild("Frame")
					.FindChild("Photo").FindChild("TxtPlayer").GetComponent<UITexture>().mainTexture
						= UtilMgr.GetTextureDefault();

				item.FindChild("Players").FindChild("Left").FindChild("Frame")
					.FindChild("Photo").FindChild("TxtPlayer").GetComponent<UITexture>().color
						= new Color(1f, 1f, 1f, 50f/255f);
//				if(!UtilMgr.IsMLB())
				item.FindChild("Players").FindChild("Left").FindChild("Frame")
					.FindChild("Photo").FindChild("TxtPlayer").GetComponent<UITexture>().width = 70;

//				UtilMgr.LoadImage(data.hitterPhoto,
//				                  item.FindChild("Players").FindChild("Left").FindChild("Frame")
//				                  .FindChild("Photo").FindChild("TxtPlayer").GetComponent<UITexture>());
				item.FindChild("Players").FindChild("Left")
					.FindChild("Frame").FindChild("SprPos").FindChild("Label").GetComponent<UILabel>().text = "B";

				item.FindChild("Players").FindChild("Right").FindChild("Frame")
					.FindChild("Photo").FindChild("TxtPlayer").GetComponent<UITexture>().mainTexture
						= UtilMgr.GetTextureDefault();

				item.FindChild("Players").FindChild("Right").FindChild("Frame")
					.FindChild("Photo").FindChild("TxtPlayer").GetComponent<UITexture>().color
					= new Color(1f, 1f, 1f, 50f/255f);
//				if(!UtilMgr.IsMLB())
					item.FindChild("Players").FindChild("Right").FindChild("Frame")
						.FindChild("Photo").FindChild("TxtPlayer").GetComponent<UITexture>().width = 70;

//				UtilMgr.LoadImage(data.pitcherPhoto,
//				                  item.FindChild("Players").FindChild("Right").FindChild("Frame")
//				                  .FindChild("Photo").FindChild("TxtPlayer").GetComponent<UITexture>());
				item.FindChild("Players").FindChild("Right")
					.FindChild("Frame").FindChild("SprPos").FindChild("Label").GetComponent<UILabel>().text = "P";

				item.FindChild("Players").FindChild("Left")
					.FindChild("Frame").FindChild("Label").GetComponent<UILabel>().text = data.hitterName;
				item.FindChild("Players").FindChild("Right")
					.FindChild("Frame").FindChild("Label").GetComponent<UILabel>().text = data.pitcherName;
			} else{
				item.FindChild("Score").FindChild("Right").FindChild("SprStar").gameObject.SetActive(true);
				item.FindChild("Score").FindChild("Left").FindChild("SprStar").gameObject.SetActive(false);

				if(data.inning < 1){
					item.FindChild("Players").GetComponent<UILabel>().text = "";
				} else{
					if(Localization.language.Equals("English"))
						item.FindChild("Players").GetComponent<UILabel>().text
						= UtilMgr.GetLocalText("StrBottom") + " " + data.inning + UtilMgr.GetRoundString(data.inning);
					else
						item.FindChild("Players").GetComponent<UILabel>().text
						= data.inning + UtilMgr.GetRoundString(data.inning) + " " + UtilMgr.GetLocalText("StrBottom");
				}
				
				item.FindChild("Players").FindChild("Left").FindChild("Frame")
					.FindChild("Photo").FindChild("TxtPlayer").GetComponent<UITexture>().mainTexture
						= UtilMgr.GetTextureDefault();
				
				item.FindChild("Players").FindChild("Left").FindChild("Frame")
					.FindChild("Photo").FindChild("TxtPlayer").GetComponent<UITexture>().color
						= new Color(1f, 1f, 1f, 50f/255f);

//				if(!UtilMgr.IsMLB())
					item.FindChild("Players").FindChild("Left").FindChild("Frame")
						.FindChild("Photo").FindChild("TxtPlayer").GetComponent<UITexture>().width = 70;
				
				item.FindChild("Players").FindChild("Right").FindChild("Frame")
					.FindChild("Photo").FindChild("TxtPlayer").GetComponent<UITexture>().mainTexture
						= UtilMgr.GetTextureDefault();
				
				item.FindChild("Players").FindChild("Right").FindChild("Frame")
					.FindChild("Photo").FindChild("TxtPlayer").GetComponent<UITexture>().color
						= new Color(1f, 1f, 1f, 50f/255f);

//				if(!UtilMgr.IsMLB())
					item.FindChild("Players").FindChild("Right").FindChild("Frame")
						.FindChild("Photo").FindChild("TxtPlayer").GetComponent<UITexture>().width = 70;

//				UtilMgr.LoadImage(data.hitterPhoto,
//				                  item.FindChild("Players").FindChild("Right").FindChild("Frame")
//				                  .FindChild("Photo").FindChild("TxtPlayer").GetComponent<UITexture>());
				item.FindChild("Players").FindChild("Right")
					.FindChild("Frame").FindChild("SprPos").FindChild("Label").GetComponent<UILabel>().text = "B";

//				UtilMgr.LoadImage(data.pitcherPhoto,
//				                  item.FindChild("Players").FindChild("Left").FindChild("Frame")
//				                  .FindChild("Photo").FindChild("TxtPlayer").GetComponent<UITexture>());
				item.FindChild("Players").FindChild("Left")
					.FindChild("Frame").FindChild("SprPos").FindChild("Label").GetComponent<UILabel>().text = "P";

				item.FindChild("Players").FindChild("Right")
					.FindChild("Frame").FindChild("Label").GetComponent<UILabel>().text = data.hitterName;
				item.FindChild("Players").FindChild("Left")
					.FindChild("Frame").FindChild("Label").GetComponent<UILabel>().text = data.pitcherName;
			}

			string dateTime = null;
			if(UtilMgr.IsMLB()){
				dateTime = data.dateTime;
			} else{
				dateTime = data.korDateTime;
			}
			int year = 0, mon = 0, day = 0, hour = 0, min = 0, sec = 0;
			year = int.Parse(dateTime.Substring(0, 4));
			mon = int.Parse(dateTime.Substring(4, 2));
			day = int.Parse(dateTime.Substring(6, 2));
			hour = int.Parse(dateTime.Substring(8, 2));
			min = int.Parse(dateTime.Substring(10, 2));
			sec = int.Parse(dateTime.Substring(12, 2));

			if(data.status.Equals("Scheduled")){
				item.FindChild("BtnEnter").FindChild("LblEnter").GetComponent<UILabel>().text =
					UtilMgr.GetLocalText("StrGameReady");
				item.FindChild("BtnEnter").FindChild("Background").GetComponent<UISprite>().color
					= new Color(255f / 255f, 91f / 255f, 16f / 255f);
				item.FindChild("BtnEnter").GetComponent<UIButton>().defaultColor
					= new Color(255f / 255f, 91f / 255f, 16f / 255f);
				item.FindChild("BtnEnter").GetComponent<UIButton>().hover
					= new Color(255f / 255f, 91f / 255f, 16f / 255f);
				item.FindChild("BtnEnter").GetComponent<UIButton>().pressed
					= new Color(255f / 255f, 91f / 255f, 16f / 255f);
				item.FindChild("Top").FindChild("SprLive").gameObject.SetActive(false);

				string strMin = min+" ";
				if(min < 10)
					strMin = "0"+min+" ";

				if(UtilMgr.IsMLB()){
					item.FindChild("Players").GetComponent<UILabel>().text = "ET "
						+ UtilMgr.GetAMPM(hour)[0] + ":" +
						strMin + UtilMgr.GetAMPM(hour)[1];
				} else{
					item.FindChild("Players").GetComponent<UILabel>().text = "KST "
						+ UtilMgr.GetAMPM(hour)[0] + ":" +
						strMin + UtilMgr.GetAMPM(hour)[1];
				}
			} else if(data.status.Equals("InProgress")){
				item.FindChild("BtnEnter").FindChild("LblEnter").GetComponent<UILabel>().text
					= UtilMgr.GetLocalText("LblEnter");
				item.FindChild("BtnEnter").FindChild("Background").GetComponent<UISprite>().color
					= new Color(0 / 255f, 106f / 255f, 216f / 255f);
				item.FindChild("BtnEnter").GetComponent<UIButton>().defaultColor
					= new Color(0 / 255f, 106f / 255f, 216f / 255f);
				item.FindChild("BtnEnter").GetComponent<UIButton>().hover
					= new Color(0 / 255f, 106f / 255f, 216f / 255f);
				item.FindChild("BtnEnter").GetComponent<UIButton>().pressed
					= new Color(1f, 91f / 255f, 16f / 255f);
				item.FindChild("Top").FindChild("SprLive").gameObject.SetActive(true);

				if(!UtilMgr.IsMLB()){
					if(data.inningState.Equals("END")){
						item.FindChild("BtnEnter").FindChild("LblEnter").GetComponent<UILabel>().text
							= "공수 교대 중";
					}
				}

			} else if(data.status.Equals("Final")){
				item.FindChild("BtnEnter").FindChild("LblEnter").GetComponent<UILabel>().text
					= UtilMgr.GetLocalText("StrGameOver");
				item.FindChild("BtnEnter").FindChild("Background").GetComponent<UISprite>().color
					= new Color(102f / 255f, 102f / 255f, 102f / 255f);
				item.FindChild("BtnEnter").GetComponent<UIButton>().defaultColor
					= new Color(102f / 255f, 102f / 255f, 102f / 255f);
				item.FindChild("BtnEnter").GetComponent<UIButton>().hover
					= new Color(102f / 255f, 102f / 255f, 102f / 255f);
				item.FindChild("BtnEnter").GetComponent<UIButton>().pressed
					= new Color(102f / 255f, 102f / 255f, 102f / 255f);
				item.FindChild("Top").FindChild("SprLive").gameObject.SetActive(false);
			} else if(data.status.Equals("Postponed")){
				item.FindChild("BtnEnter").FindChild("LblEnter").GetComponent<UILabel>().text
					= UtilMgr.GetLocalText("StrPostponed");
				item.FindChild("BtnEnter").FindChild("Background").GetComponent<UISprite>().color
					= new Color(102f / 255f, 102f / 255f, 102f / 255f);
				item.FindChild("BtnEnter").GetComponent<UIButton>().defaultColor
					= new Color(102f / 255f, 102f / 255f, 102f / 255f);
				item.FindChild("BtnEnter").GetComponent<UIButton>().hover
					= new Color(102f / 255f, 102f / 255f, 102f / 255f);
				item.FindChild("BtnEnter").GetComponent<UIButton>().pressed
					= new Color(102f / 255f, 102f / 255f, 102f / 255f);
				item.FindChild("Top").FindChild("SprLive").gameObject.SetActive(false);
			} else if(data.status.Equals("Cancel")){
				item.FindChild("BtnEnter").FindChild("LblEnter").GetComponent<UILabel>().text
					= UtilMgr.GetLocalText("StrGameCanceled");
				item.FindChild("BtnEnter").FindChild("Background").GetComponent<UISprite>().color
					= new Color(102f / 255f, 102f / 255f, 102f / 255f);
				item.FindChild("BtnEnter").GetComponent<UIButton>().defaultColor
					= new Color(102f / 255f, 102f / 255f, 102f / 255f);
				item.FindChild("BtnEnter").GetComponent<UIButton>().hover
					= new Color(102f / 255f, 102f / 255f, 102f / 255f);
				item.FindChild("BtnEnter").GetComponent<UIButton>().pressed
					= new Color(102f / 255f, 102f / 255f, 102f / 255f);
				item.FindChild("Top").FindChild("SprLive").gameObject.SetActive(false);
			} else{
				item.FindChild("BtnEnter").FindChild("LblEnter").GetComponent<UILabel>().text
					= UtilMgr.GetLocalText("StrGameOver");
				item.FindChild("BtnEnter").FindChild("Background").GetComponent<UISprite>().color
					= new Color(102f / 255f, 102f / 255f, 102f / 255f);
				item.FindChild("BtnEnter").GetComponent<UIButton>().defaultColor
					= new Color(102f / 255f, 102f / 255f, 102f / 255f);
				item.FindChild("BtnEnter").GetComponent<UIButton>().hover
					= new Color(102f / 255f, 102f / 255f, 102f / 255f);
				item.FindChild("BtnEnter").GetComponent<UIButton>().pressed
					= new Color(102f / 255f, 102f / 255f, 102f / 255f);
				item.FindChild("Top").FindChild("SprLive").gameObject.SetActive(false);
			}

			if(data.joinYN > 0){
				item.FindChild("Top").FindChild("SprJoined").gameObject.SetActive(true);
			} else{
				item.FindChild("Top").FindChild("SprJoined").gameObject.SetActive(false);
			}

		}



//		transform.FindChild("ScrollRT").GetComponent<UIScrollView>().ResetPosition();
		transform.FindChild("ScrollRT").GetComponent<UICenterOnChild>().Recenter();

		if(transform.root.FindChild("Lobby").GetComponent<Lobby>().mState != UtilMgr.STATE.Lobby){
			UtilMgr.AnimatePageToRight(
				transform.root.FindChild("Lobby").GetComponent<Lobby>().mState.ToString(), "Lobby",
				new EventDelegate(AnimationFinish));
			transform.root.FindChild("Lobby").GetComponent<Lobby>().mState = UtilMgr.STATE.Lobby;
		} else{
			AnimationFinish();
		}
	}

	void AnimationFinish(){
		ItemRT[] items = transform.FindChild("ScrollRT").GetComponentsInChildren<ItemRT>();
		foreach(ItemRT item in items)
			item.LoadImage();
	}

//	IEnumerator loadImage(string url, Transform tf){
//		WWW www = new WWW(url);
//		yield return www;
//
//		Texture2D texture = new Texture2D(0, 0, TextureFormat.ARGB4444, false);
//		www.LoadImageIntoTexture(texture);
//		tf.GetComponent<UITexture>().mainTexture = texture;
//		tf.GetComponent<UITexture>().color = Color.white;
//	}
}
