using UnityEngine;
using System.Collections;

public class MyLineup : MonoBehaviour {

	public GetLineupEvent mLineupEvent;
	public bool IsDeletable;
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

		mLineupEvent = new GetLineupEvent(ReceivedLineup);
		NetMgr.GetLineup(mLineupEvent);
	}

	public void Reload(){
		transform.FindChild("Body").FindChild("Draggable").GetComponent<UIDraggablePanel2>().RemoveAll();
		transform.FindChild("Body").FindChild("Draggable").GetComponent<UIDraggablePanel2>().ResetPosition();
	}

	void ReceivedLineup(){
		transform.FindChild("Top").FindChild("LblMyLineup").GetComponent<UILabel>().text
			= UtilMgr.GetLocalText("LblMyLineup") + " [00a0e9]["+mLineupEvent.Response.data.Count+"/50]";

		UtilMgr.ClearList(transform.FindChild("Body").FindChild("Draggable"));
		transform.FindChild("Body").FindChild("Draggable").GetComponent<UIDraggablePanel2>()
			.Init(mLineupEvent.Response.data.Count, delegate(UIListItem item, int index) {
				LineupInfo info = mLineupEvent.Response.data[index];
				item.Target.GetComponent<ItemLineup>().mLineupInfo = info;

				item.Target.transform.FindChild("Normal").FindChild("LblName").GetComponent<UILabel>().text = info.name;
				item.Target.transform.FindChild("Delete").FindChild("LblName").GetComponent<UILabel>().text = info.name;
				item.Target.transform.FindChild("Normal").FindChild("LblValue").GetComponent<UILabel>().text = info.entryPlayers;
				item.Target.transform.FindChild("Delete").FindChild("LblValue").GetComponent<UILabel>().text = info.entryPlayers;

			});
		transform.FindChild("Body").FindChild("Draggable").GetComponent<UIDraggablePanel2>().ResetPosition();

		UtilMgr.AddBackState(UtilMgr.STATE.Lineup);
		UtilMgr.AnimatePageToLeft("RegisterEntry", "Lineup");
	}

}
