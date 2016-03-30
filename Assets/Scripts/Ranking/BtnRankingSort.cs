using UnityEngine;
using System.Collections;

public class BtnRankingSort : MonoBehaviour {

	public bool IsSelected;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(IsSelected){
			transform.GetComponent<UIButton>().defaultColor = new Color(0, 160f/255f, 233f/255f);
			transform.GetComponent<UIButton>().hover = new Color(0, 160f/255f, 233f/255f);
			transform.FindChild("Sprite").gameObject.SetActive(true);
		} else{
			transform.GetComponent<UIButton>().defaultColor = new Color(51f/255f, 51f/255f, 51f/255f);
			transform.GetComponent<UIButton>().hover = new Color(51f/255f, 51f/255f, 51f/255f);
			transform.FindChild("Sprite").gameObject.SetActive(false);
		}
	}

	public void OnClick(){
//		for(int i = 0; i < 3; i++){
//			transform.parent.GetChild(i).FindChild("Sprite").gameObject.SetActive(false);
//			transform.parent.GetChild(i).GetComponent<UIButton>().defaultColor = new Color(51f/255f, 51f/255f, 51f/255f);
//			transform.parent.GetChild(i).GetComponent<UIButton>().hover = new Color(51f/255f, 51f/255f, 51f/255f);
//		}
		for(int i = 0; i < 3; i++){
			transform.parent.GetChild(i).GetComponent<BtnRankingSort>().IsSelected = false;
		}
		IsSelected = true;
		if(name.Equals("1")){
			if(transform.root.FindChild("Ranking").GetComponent<Ranking>().mType == Ranking.TYPE.USER_DAILY) return;
			transform.root.FindChild("Ranking").GetComponent<Ranking>().InitNonTween (Ranking.TYPE.USER_DAILY);
		} else if(name.Equals("2")){
			if(transform.root.FindChild("Ranking").GetComponent<Ranking>().mType == Ranking.TYPE.USER_WEEKLY) return;
			transform.root.FindChild("Ranking").GetComponent<Ranking>().InitNonTween (Ranking.TYPE.USER_WEEKLY);
		} else{
			if(transform.root.FindChild("Ranking").GetComponent<Ranking>().mType == Ranking.TYPE.USER_MONTHLY) return;
			transform.root.FindChild("Ranking").GetComponent<Ranking>().InitNonTween (Ranking.TYPE.USER_MONTHLY);
		}

//		int num = int.Parse(name) -1;
//		transform.parent.GetChild(num).FindChild("Sprite").gameObject.SetActive(true);
//		transform.parent.GetChild(num).GetComponent<UIButton>().defaultColor = new Color(0, 160f/255f, 233f/255f);
//		transform.parent.GetChild(num).GetComponent<UIButton>().hover = new Color(0, 160f/255f, 233f/255f);
		transform.parent.parent.FindChild("BtnFilter").GetComponent<BtnFilter>().Fold();
	}
}
