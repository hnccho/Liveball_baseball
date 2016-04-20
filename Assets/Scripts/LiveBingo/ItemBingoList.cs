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
		mJoinInfo = joinInfo;
		transform.FindChild("BG").FindChild("Left").gameObject.SetActive(false);
		transform.FindChild("BG").FindChild("Right").gameObject.SetActive(false);
		Choice mChoice = Choice.None;
		IsChosen = false;
		transform.FindChild("Scroll View").GetComponent<UICenterOnChild>().onCenter = Oncenter;
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

	void ReceivedChoice(){
		if(mChoice == Choice.Base)
			SetToBase();
		else
			SetToOut();
	}

	void SetToBase(){
		transform.FindChild("BG").FindChild("Left").gameObject.SetActive(true);
		transform.FindChild("LblRight").GetComponent<UILabel>().alpha = 0.2f;
//		transform.FindChild("LblRight").FindChild("Label").GetComponent<UILabel>().alpha = 0.2f;
	}

	void SetToOut(){
		transform.FindChild("BG").FindChild("Right").gameObject.SetActive(true);
		transform.FindChild("LblLeft").GetComponent<UILabel>().alpha = 0.2f;
//		transform.FindChild("LblLeft").FindChild("Label").GetComponent<UILabel>().alpha = 0.2f;
	}
}
