using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class UtilMgr : MonoBehaviour {

	static UtilMgr _instance;

	static List<STATE> mListBackState = new List<STATE>();
	GameObject mProgressCircle;

	public static bool IsUntouchable;
	public static bool IsShowLoading;
	public static WWW mWWW;
	public static bool IsFirstLanding = true;

	public static int gameround=0;
	public static string SelectTeam = "";
	public static string SelectTeamSeq = "";
	public static bool OnPause;
	public static bool OnFocus;
	public static string PreLoadedLevelName;
	Transform mRoot;

	EventDelegate mEventTweenFinish;

	public enum DIRECTION{
		ToLeft,
		ToRight
	}
	GameObject mAppear;
	GameObject mDisappear;
	Vector3 mOriCamVec;

	public enum STATE{
		Lobby,
		MyCards,
		Contests,
		Shop,
		RegisterEntry,
		Profile,
		SelectPlayer,
		MyContests,
		CardPowerUp,
		SelectFeeding,
		ContestDetails,
		Lineup,
		Bingo,
		Ranking,
		Settings,
		PlayerRecords
	}

	static UtilMgr Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = FindObjectOfType(typeof(UtilMgr)) as UtilMgr;
				Debug.Log("UtilMgr is null");
				if (_instance == null)
				{
					GameObject container = new GameObject();  
					container.name = "UtilMgr";  
					_instance = container.AddComponent(typeof(UtilMgr)) as UtilMgr;
					Debug.Log("and makes new one");
					
				}
			}
			
			return _instance;
		}
	}

	void Awake()
	{
		DontDestroyOnLoad (this);
	}

	void Update(){
//		if(mWWW != null && IsShowLoading){
//			UILabel label = Instance.mProgressCircle.transform.FindChild("Panel").FindChild("SprBG").FindChild("Label").GetComponent<UILabel>();
//			int per = (int)(mWWW.uploadProgress * 100f);
//			label.text = per + "%";
//		}
	}

	public static void AnimatePage(DIRECTION direction, GameObject disappear, GameObject appear, EventDelegate eventDelegate){
		Instance.mRoot.GetComponent<SuperRoot>().IsAnimating = true;
		Instance.mEventTweenFinish = eventDelegate;

		appear.SetActive(true);
		Instance.mOriCamVec = Instance.mRoot.FindChild("Camera").localPosition;
		if(direction == DIRECTION.ToLeft){
			appear.transform.localPosition = new Vector3(720f, 0, 0);
			TweenPosition.Begin(Instance.mRoot.FindChild("Camera").gameObject
			                    , 0.5f, new Vector3(720f, Instance.mOriCamVec.y, Instance.mOriCamVec.z), false);
//			TweenPosition.Begin(disappear, 0.5f, new Vector3(-720f, 0, 0), false);
//			Instance.mRoot.FindChild("Camera").GetComponent<TweenPosition>().to
//				= new Vector3(720f, 0, -2000f);
		} else{
			appear.transform.localPosition = new Vector3(-720f, 0, 0);
			TweenPosition.Begin(Instance.mRoot.FindChild("Camera").gameObject
			                    , 0.5f, new Vector3(-720f, Instance.mOriCamVec.y, Instance.mOriCamVec.z), false);
//			TweenPosition.Begin(disappear, 0.5f, new Vector3(720f, 0, 0), false);
//			Instance.mRoot.FindChild("Camera").GetComponent<TweenPosition>().to
//				= new Vector3(-720f, 0, -2000f);
		}
//		disappear.GetComponent<UITweener>().SetOnFinished(Instance.DisappearFinished);
//		disappear.GetComponent<UITweener>().method = UITweener.Method.EaseOut;
		Instance.mRoot.FindChild("Camera").GetComponent<UITweener>().SetOnFinished(Instance.TweenFinished);
		Instance.mRoot.FindChild("Camera").GetComponent<UITweener>().method = UITweener.Method.EaseOut;

//		TweenPosition.Begin(appear, 0.5f, new Vector3(0, 0, 0), false);
//		appear.GetComponent<UITweener>().method = UITweener.Method.EaseOut;

		Instance.mDisappear = disappear;
		Instance.mAppear = appear;

//		Instance.mRoot.FindChild("Camera").GetComponent<TweenPosition>().
//		Instance.mRoot.FindChild("Camera").GetComponent<TweenPosition>().SetOnFinished(Instance.TweenFinished);
	}

	void TweenFinished(){
		Instance.mRoot.GetComponent<SuperRoot>().IsAnimating = false;

		Instance.mDisappear.SetActive(false);
		Instance.mAppear.transform.localPosition = new Vector3(0, 0, 0);
		Instance.mRoot.FindChild("Camera").transform.localPosition
			= new Vector3(0, Instance.mOriCamVec.y, Instance.mOriCamVec.z);

		Instance.mRoot.FindChild("Profile").gameObject.SetActive(false);

		if(Instance.mEventTweenFinish != null){
			Instance.mEventTweenFinish.Execute();
			Instance.mEventTweenFinish.Clear();
			Instance.mEventTweenFinish = null;
		}
	}

//	void DisappearFinished(){
//
//	}

	public static void SetRoot(Transform root){
		Instance.mRoot = root;
	}

	public static void AddBackState(STATE state){
		mListBackState.Add(state);
	}

	public static void RemoveBackState(STATE state){
		mListBackState.Remove(state);
	}

	public static STATE GetLastBackState(){
		if(mListBackState.Count > 0)
			return mListBackState[mListBackState.Count-1];
		else
			return STATE.Lobby;
	}

	public static void ClearBackStates(){
		mListBackState.Clear();
	}

	public static bool OnBackPressed()
	{
		Debug.Log("OnBackPressed : "+mListBackState.Count);
//		if (UtilMgr.IsUntouchable)
//			return false;

		if(mListBackState.Count > 1)
		{
			STATE state = mListBackState[mListBackState.Count-1];

			if(state == STATE.Profile){
				TweenPosition.Begin(Instance.mRoot.FindChild("Profile").gameObject,
				                    				                    1f, new Vector3(1600f, 0, 0), false);
			} else if(mListBackState[mListBackState.Count-2] == STATE.Lobby){
				ClearBackStates();
				Instance.mRoot.FindChild("Lobby").GetComponent<Lobby>().Init(state);
				return true;
			} else{
				AnimatePageToRight(state.ToString(), mListBackState[mListBackState.Count-2].ToString());
			}

			mListBackState.RemoveAt(mListBackState.Count-1);
			return true;
		}
		else
		{
			Instance.ShowExitDialog();
			return false;
		}
	}

	public static void AnimatePageToRight(string disappear, string appear){
		AnimatePageToRight(disappear, appear, null);
	}

	public static void AnimatePageToLeft(string disappear, string appear){
		AnimatePageToLeft(disappear, appear, null);
	}

	public static void AnimatePageToRight(string disappear, string appear, EventDelegate eventDelegate){
		AnimatePage(DIRECTION.ToRight,
		            Instance.mRoot.FindChild(disappear).gameObject,
		            Instance.mRoot.FindChild(appear).gameObject, eventDelegate);
	}
	
	public static void AnimatePageToLeft(string disappear, string appear, EventDelegate eventDelegate){
		AnimatePage(DIRECTION.ToLeft,
		            Instance.mRoot.FindChild(disappear).gameObject,
		            Instance.mRoot.FindChild(appear).gameObject, eventDelegate);
	}

	public static void Quit(){
		Debug.Log("Quit");
//		Instance.QuitGame();
		Application.Quit();
	}

	public void ShowExitDialog(){
		DialogueMgr.ShowExitDialogue(DialogClickHandler);
	}

	public void DialogClickHandler(DialogueMgr.BTNS btn){
		if(btn == DialogueMgr.BTNS.Btn1){
			UtilMgr.Quit();
		}
	}

	public static void ResizeList(GameObject go)
	{
		try{
		Vector3 offset3 = go.transform.localPosition;
		offset3.y += UtilMgr.GetScaledPositionY () ;
		go.transform.localPosition = new Vector3 (offset3.x, offset3.y, offset3.z);
		Vector4 offset4 = go.GetComponent<UIPanel> ().baseClipRegion;
		offset4.w -= UtilMgr.GetScaledPositionY () * 2;
		go.GetComponent<UIPanel> ().baseClipRegion = new Vector4 (offset4.x, offset4.y, offset4.z, offset4.w);
		}catch{
		}
	}

	public static float GetScaledPositionY()
	{
		float height = (float)Screen.height;
		float width = (float)Screen.width;
		float ratio = height / width;
		float diff = Constants.DEFAULT_SCR_RATIO - ratio;
//		Debug.Log ("ScaledPositionY is "+360f * diff);

		return 360f * diff;
	}

	public static string RemoveThousandSeperator(string number){
		return number.Replace (",", "");
	}

	public static string AddsThousandsSeparator(string number)
	{
		return AddsThousandsSeparator (double.Parse (number));
	}

	public static string AddsThousandsSeparator(int number)
	{
		return string.Format ("{0:n0}", number);
	}

	public static string AddsThousandsSeparator(double number)
	{
		return string.Format ("{0:n0}", number);
	}

	public static string GetDateTime(TimeSpan ts){
		string value = "";

		if(ts.Hours < 10)
			value += "0"+ts.Hours;
		else
			value += ts.Hours+"";
		value += ":";
		if(ts.Minutes < 10)
			value += "0"+ts.Minutes;
		else
			value += ts.Minutes+"";
		value += ":";
		if(ts.Seconds < 10)
			value += "0"+ts.Seconds;
		else
			value += ts.Seconds+"";
		return value;
	}

	/** "yyyy-MM-dd HH:mm:ss" */
	public static string GetDateTimeNow(string expression)
	{
//		DateTime oldDate = new DateTime(
//		DateTime newDate = DateTime.Now;
//		
//		// Difference in days, hours, and minutes.
//		TimeSpan ts = newDate - oldDate;
//		// Difference in days.
//		int differenceInDays = ts.Days;
//		
//		Console.WriteLine("Difference in days: {0} ", differenceInDays);
		return System.DateTime.Now.ToString (expression);
	}
	/** "20150225182000"  */
	public static string ConvertToDate(string timeStr)
	{
		string year = timeStr.Substring (0, 4);
		string month = timeStr.Substring (4, 2);
		string day = timeStr.Substring (6, 2);
		int nTime = int.Parse(timeStr.Substring (8, 2));
		string minute = timeStr.Substring (10, 2);
		string time;
		if(nTime > 11)
		{
			time = "오후 ";
			if(nTime > 12)
			{
				nTime -= 12;
			}
			time += nTime+":";
		}
		else
		{
			time = "오전 ";
			time += nTime+":";
		}
		string final = year + ". " + month + ". " + day + " " + time + minute;
		return final;
	}

	public static string GetLocalText(string key){
		return Localization.Get(key);
	}

	public static string GetLocalText(string key, params object[] values){
		string oriTxt = Localization.Get(key);
		return string.Format(oriTxt, values);
	}

	public static string GetPosition(int positionNo){
		if(Localization.language.Equals("English")){
			switch(positionNo)
			{
			case 1: return "P";
			case 2: return "C";
			case 3: return "1B";
			case 4: return "2B";
			case 5: return "3B";
			case 6: return "SS";
			case 7: return "LF";
			case 8: return "CF";
			case 9: return "RF";
			case 10:return "DH";
			case 11:return "OF";
			case 12:return "IF";
			default:
				return "N";
			}
		} else{
			switch(positionNo)
			{
			case 1: return "투수";
			case 2: return "포수";
			case 3: return "1루수";
			case 4: return "2루수";
			case 5: return "3루수";
			case 6: return "유격수";
			case 7: return "좌익수";
			case 8: return "중견수";
			case 9: return "우익수";
			case 10:return "지명타자";
			case 11:return "외야수";
			case 12:return "내야수";
			default:
				return "N";
			}
		}
	}

	public static string GetTeamEmblem(string imgName)
	{
		switch(imgName)
		{
		case "sports_team_baseball_lg.png":
		case "LG":
			return "ic_lg";
		case "sports_team_baseball_lt.png":
		case "LT":
			return "ic_lotte";
		case "sports_team_baseball_hh.png":
		case "HH":
			return "ic_hanwha";
		case "sports_team_baseball_ob.png":
		case "OB":
			return "ic_doosan";
		case "sports_team_baseball_ht.png":
		case "HT":
			return "ic_kia";
		case "sports_team_baseball_ss.png":
		case "SS":
			return "ic_samsung";
		case "sports_team_baseball_wo.png":
		case "WO":
			return "ic_nexen";
		case "sports_team_baseball_sk.png":
		case "SK":
			return "ic_sk";
		case "sports_team_baseball_nc.png":
		case "NC":
			return "ic_nc";
		case "sports_team_baseball_kt.png":
		case "kt":
			return "ic_kt";
		}
		return "ic_liveball";
	}
	public static string GetTeamCode(string teamname)
	{
		switch(teamname)
		{
		case "LG":
			return "LG";
		case "롯데":
			return "LT";
		case "한화":
			return "HH";    
		case "두산":
			return "OB";
		case "기아":
			return "HT";
		case "삼성":
			return "SS";
		case "넥센":
			return "WO";        
		case "SK":
			return "SK";        
		case "NC":
			return "NC";
		case "kt":
		case "KT":
			return "kt";
		}
		return "none";
	}

	public static string GetTeamName(string teamCode)
	{
		switch(teamCode)
		{
		case "LG":
			return "LG트윈스";
		case "LT":
			return "롯데자이언츠";
		case "HH":
			return "한화이글스";    
		case "OB":
			return "두산베어스";
		case "HT":
			return "기아타이거즈";
		case "SS":
			return "삼성라이온즈";
		case "WO":
			return "넥센히어로즈";        
		case "SK":
			return "SK와이번스";        
		case "NC":
			return "NC다이노스";
		case "kt":
			return "KT위즈";
		}
		return "ic_liveball";
	}

//	public static string GetTeamEmblem(string teamCode)
//	{
//		switch(teamCode)
//		{
//		case "SS":
//			return "ic_samsung";
//		case "WO":
//			return "ic_nexen";
//		}
//		return null;
//	}

	public static string GetRoundString(int round)
	{	
		if(Localization.language.Equals("English"))
			return GetOrderString(round);
		else
			return "회";			
	}

	public static string GetOrderString(int order){
		if(order == 1)
		{
			return "ST";
		}
		else if(order == 2)
		{
			return "ND";
		}
		else if(order == 3)
		{
			return "RD";
		}
		else
		{
			return "TH";
		}
	}

	/** 객체의 이름을 통하여 자식 요소를 찾아서 리턴하는 함수 */
	public static GameObject GetChildObj( GameObject source, string strName) { 
		Transform[] AllData = source.GetComponentsInChildren< Transform >(); 
		GameObject target = null;
		
		foreach( Transform Obj in AllData ) { 
			if( Obj.name == strName ) { 
				target = Obj.gameObject;
				break;
			} 
		}
		
		return target;
	}

	public static Texture2D ScaleTexture(Texture2D source, int targetWidth, int targetHeight)
	{
		Texture2D result = new Texture2D(targetWidth, targetHeight, source.format, true);
		Color[] rpixels = result.GetPixels(0);
		float incX = (1.0f / (float)targetWidth);
		float incY = (1.0f / (float)targetHeight);
		for (int px = 0; px < rpixels.Length; px++)
		{
			rpixels[px] = source.GetPixelBilinear(incX * ((float)px % targetWidth), incY * ((float)Mathf.Floor(px / targetWidth)));
		}
		result.SetPixels(rpixels, 0);
		result.Apply();
		Destroy (source);
//		System.GC.Collect ();
		return result;
	}

	public static void ShowLoading(bool unTouchable, WWW www){
		if (Instance.mProgressCircle == null) {
			GameObject prefab = Resources.Load ("Progress") as GameObject;
			Instance.mProgressCircle = Instantiate (prefab, new Vector3 (0f, 0f, 0f), Quaternion.identity) as GameObject;
		}
		
		Instance.mProgressCircle.transform.parent = GameObject.Find ("UI Root").transform;
		Instance.mProgressCircle.transform.localScale = new Vector3(1f, 1f, 1f);
		Instance.mProgressCircle.transform.localPosition = new Vector3(0, 0, 0);
		Instance.mProgressCircle.SetActive (true);
		
		UtilMgr.IsUntouchable = unTouchable;

//		if(www != null){
//			mWWW = www;
//			Instance.mProgressCircle.transform.FindChild("Panel").FindChild("SprBG").FindChild("Label").gameObject.SetActive(true);
//			Instance.mProgressCircle.transform.FindChild("Panel").FindChild("SprBG").FindChild("Sprite").gameObject.SetActive(true);
//		} else{
//			Instance.mProgressCircle.transform.FindChild("Panel").FindChild("SprBG").FindChild("Label").gameObject.SetActive(false);
//			Instance.mProgressCircle.transform.FindChild("Panel").FindChild("SprBG").FindChild("Sprite").gameObject.SetActive(false);
//		}

		IsShowLoading = true;
	}

	public static void ShowLoading(){
		ShowLoading(true);
	}

	public static void ShowLoading(bool unTouchable)
	{
		ShowLoading(unTouchable, null);
	}

	public static void DismissLoading()
	{
		if(Instance.mProgressCircle != null)
			Instance.mProgressCircle.SetActive (false);

		UtilMgr.IsUntouchable = false;
		IsShowLoading = false;
		mWWW = null;
	}
	
	public static bool IsTestServer(){
		bool isTest = false;
		string strTest = PlayerPrefs.GetString (Constants.PrefServerTest);
		if(strTest != null && strTest.Equals("1"))
			isTest = true;
		
		return isTest;
	}

	public static bool IsMLB(){
		bool value = false;
		if(Application.productName.Equals("RankingBall"))
		   value = true;

		return value;
	}

	public static bool IsGuestAccount(){
		bool value = false;
//		string strTest = PlayerPrefs.GetString (Constants.PrefGuest);
//		if(strTest != null && strTest.Equals("1"))
//			value = true;
		
		return value;
	}

	public static void ClearList(Transform tf, Vector2 clip, Vector3 position){
		tf.GetComponent<UIPanel>().clipOffset = clip;
		tf.localPosition = position;

		ClearList(tf);
	}

	public static void ClearList(Transform tf){
		if(tf.childCount == 0) return;

		GameObject[] gos = new GameObject[tf.childCount];
		for(int i = 0; i < gos.Length; i++){
			gos[i] = tf.GetChild(i).gameObject;
		}
		tf.DetachChildren();
		for(int i = 0; i < gos.Length; i++){
			Destroy(gos[i]);
//			DestroyImmediate(gos[i]);
		}
	}

	public static string[] GetAMPM(int hour){
		string[] values = new string[2];
		if(hour == 12){
			values[0] = hour+"";
			values[1] = "p.m";
		} else if(hour > 12){
			hour = hour - 12;
			if(hour < 10)
				values[0] = "0"+hour;
			else
				values[0] = hour+"";
			values[1] = "p.m";
		} else{
			if(hour < 10)
				values[0] = "0"+hour;
			else
				values[0] = hour+"";
			values[1] = "a.m";
		}
		return values;
	}

	public static void StopAllCoroutine(){
		Instance.StopAllCoroutines();
	}

	public static void LoadImage(string url, UITexture texture){
		if(url == null || url.Length < 1) return;

		int pngIdx = UtilMgr.IsMLB() ? url.IndexOf(".png") : url.IndexOf(".jpg");
		int slashIdx = url.LastIndexOf("/", pngIdx);
		int length = pngIdx - slashIdx;
		string fileName = url.Substring(slashIdx, length);
//		Debug.Log("pngIdx : "+pngIdx+", slashIdx : "+slashIdx);
		string filePath = "";
		if(UtilMgr.IsMLB())
			filePath = Application.temporaryCachePath + fileName + ".png";
		else
			filePath = Application.temporaryCachePath + fileName + ".jpg";
		
		if(File.Exists(filePath)){
//			Debug.Log("have image : " + filePath);
			FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
			byte[] bytes = new byte[fs.Length];
			fs.Read(bytes, 0, (int)fs.Length);
			Texture2D temp = new Texture2D(0, 0, TextureFormat.ARGB4444, false);
			temp.LoadImage(bytes);
			texture.mainTexture = temp;
			texture.color = new Color(1f, 1f, 1f, 1f);
		} else{
			Instance.StartCoroutine(Instance.LoadingImage (url, texture, filePath));
		}
	}

		IEnumerator LoadingImage(string url, UITexture texture, string filePath){
		WWW www = new WWW(url);
		yield return www;

		if(www.error == null && www.isDone){
			if(www.size < 1){
//				Debug.Log("file size is zero");
				yield break;
			} 

			Texture2D temp = new Texture2D(0, 0, TextureFormat.ARGB4444, false);
			www.LoadImageIntoTexture(temp);
			texture.mainTexture = temp;	
			texture.color = new Color(1f, 1f, 1f, 1f);

			www.Dispose();
			byte[] bytes = UtilMgr.IsMLB() ? temp.EncodeToPNG() : temp.EncodeToJPG();
			try{
				File.WriteAllBytes(filePath, bytes);
			} catch{
				File.Delete(filePath);
//				Debug.Log("file deleted : "+filePath);
			}

//			Debug.Log("save image : " + filePath);
		}
	}
}
