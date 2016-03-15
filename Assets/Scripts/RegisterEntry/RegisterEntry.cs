using UnityEngine;
using System.Collections;

public class RegisterEntry : MonoBehaviour {

	string[] mPositions = {"P", "C", "1B", "2B", "3B", "SS", "LF", "CF", "RF"};
	public GameObject mRegItem;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void InitRegisterEntry(){

		float height = 136f*8f;
		for(int i = 0; i < transform.FindChild("Ground").FindChild("BtnPosition").childCount; i++){
			transform.FindChild("Ground").FindChild("BtnPosition")
				.GetChild(i).FindChild("Designated").gameObject.SetActive(false);

			GameObject go = Instantiate(mRegItem);
			go.transform.parent = transform.FindChild("List").FindChild("Scroll View");
			go.transform.localPosition = new Vector3(0, height - (136f * i), 0);
			go.transform.localScale = new Vector3(1f, 1f, 1f);
			go.transform.FindChild("Label").GetComponent<UILabel>().text = i+"";
			go.transform.FindChild("Undesignated").FindChild("LblDesignated")
					.GetComponent<UILabel>().text = "[333333]Select [-][006AD8][b]" + mPositions[i];
			//
			go.transform.FindChild("Designated").gameObject.SetActive(false);
			go.transform.FindChild("Undesignated").gameObject.SetActive(true);
			//

		}

//		transform.FindChild("List").FindChild("Draggable").GetComponent<UIDraggablePanel2>()
//			.Init (9, delegate (UIListItem item, int index){
//				item.Target.transform.FindChild("Undesignated").FindChild("LblDesignated")
//					.GetComponent<UILabel>().text = "[333333]Select [-][006AD8][b]" + mPositions[index];
//
//				item.Target.transform.FindChild("Designated").gameObject.SetActive(false);
//				item.Target.transform.FindChild("Undesignated").gameObject.SetActive(true);
//			});




		transform.FindChild("List").FindChild("Scroll View").GetComponent<UIScrollView>().ResetPosition();
	}
}
