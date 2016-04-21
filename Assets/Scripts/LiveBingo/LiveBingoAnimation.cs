using UnityEngine;
using System.Collections;

public class LiveBingoAnimation : MonoBehaviour {

	const int MAX_GAUGE = 10;
	const float GAUGE_HEIGHT = 640f;
	public int mGaugeCnt;
	bool m11to41, m12to42, m13to43, m14to44
		,m11to14, m21to24, m31to34, m41to44
			,m11to44, m14to41, mBlack;
	public GameObject mDot;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Init(){
		mGaugeCnt = 0;
		m11to41 = false; m12to42 = false; m13to43 = false; m14to44 = false; m11to14 = false;
		m21to24 = false; m31to34 = false; m41to44 = false; m11to44 = false; m14to41 = false; mBlack = false;
	}

	EventDelegate delegateGauge;
	public void GaugeUp(){
		transform.FindChild("Body").FindChild("Scroll View").FindChild("Board")
			.FindChild("BG").FindChild("Sprite").gameObject.SetActive(true);
		
		delegateGauge = new EventDelegate(FinishGaugeUp);
		mGaugeCnt++;
		int height = (int)(GAUGE_HEIGHT * ((float)mGaugeCnt / (float)MAX_GAUGE));
		TweenHeight.Begin(transform.FindChild("Body").FindChild("Scroll View").FindChild("Board")
		                  .FindChild("BG").FindChild("Sprite").GetComponent<UISprite>(), 1f, height);
		transform.FindChild("Body").FindChild("Scroll View").FindChild("Board")
			.FindChild("BG").FindChild("Sprite").GetComponent<TweenHeight>().SetOnFinished(delegateGauge);
	}
	
	void FinishGaugeUp(){
		transform.FindChild("Body").FindChild("Scroll View").FindChild("Board")
			.FindChild("BG").FindChild("Sprite").GetComponent<TweenHeight>().RemoveOnFinished(delegateGauge);
		if(mGaugeCnt >= MAX_GAUGE){
			GaugeMax();
		} else{
			transform.FindChild("Body").FindChild("Scroll View").FindChild("Board")
				.FindChild("BG").FindChild("Sprite").GetComponent<Animator>().SetTrigger("Alpha");
		}
	}

	void GaugeMax(){
		DialogueMgr.ShowDialogue("max", "max", DialogueMgr.DIALOGUE_TYPE.Alert, null);
	}

	IEnumerator ShowBingoAni(string[] items, EventDelegate eventDelegate){
		for(int i = 0; i < items.Length; i++){
			transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("Items").FindChild(items[i])
				.GetComponent<ItemBingo>().Bingo();
			yield return new WaitForSeconds(0.2f);
		}
		eventDelegate.Execute();
	}
	
	public void ShowBingoAni(string name){
		Debug.Log("ShowBingo is "+name);
		if(name.Equals("11to41") && !m11to41){
			m11to41 = true;
			EventDelegate eventDelegate = new EventDelegate(this, "ShowLineRow");
			eventDelegate.parameters[0] = new EventDelegate.Parameter(1);
			StartCoroutine(ShowBingoAni(new string[]{"11", "21", "31", "41"}, eventDelegate));
			return;
		}
		else if(name.Equals("12to42") && !m12to42){
			m12to42 = true;
			EventDelegate eventDelegate = new EventDelegate(this, "ShowLineRow");
			eventDelegate.parameters[0] = new EventDelegate.Parameter(2);
			StartCoroutine(ShowBingoAni(new string[]{"12", "22", "32", "42"}, eventDelegate));
			return;
		}
		else if(name.Equals("13to43") && !m13to43){
			m13to43 = true;
			EventDelegate eventDelegate = new EventDelegate(this, "ShowLineRow");
			eventDelegate.parameters[0] = new EventDelegate.Parameter(3);
			StartCoroutine(ShowBingoAni(new string[]{"13", "23", "33", "43"}, eventDelegate));
			return;
		}
		else if(name.Equals("14to44") && !m14to44){
			m14to44 = true;
			EventDelegate eventDelegate = new EventDelegate(this, "ShowLineRow");
			eventDelegate.parameters[0] = new EventDelegate.Parameter(4);
			StartCoroutine(ShowBingoAni(new string[]{"14", "24", "34", "44"}, eventDelegate));
			return;
		}
		else if(name.Equals("11to14") && !m11to14){
			m11to14 = true;
			EventDelegate eventDelegate = new EventDelegate(this, "ShowLineCol");
			eventDelegate.parameters[0] = new EventDelegate.Parameter(1);
			StartCoroutine(ShowBingoAni(new string[]{"11", "12", "13", "14"}, eventDelegate));
			return;
		}
		else if(name.Equals("21to24") && !m21to24){
			m21to24 = true;
			EventDelegate eventDelegate = new EventDelegate(this, "ShowLineCol");
			eventDelegate.parameters[0] = new EventDelegate.Parameter(2);
			StartCoroutine(ShowBingoAni(new string[]{"21", "22", "23", "24"}, eventDelegate));
			return;
		}
		else if(name.Equals("31to34") && !m31to34){
			m31to34 = true;
			EventDelegate eventDelegate = new EventDelegate(this, "ShowLineCol");
			eventDelegate.parameters[0] = new EventDelegate.Parameter(3);
			StartCoroutine(ShowBingoAni(new string[]{"31", "32", "33", "34"}, eventDelegate));
			return;
		}
		else if(name.Equals("41to44") && !m41to44){
			m41to44 = true;
			EventDelegate eventDelegate = new EventDelegate(this, "ShowLineCol");
			eventDelegate.parameters[0] = new EventDelegate.Parameter(4);
			StartCoroutine(ShowBingoAni(new string[]{"41", "42", "43", "44"}, eventDelegate));
			return;
		}
		else if(name.Equals("11to44") && !m11to44){
			m11to44 = true;
			EventDelegate eventDelegate = new EventDelegate(ShowLineLTtoRB);
			StartCoroutine(ShowBingoAni(new string[]{"11", "22", "33", "44"}, eventDelegate));
			return;
		}
		else if(name.Equals("14to41") && !m14to41){
			m14to41 = true;
			EventDelegate eventDelegate = new EventDelegate(ShowLineLBtoRT);
			StartCoroutine(ShowBingoAni(new string[]{"14", "23", "32", "41"}, eventDelegate));
			return;
		}
		
	}
	
	public void ShowBlackBingo(){
		if(!mBlack){
			mBlack = true;
		}
	}
	
//	void ShowLineRow1(){ShowLineRow (1)}
	public void ShowLineRow(int col){
		transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("LineRow").gameObject.SetActive(true);
		switch(col){
		case 1:transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("LineRow")
			.localPosition = new Vector3(0, 220f); break;
		case 2:transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("LineRow")
			.localPosition = new Vector3(0, 73.4f); break;
		case 3:transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("LineRow")
			.localPosition = new Vector3(0, -73.2f); break;
		case 4:transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("LineRow")
			.localPosition = new Vector3(0, -219.8f); break;
		}
		
		int childCnt = transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("LineRow").childCount;
		if(childCnt < 1){
			for(int i = -315; i < 316; i += 15){
				GameObject obj = Instantiate(mDot);
				obj.transform.parent = transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("LineRow");
				obj.transform.localScale = new Vector3(1f, 1f, 1f);
				obj.transform.localPosition = new Vector3(i, 0);
			}
		}
		childCnt = transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("LineRow").childCount;
		for(int i = 0; i < childCnt; i++){
			transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("LineRow").GetChild(i)
				.gameObject.SetActive(true);
			transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("LineRow").GetChild(i)
				.GetComponent<Animator>().SetTrigger("Blink");
		}
	}

	public void ShowLineCol(int row){
		transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("LineCol").gameObject.SetActive(true);
		switch(row){
		case 1:transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("LineCol")
			.localPosition = new Vector3(-220f, 0); break;
		case 2:transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("LineCol")
			.localPosition = new Vector3(-73.4f, 0); break;
		case 3:transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("LineCol")
			.localPosition = new Vector3(73.2f, 0); break;
		case 4:transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("LineCol")
			.localPosition = new Vector3(219.8f, 0); break;
		}
		
		int childCnt = transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("LineCol").childCount;
		if(childCnt < 1){
			for(int i = -315; i < 316; i += 15){
				GameObject obj = Instantiate(mDot);
				obj.transform.parent = transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("LineCol");
				obj.transform.localScale = new Vector3(1f, 1f, 1f);
				obj.transform.localPosition = new Vector3(0, i);
			}
		}
		childCnt = transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("LineCol").childCount;
		for(int i = 0; i < childCnt; i++){
			transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("LineCol").GetChild(i)
				.gameObject.SetActive(true);
			transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("LineCol").GetChild(i)
				.GetComponent<Animator>().SetTrigger("Blink");
		}
	}

	public void ShowLineLTtoRB(){
		transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("LineLTtoRB").gameObject.SetActive(true);
		int childCnt = transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("LineLTtoRB").childCount;
		if(childCnt < 1){
			for(int i = -315, j = 315; i < 316; i += 15, j -= 15){
				GameObject obj = Instantiate(mDot);
				obj.transform.parent = transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("LineLTtoRB");
				obj.transform.localScale = new Vector3(1f, 1f, 1f);
				obj.transform.localPosition = new Vector3(i, j);
			}
		}
		childCnt = transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("LineLTtoRB").childCount;
		for(int i = 0; i < childCnt; i++){
			transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("LineLTtoRB").GetChild(i)
				.gameObject.SetActive(true);
			transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("LineLTtoRB").GetChild(i)
				.GetComponent<Animator>().SetTrigger("Blink");
		}
	}

	public void ShowLineLBtoRT(){
		transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("LineLBtoRT").gameObject.SetActive(true);
		int childCnt = transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("LineLBtoRT").childCount;
		if(childCnt < 1){
			for(int i = -315, j = -315; i < 316; i += 15, j += 15){
				GameObject obj = Instantiate(mDot);
				obj.transform.parent = transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("LineLBtoRT");
				obj.transform.localScale = new Vector3(1f, 1f, 1f);
				obj.transform.localPosition = new Vector3(i, j);
			}
		}
		childCnt = transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("LineLBtoRT").childCount;
		for(int i = 0; i < childCnt; i++){
			transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("LineLBtoRT").GetChild(i)
				.gameObject.SetActive(true);
			transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("LineLBtoRT").GetChild(i)
				.GetComponent<Animator>().SetTrigger("Blink");
		}
	}

	public void DotFinish(){
		transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("LineRow").gameObject.SetActive(false);
		transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("LineCol").gameObject.SetActive(false);
		transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("LineLBtoRT").gameObject.SetActive(false);
		transform.FindChild("Body").FindChild("Scroll View").FindChild("Board").FindChild("LineLTtoRB").gameObject.SetActive(false);
	}
}
