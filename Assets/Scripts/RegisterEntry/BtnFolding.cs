using UnityEngine;
using System.Collections;

public class BtnFolding : MonoBehaviour {

	enum State{
		Ground,
		List
	}
	State mState;

	// Use this for initialization
	void Start () {
//		UIDraggablePanel2 panel2 = transform.root.FindChild("RegisterEntry").FindChild("List")
//			.GetChild(0).GetComponent<UIDraggablePanel2>();
//		panel2.ResetPosition();
//		mState = State.List;
//		OnClick();
		Init ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Init(){
		mState = State.Ground;
		transform.GetComponent<UIButton>().normalSprite = "entry_btn_tolist";
		UILabel label = transform.FindChild("Label").GetComponent<UILabel>();
		label.text = "List";

		UIPanel panel = transform.root.FindChild("RegisterEntry").FindChild("List").GetChild(0).GetComponent<UIPanel>();
		UIDraggablePanel2 panel2 = transform.root.FindChild("RegisterEntry").FindChild("List")
			.GetChild(0).GetComponent<UIDraggablePanel2>();
		panel.SetRect(0f, 0f, 720f, 326f);
	}

	public void OnClick(){
		UIPanel panel = transform.root.FindChild("RegisterEntry").FindChild("List").GetChild(0).GetComponent<UIPanel>();
		UIDraggablePanel2 panel2 = transform.root.FindChild("RegisterEntry").FindChild("List")
			.GetChild(0).GetComponent<UIDraggablePanel2>();

//		panel2.RemoveAll();

		if(mState == State.Ground){
//			transform.root.FindChild("RegisterEntry").FindChild("Ground").gameObject.SetActive(false);
			TweenPosition.Begin(transform.root.FindChild("RegisterEntry").FindChild("Ground").gameObject
			                    , 0.5f, new Vector3(0f, 520f, 0f), false);
			TweenPosition.Begin(transform.root.FindChild("RegisterEntry").FindChild("List").gameObject
			                    , 0.5f, new Vector3(0f, -95f, 0f), false);
			transform.root.FindChild("RegisterEntry").FindChild("Ground").GetComponent<UITweener>()
				.SetOnFinished(TweenFinished);
//			panel.transform.localPosition = new Vector3(0f, -95f, 0f);
			panel.SetRect(0f, 0f, 720f, 842f);
			transform.GetComponent<UIButton>().normalSprite = "entry_btn_toground";
			UILabel label = transform.FindChild("Label").GetComponent<UILabel>();
			label.text = "Ground";

			mState = State.List;
		} else{
			transform.root.FindChild("RegisterEntry").FindChild("Ground").gameObject.SetActive(true);
			TweenPosition.Begin(transform.root.FindChild("RegisterEntry").FindChild("Ground").gameObject
			                    , 0.5f, new Vector3(0f, 0f, 0f), false);
			TweenPosition.Begin(transform.root.FindChild("RegisterEntry").FindChild("List").gameObject
			                    , 0.5f, new Vector3(0f, -352f, 0f), false);
			transform.root.FindChild("RegisterEntry").FindChild("Ground").GetComponent<UITweener>()
				.SetOnFinished(TweenFinished);
//			panel.transform.localPosition = new Vector3(0f, -352f, 0f);
			panel.SetRect(0f, 0f, 720f, 326f);
			transform.GetComponent<UIButton>().normalSprite = "entry_btn_tolist";
			UILabel label = transform.FindChild("Label").GetComponent<UILabel>();
			label.text = "List";

			mState = State.Ground;
		}

		panel2.ResetPosition();
	}

	void TweenFinished(){
		if(mState == State.List){
			transform.root.FindChild("RegisterEntry").FindChild("Ground").gameObject.SetActive(false);
		} else{

		}
	}

	void SetList(){







	}

	void SetGround(){


		UIPanel panel = transform.root.FindChild("RegisterEntry").FindChild("List").GetChild(0).GetComponent<UIPanel>();
		UIDraggablePanel2 panel2 = transform.root.FindChild("RegisterEntry").FindChild("List")
			.GetChild(0).GetComponent<UIDraggablePanel2>();



		panel2.ResetPosition();
	}
}
