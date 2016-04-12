using UnityEngine;
using System.Collections;

public class PlayerCardAnimation : MonoBehaviour {

	public bool CanOpen;
	PlayerCard mPlayerCard;

	// Use this for initialization
	void Start () {
		mPlayerCard = transform.GetComponent<PlayerCard>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	EventDelegate delegateAppearBackFinish;// = new EventDelegate(AppearBackFinish);
	public void AppearBack(){
		delegateAppearBackFinish = new EventDelegate(AppearBackFinish);
		Debug.Log("1");
		UtilMgr.AddBackState(UtilMgr.STATE.PlayerCard);
		transform.gameObject.SetActive(true);
		transform.FindChild("Back").gameObject.SetActive(true);
//		transform.FindChild("BG").GetComponent<UISprite>().color = new Color(0, 0, 0, 200f/255f);
		TweenAlpha.Begin(transform.FindChild("BG").gameObject, 0, 200f/255f);
		
		string strImg = "";
		if(mPlayerCard.IsCard){
			strImg = "images/card_back_"+mPlayerCard.mCardInfo.cardClass;
		} else{
			//default
			strImg = "images/card_back_default";
		}
		
		transform.FindChild("Back").FindChild("Texture").GetComponent<UITexture>()
			.mainTexture = Resources.Load<Texture2D>(strImg);
		
		transform.FindChild("Back").localScale = new Vector3(0f, 0f, 1f);
		transform.localPosition = Vector3.zero;
		transform.FindChild("Body").localScale = new Vector3(0, 1f, 1f);
		TweenScale.Begin(transform.FindChild("Back").gameObject, 0.5f, new Vector3(1f, 1f, 1f));
		CanOpen = false;
		transform.FindChild("Back").GetComponent<UITweener>().SetOnFinished(delegateAppearBackFinish);
	}
	
	void AppearBackFinish(){
		Debug.Log("2");
		//		transform.FindChild("Back").GetComponent<UITweener>().onFinished = new List<EventDelegate>();
		transform.FindChild("Back").GetComponent<UITweener>().RemoveOnFinished(delegateAppearBackFinish);
		StartCoroutine(WaitForLoading());
		//		DisappearBack();
	}
	
	EventDelegate delegateAnimateAppear;// = new EventDelegate(AnimateAppear);
	void DisappearBack(){
		delegateAnimateAppear = new EventDelegate(AnimateAppear);
		Debug.Log("3");
		TweenScale.Begin(transform.FindChild("Back").gameObject, 0.2f, new Vector3(0f, 1f, 1f));
		transform.FindChild("Back").GetComponent<UITweener>().SetOnFinished(delegateAnimateAppear);
	}
	
	IEnumerator WaitForLoading(){
		Debug.Log("4");
		if(!CanOpen)
			yield return 0;
		
		DisappearBack();
	}
	
	EventDelegate delegateAppearFinish;// = new EventDelegate(AppearFinish);
	void AnimateAppear(){
		delegateAppearFinish = new EventDelegate(AppearFinish);
		Debug.Log("5");
		//		transform.FindChild("Back").GetComponent<UITweener>().onFinished = new List<EventDelegate>();
		transform.FindChild("Back").GetComponent<UITweener>().RemoveOnFinished(delegateAnimateAppear);
		transform.FindChild("Body").localScale = new Vector3(0, 0.659f, 1f);
		TweenScale.Begin(transform.FindChild("Body").gameObject, 0.2f, new Vector3(1f, 1f, 1f));
		transform.FindChild("Body").GetComponent<UITweener>().SetOnFinished(delegateAppearFinish);
	}

	EventDelegate delegateDisappearFinish;
	public void AnimateDisappear(){
		delegateDisappearFinish = new EventDelegate(DisappearFinish);
		TweenScale.Begin(transform.FindChild("Body").gameObject, 0.2f, new Vector3(0f, 0f, 1f));
		TweenAlpha.Begin(transform.FindChild("BG").gameObject, 0.2f, 0);
		transform.FindChild("Body").GetComponent<UITweener>().SetOnFinished(delegateDisappearFinish);
	}
	
	EventDelegate delegateAppearFinish2;
	void AppearFinish(){
		delegateAppearFinish2 = new EventDelegate(AppearFinish2);
		//		transform.FindChild("Body").GetComponent<UITweener>().RemoveOnFinished(delegateAppearFinish);
		//		TweenScale.Begin(transform.FindChild("Body").gameObject, 0.2f, new Vector3(1f, 1f, 1f));
		//		transform.FindChild("Body").GetComponent<UITweener>().SetOnFinished(delegateAppearFinish2);
	}
	
	void AppearFinish2(){
		transform.FindChild("Body").GetComponent<UITweener>().RemoveOnFinished(delegateAppearFinish2);
	}
	
	void DisappearFinish(){
		transform.FindChild("Body").GetComponent<UITweener>().RemoveOnFinished(delegateDisappearFinish);
		transform.localPosition = new Vector3(2000f, 2000f);
		transform.gameObject.SetActive(false);
	}
}
