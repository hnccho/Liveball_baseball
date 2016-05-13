using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BtnFolding : MonoBehaviour {

	public enum State{
		Ground,
		List
	}
	public State mState;

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

		UIPanel panel = transform.root.FindChild("RegisterEntry").FindChild("Body").FindChild("List").GetChild(0)
			.GetComponent<UIPanel>();
		UIScrollView panel2 = transform.root.FindChild("RegisterEntry").FindChild("Body").FindChild("List")
			.GetChild(0).GetComponent<UIScrollView>();
		panel.transform.localPosition = new Vector3(0f, -328f, 0f);
		panel.SetRect(0f, 0f, 720f, 376f);
		panel.clipOffset = Vector2.zero;
		panel2.ResetPosition();
	}

	public void OnClick(){
		UIPanel panel = transform.root.FindChild("RegisterEntry").FindChild("Body").FindChild("List").GetChild(0)
			.GetComponent<UIPanel>();
		UIScrollView panel2 = transform.root.FindChild("RegisterEntry").FindChild("Body").FindChild("List")
			.GetChild(0).GetComponent<UIScrollView>();

//		panel2.RemoveAll();

		if(mState == State.Ground){ //ground invisible
//			transform.root.FindChild("RegisterEntry").FindChild("Ground").gameObject.SetActive(false);
			TweenPosition.Begin(transform.root.FindChild("RegisterEntry").FindChild("Body").FindChild("Ground").gameObject
			                    , 0.5f, new Vector3(0f, 470f, 0f), false);
			transform.root.FindChild("RegisterEntry").FindChild("Body").FindChild("Ground").GetComponent<UITweener>()
				.onFinished = new List<EventDelegate>();
			transform.root.FindChild("RegisterEntry").FindChild("Body").FindChild("Ground").GetComponent<UITweener>()
				.SetOnFinished(TweenFinished);
			panel.transform.localPosition = new Vector3(0f, -70f, 0f);
			panel.SetRect(0f, 0f, 720f, 892f);
			panel.clipOffset = Vector2.zero;
			transform.GetComponent<UIButton>().normalSprite = "entry_btn_toground";
			UILabel label = transform.FindChild("Label").GetComponent<UILabel>();
			label.text = "Ground";

			mState = State.List;

			panel2.ResetPosition();
		} else{ //ground visible
			transform.root.FindChild("RegisterEntry").FindChild("Body").FindChild("Ground").gameObject.SetActive(true);
			TweenPosition.Begin(transform.root.FindChild("RegisterEntry").FindChild("Body").FindChild("Ground").gameObject
			                    , 0.5f, new Vector3(0f, 50f, 0f), false);
			transform.root.FindChild("RegisterEntry").FindChild("Body").FindChild("Ground").GetComponent<UITweener>()
				.onFinished = new List<EventDelegate>();
			transform.root.FindChild("RegisterEntry").FindChild("Body").FindChild("Ground").GetComponent<UITweener>()
				.SetOnFinished(TweenFinished);
			transform.GetComponent<UIButton>().normalSprite = "entry_btn_tolist";
			UILabel label = transform.FindChild("Label").GetComponent<UILabel>();
			label.text = "List";

			mState = State.Ground;
		}
	}

	void TweenFinished(){
		transform.root.FindChild("RegisterEntry").FindChild("Body").FindChild("Ground").GetComponent<UITweener>()
			.onFinished = new List<EventDelegate>();
		if(mState == State.List){
			transform.root.FindChild("RegisterEntry").FindChild("Body").FindChild("Ground").gameObject.SetActive(false);
		} else{
			UIPanel panel = transform.root.FindChild("RegisterEntry").FindChild("Body").FindChild("List").GetChild(0)
				.GetComponent<UIPanel>();
			panel.transform.localPosition = new Vector3(0f, -328f, 0f);
			panel.SetRect(0f, 0f, 720f, 376f);
			panel.clipOffset = new Vector2(0, 0);
			transform.root.FindChild("RegisterEntry").FindChild("Body").FindChild("List")
				.GetChild(0).GetComponent<UIScrollView>().ResetPosition();
		}
	}

	void SetList(){







	}

	void SetGround(){


		UIPanel panel = transform.root.FindChild("RegisterEntry").FindChild("Body").FindChild("List").GetChild(0).GetComponent<UIPanel>();
		UIScrollView panel2 = transform.root.FindChild("RegisterEntry").FindChild("Body").FindChild("List")
			.GetChild(0).GetComponent<UIScrollView>();



		panel2.ResetPosition();
	}
}
