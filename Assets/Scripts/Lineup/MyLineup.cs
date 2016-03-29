using UnityEngine;
using System.Collections;

public class MyLineup : MonoBehaviour {

	public GetLineupEvent mLineupEvent;
	EditLineupEvent mEditEvent;
	public bool IsDeletable;
	LineupInfo mLineup;
	string mName;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Init(){
		IsDeletable = false;
		transform.localPosition = new Vector3(2000f, 2000f);
		transform.gameObject.SetActive(true);
		transform.FindChild("Rename").gameObject.SetActive(false);

		mLineupEvent = new GetLineupEvent(ReceivedLineup);
		NetMgr.GetLineup(mLineupEvent);
	}

	public void Reload(){
		transform.FindChild("Top").FindChild("LblMyLineup").GetComponent<UILabel>().text
			= UtilMgr.GetLocalText("LblMyLineup") + " [00a0e9]["+mLineupEvent.Response.data.Count+"/50]";

		transform.FindChild("Body").FindChild("Draggable").GetComponent<UIDraggablePanel2>().RemoveAll();
		UtilMgr.ClearList(transform.FindChild("Body").FindChild("Draggable"));
		transform.FindChild("Body").FindChild("Draggable").GetComponent<UIDraggablePanel2>()
			.Init(mLineupEvent.Response.data.Count, delegate(UIListItem item, int index) {
				InitItem(item, index);
			});
		transform.FindChild("Body").FindChild("Draggable").GetComponent<UIDraggablePanel2>().ResetPosition();
	}

	void ReceivedLineup(){
		transform.FindChild("Top").FindChild("LblMyLineup").GetComponent<UILabel>().text
			= UtilMgr.GetLocalText("LblMyLineup") + " [00a0e9]["+mLineupEvent.Response.data.Count+"/50]";

		UtilMgr.ClearList(transform.FindChild("Body").FindChild("Draggable"));
		transform.FindChild("Body").FindChild("Draggable").GetComponent<UIDraggablePanel2>()
			.Init(mLineupEvent.Response.data.Count, delegate(UIListItem item, int index) {
				InitItem(item, index);
			});
		transform.FindChild("Body").FindChild("Draggable").GetComponent<UIDraggablePanel2>().ResetPosition();

		UtilMgr.AddBackState(UtilMgr.STATE.Lineup);
		UtilMgr.AnimatePageToLeft("RegisterEntry", "Lineup");
	}

	void InitItem(UIListItem item, int index){
		LineupInfo info = mLineupEvent.Response.data[index];
		item.Target.GetComponent<ItemLineup>().mLineupInfo = info;
		
		item.Target.transform.FindChild("Normal").FindChild("LblName").GetComponent<UILabel>().text = info.name;
		int width = item.Target.transform.FindChild("Normal").FindChild("LblName").GetComponent<UILabel>().width;
		item.Target.transform.FindChild("Normal").FindChild("LblName").FindChild("BtnEdit").
			localPosition = new Vector3(width+40f, 0);
		item.Target.transform.FindChild("Delete").FindChild("LblName").GetComponent<UILabel>().text = info.name;
		item.Target.transform.FindChild("Normal").FindChild("LblValue").GetComponent<UILabel>().text = info.entryPlayers;
		item.Target.transform.FindChild("Delete").FindChild("LblValue").GetComponent<UILabel>().text = info.entryPlayers;
	}

	public void ShowEditBox(LineupInfo lineup){
		mLineup = lineup;
		transform.FindChild("Rename").gameObject.SetActive(true);
		transform.root.GetComponent<LandingRoot>().mPopup = transform.FindChild("Rename").gameObject;
		transform.FindChild("Rename").FindChild("Box").FindChild("Input").GetComponent<UIInput>().value = lineup.name;
	}

	public void DismissEditBox(){
		transform.root.GetComponent<LandingRoot>().OnBackPressed();
	}

	public void SubmitEditBox(){
		mEditEvent = new EditLineupEvent(ReceivedEdit);
		mName = transform.FindChild("Rename").FindChild("Box").FindChild("Input").GetComponent<UIInput>().value;
		NetMgr.EditLineup(mName, mLineup.lineupSeq, mEditEvent);
	}

	void ReceivedEdit(){
		DismissEditBox();
		for(int i = 0; i < mLineupEvent.Response.data.Count; i++){
			if(mLineup.lineupSeq == mLineupEvent.Response.data[i].lineupSeq){
				mLineupEvent.Response.data[i].name = mName;
				Reload();
				break;
			}
		}
	}
}
