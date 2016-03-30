using UnityEngine;
using System.Collections;

public class BtnRank : MonoBehaviour {

//	GetUserRankingEvent mUserRankingEvent;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick(){
		if(name.Equals("BtnRanking")){
			transform.root.FindChild("Ranking").GetComponent<Ranking>().Init();
		} else{

		}
	}
}
