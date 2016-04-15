using UnityEngine;
using System.Collections;

public class BtnCardPage : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		PlayerCard pCard = transform.root.FindChild("PlayerCard").GetComponent<PlayerCard>();
		if(pCard.mCardList == null) return;

		if(name.Equals("BtnLeft")){
			if(pCard.mListCnt <= 1) 
				transform.GetComponent<UIButton>().SetState(UIButtonColor.State.Disabled, true);
			else
				transform.GetComponent<UIButton>().SetState(UIButtonColor.State.Normal, true);
		} else{
			if(pCard.mListCnt >= pCard.mCardList.Count)
				transform.GetComponent<UIButton>().SetState(UIButtonColor.State.Disabled, true);
			else
				transform.GetComponent<UIButton>().SetState(UIButtonColor.State.Normal, true);
		}
	}

	public void OnClick(){
		PlayerCard pCard = transform.root.FindChild("PlayerCard").GetComponent<PlayerCard>();
		if(name.Equals("BtnLeft")){
			pCard.PrevPage();
		} else{
			pCard.NextPage();
		}
	}
}
