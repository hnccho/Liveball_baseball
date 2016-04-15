using UnityEngine;
using System.Collections;

public class PlayerCardAnimation : MonoBehaviour {

	public bool CanOpen;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SetRenderQ(){
		TweenAlpha.Begin(transform.FindChild("BG").gameObject, 0, 1f);
		transform.FindChild("Boom").gameObject.SetActive(true);
		transform.FindChild("Boom").GetComponent<ParticleSystem>().Play();

		transform.GetComponent<UIPanel>().renderQueue = UIPanel.RenderQueue.StartAt;
		transform.GetComponent<UIPanel>().startingRenderQueue = 1000;
	}

	void RestoreRenderQ(){
		TweenAlpha.Begin(transform.FindChild("BG").gameObject, 0, 200f/255f);
		transform.FindChild("Boom").gameObject.SetActive(false);

		transform.GetComponent<UIPanel>().renderQueue = UIPanel.RenderQueue.Automatic;
	}

	public void AppearPack(string productCode){
		SetRenderQ();

		UtilMgr.AddBackState(UtilMgr.STATE.PlayerCard);
		transform.gameObject.SetActive(true);
		transform.FindChild("PackBack").gameObject.SetActive(true);
		transform.FindChild("PackBack").localPosition = Vector3.zero;
		
		string strImg = "";
		if(productCode.Equals("item.2120213001")){
			strImg = "images/shop_card_pack_bronze";
		} else if(productCode.Equals("item.2120214001")){
			strImg = "images/shop_card_pack_silver";
		} else if(productCode.Equals("item.2120225001")){
			strImg = "images/shop_card_pack_gold";
		} else
			strImg = "images/shop_card_pack_vip";
		
		transform.FindChild("PackBack").FindChild("Texture").GetComponent<UITexture>()
			.mainTexture = Resources.Load<Texture2D>(strImg);
		
		transform.FindChild("PackBack").localScale = new Vector3(1f, 1f, 1f);
		transform.localPosition = Vector3.zero;
		transform.FindChild("Body").localScale = new Vector3(0, 1f, 1f);


		StartCoroutine(WaitForLighting());
	}

	IEnumerator WaitForLighting(){
		yield return new WaitForSeconds(2f);
		
		ScaleupPack();
	}

	EventDelegate delegateScaleupPackFinish;
	void ScaleupPack(){
		delegateScaleupPackFinish = new EventDelegate(MovedownPack);
		TweenScale.Begin(transform.FindChild("PackBack").gameObject, 0.5f, new Vector3(1.2f, 1.2f, 1f));
		transform.FindChild("PackBack").GetComponent<TweenScale>().SetOnFinished(delegateScaleupPackFinish);
	}

	EventDelegate delegateMovedownPackFinish;
	void MovedownPack(){
		transform.FindChild("PackBack").GetComponent<TweenScale>().RemoveOnFinished(delegateScaleupPackFinish);
		delegateMovedownPackFinish = new EventDelegate(MovedownPackFinish);
		TweenPosition.Begin(transform.FindChild("PackBack").gameObject, 0.5f, new Vector3(0, -2000f, 0));
		transform.FindChild("PackBack").GetComponent<TweenPosition>().SetOnFinished(delegateMovedownPackFinish);

		JumpBack();
	}

	void MovedownPackFinish(){
		transform.FindChild("PackBack").GetComponent<TweenPosition>().RemoveOnFinished(delegateMovedownPackFinish);
	}

	EventDelegate delegateJumpBackFinish;
	void JumpBack(){
		Debug.Log("11");
		delegateJumpBackFinish = new EventDelegate(FallBack);
		transform.FindChild("Back").gameObject.SetActive(true);
		
		string strImg = "images/card_back_"+transform.GetComponent<PlayerCard>().mCardInfo.cardClass;
		transform.FindChild("Back").FindChild("Texture").GetComponent<UITexture>()
			.mainTexture = Resources.Load<Texture2D>(strImg);
		
		transform.FindChild("Back").localScale = new Vector3(1f, 1f, 1f);
		transform.localPosition = Vector3.zero;
		TweenPosition.Begin(transform.FindChild("Back").gameObject, 0.2f, new Vector3(0, 150f, 0));
		transform.FindChild("Back").GetComponent<TweenPosition>().SetOnFinished(delegateJumpBackFinish);
		Debug.Log("11.5");
	}

	EventDelegate delegateFallBackFinish;
	void FallBack(){
		Debug.Log("12");
		transform.FindChild("Back").GetComponent<TweenPosition>().RemoveOnFinished(delegateJumpBackFinish);
		delegateFallBackFinish = new EventDelegate(FallBack2);
		TweenPosition.Begin(transform.FindChild("Back").gameObject, 0.2f, new Vector3(0, 0, 0));
		transform.FindChild("Back").GetComponent<TweenPosition>().SetOnFinished(delegateFallBackFinish);
	}

	void FallBack2(){
		Debug.Log("13");
		transform.FindChild("Back").GetComponent<TweenPosition>().RemoveOnFinished(delegateFallBackFinish);
		delegateFallBackFinish = new EventDelegate(FallBack3);
		TweenPosition.Begin(transform.FindChild("Back").gameObject, 0.1f, new Vector3(0, 10f, 0));
		transform.FindChild("Back").GetComponent<TweenPosition>().SetOnFinished(delegateFallBackFinish);
	}

	void FallBack3(){
		Debug.Log("14");
		transform.FindChild("Back").GetComponent<TweenPosition>().RemoveOnFinished(delegateFallBackFinish);
//		delegateFallBackFinish = new EventDelegate(FallBackFinish);
		TweenPosition.Begin(transform.FindChild("Back").gameObject, 0.1f, new Vector3(0, 0, 0));
//		transform.FindChild("Back").GetComponent<TweenPosition>().SetOnFinished(delegateFallBackFinish);
		StartCoroutine(WaitForStopping());
	}

	IEnumerator WaitForStopping(){
		yield return new WaitForSeconds(1f);
		
		FallBackFinish();
	}

	void FallBackFinish(){
		transform.FindChild("Back").GetComponent<TweenPosition>().RemoveOnFinished(delegateFallBackFinish);
		DisappearBack();
	}

	EventDelegate delegatePageBack;
	public void PrevPage(){
		SetCardBack();

		delegatePageBack = new EventDelegate(ShowPlayer);
		transform.FindChild("Back").localScale = new Vector3(0, 1f, 1f);
		transform.FindChild("Back").localPosition = new Vector3(-360f, 0);
		TweenScale.Begin(transform.FindChild("Back").gameObject, 0.5f, new Vector3(1f, 1f, 1f));
		TweenPosition.Begin(transform.FindChild("Back").gameObject, 0.5f, new Vector3(0, 0));
		transform.FindChild("Back").GetComponent<TweenPosition>().SetOnFinished(delegatePageBack);
		
		TweenScale.Begin(transform.FindChild("Body").gameObject, 0.5f, new Vector3(0, 0.659f, 1f));
		TweenPosition.Begin(transform.FindChild("Body").gameObject, 0.5f, new Vector3(360f, 0));
	}

	public void NextPage(){
		SetCardBack();

		delegatePageBack = new EventDelegate(ShowPlayer);
		transform.FindChild("Back").localScale = new Vector3(0, 1f, 1f);
		transform.FindChild("Back").localPosition = new Vector3(360f, 0);
		TweenScale.Begin(transform.FindChild("Back").gameObject, 0.5f, new Vector3(1f, 1f, 1f));
		TweenPosition.Begin(transform.FindChild("Back").gameObject, 0.5f, new Vector3(0, 0));
		transform.FindChild("Back").GetComponent<TweenPosition>().SetOnFinished(delegatePageBack);

		TweenScale.Begin(transform.FindChild("Body").gameObject, 0.5f, new Vector3(0, 0.659f, 1f));
		TweenPosition.Begin(transform.FindChild("Body").gameObject, 0.5f, new Vector3(-360f, 0));
	}

	void SetCardBack(){
		string strImg = "";
		if(transform.GetComponent<PlayerCard>().IsCard){
			strImg = "images/card_back_"+transform.GetComponent<PlayerCard>().mCardInfo.cardClass;
		} else{
			//default
			strImg = "images/card_back_default";
		}
		
		transform.FindChild("Back").FindChild("Texture").GetComponent<UITexture>()
			.mainTexture = Resources.Load<Texture2D>(strImg);
	}

	void ShowPlayer(){
		transform.FindChild("Back").GetComponent<TweenPosition>().RemoveOnFinished(delegatePageBack);

		TweenPosition.Begin(transform.FindChild("Body").gameObject, 0, new Vector3(0, 0));
		transform.GetComponent<PlayerCard>().InitWithCard(
			transform.GetComponent<PlayerCard>().mCardInfo, null);
		DisappearBack();
	}

//	void PrevPage2(){
//		transform.FindChild("Back").GetComponent<TweenPosition>().RemoveOnFinished(delegatePageFinish);
//		transform.FindChild("Back").localScale = new Vector3(0, 1f, 1f);
//		transform.FindChild("Back").localPosition = new Vector3(-180f, 0);
//		TweenScale.Begin(transform.FindChild("Back").gameObject, 0.5f, new Vector3(1f, 1f, 1f));
//		TweenPosition.Begin(transform.FindChild("Back").gameObject, 0.5f, new Vector3(-360f, 0));
//	}

	EventDelegate delegateAppearBackFinish;// = new EventDelegate(AppearBackFinish);
	public void AppearBack(){
		delegateAppearBackFinish = new EventDelegate(AppearBackFinish);
		Debug.Log("1");
		UtilMgr.AddBackState(UtilMgr.STATE.PlayerCard);
		transform.gameObject.SetActive(true);
		transform.FindChild("Back").gameObject.SetActive(true);
		transform.FindChild("PackBack").gameObject.SetActive(false);
//		transform.FindChild("BG").GetComponent<UISprite>().color = new Color(0, 0, 0, 200f/255f);
		TweenAlpha.Begin(transform.FindChild("BG").gameObject, 0, 200f/255f);

		SetCardBack();
		
		transform.FindChild("Back").localScale = new Vector3(0f, 0f, 1f);
		transform.localPosition = Vector3.zero;
		transform.FindChild("Body").localScale = new Vector3(0, 1f, 1f);
		TweenScale.Begin(transform.FindChild("Back").gameObject, 0.3f, new Vector3(1f, 1f, 1f));
		CanOpen = false;
		transform.FindChild("Back").GetComponent<TweenScale>().SetOnFinished(delegateAppearBackFinish);
	}
	
	void AppearBackFinish(){
		Debug.Log("2");
		//		transform.FindChild("Back").GetComponent<UITweener>().onFinished = new List<EventDelegate>();
		transform.FindChild("Back").GetComponent<TweenScale>().RemoveOnFinished(delegateAppearBackFinish);
		StartCoroutine(WaitForLoading());
		//		DisappearBack();
	}
	
	EventDelegate delegateAnimateAppear;// = new EventDelegate(AnimateAppear);
	void DisappearBack(){
		RestoreRenderQ();

		delegateAnimateAppear = new EventDelegate(AnimateAppear);
		Debug.Log("3");
		TweenScale.Begin(transform.FindChild("Back").gameObject, 0.2f, new Vector3(0f, 1f, 1f));
		transform.FindChild("Back").GetComponent<TweenScale>().SetOnFinished(delegateAnimateAppear);
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
		transform.FindChild("Back").GetComponent<TweenScale>().RemoveOnFinished(delegateAnimateAppear);
		transform.FindChild("Body").localScale = new Vector3(0, 0.659f, 1f);
		TweenScale.Begin(transform.FindChild("Body").gameObject, 0.2f, new Vector3(1f, 1f, 1f));
		transform.FindChild("Body").GetComponent<TweenScale>().SetOnFinished(delegateAppearFinish);
	}

	EventDelegate delegateDisappearFinish;
	public void AnimateDisappear(){
		delegateDisappearFinish = new EventDelegate(DisappearFinish);
		TweenScale.Begin(transform.FindChild("Body").gameObject, 0.2f, new Vector3(0f, 0f, 1f));
		TweenAlpha.Begin(transform.FindChild("BG").gameObject, 0.2f, 0);
		transform.FindChild("Body").GetComponent<TweenScale>().SetOnFinished(delegateDisappearFinish);
	}
	
	EventDelegate delegateAppearFinish2;
	void AppearFinish(){
		delegateAppearFinish2 = new EventDelegate(AppearFinish2);
		//		transform.FindChild("Body").GetComponent<UITweener>().RemoveOnFinished(delegateAppearFinish);
		//		TweenScale.Begin(transform.FindChild("Body").gameObject, 0.2f, new Vector3(1f, 1f, 1f));
		//		transform.FindChild("Body").GetComponent<UITweener>().SetOnFinished(delegateAppearFinish2);
	}
	
	void AppearFinish2(){
		transform.FindChild("Body").GetComponent<TweenScale>().RemoveOnFinished(delegateAppearFinish2);
	}
	
	void DisappearFinish(){
		transform.FindChild("Body").GetComponent<TweenScale>().RemoveOnFinished(delegateDisappearFinish);
		transform.localPosition = new Vector3(2000f, 2000f);
		transform.gameObject.SetActive(false);
	}
}
