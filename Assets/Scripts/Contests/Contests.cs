using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Contests : MonoBehaviour {

	List<ContestListInfo> mContestList;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void InitContests(string title, List<ContestListInfo> list){
		transform.FindChild("Top").FindChild("LblRanking").GetComponent<UILabel>().text = title;
		mContestList = list;

		UIDraggablePanel2 dragPanel = transform.FindChild("Body").FindChild("Scroll").GetComponent<UIDraggablePanel2>();
		dragPanel.Init(mContestList.Count, delegate (UIListItem item, int index){
			InitContestItem(item, index);
		});
		dragPanel.ResetPosition();
	}

	void InitContestItem(UIListItem item, int index){
		item.Target.gameObject.transform.FindChild("LblTitle")
			.GetComponent<UILabel>().text = mContestList[index].contestName;
		item.Target.gameObject.transform.FindChild("LblPrize").FindChild("Label")
			.GetComponent<UILabel>().text = "[fc8535]"+UtilMgr.AddsThousandsSeparator(mContestList[index].rewardValue);
		item.Target.gameObject.transform.FindChild("Button").GetComponent<ItemContestsBtns>()
			.SetContestSeq(mContestList[index].contestSeq);
	}
}
