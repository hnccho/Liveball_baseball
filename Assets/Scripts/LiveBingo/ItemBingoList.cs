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

	// Use this for initialization
	void Start () {
		Init ();
	}
	
	// Update is called once per frame
	void Update () {
		float x = transform.FindChild("Scroll View").FindChild("Button").localPosition.x;
		if(x < -100) mChoice = Choice.Base;
		else if(x > 100) mChoice = Choice.Out;
	}

	public void Init(){
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
			DialogueMgr.ShowDialogue("IsChosen", ""+mChoice, DialogueMgr.DIALOGUE_TYPE.Alert, null);
			IsChosen = true;
//			Event
//			NetMgr
			if(mChoice == Choice.Base)
				SetToBase();
			else
				SetToOut();

			obj.GetComponent<UIDragScrollView>().enabled = false;
		}
	}

	void ReceivedChoice(){

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
