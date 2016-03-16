using UnityEngine;
using System.Collections;

public class RegisterEntry : MonoBehaviour {

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
				.GetChild(i).GetComponent<BtnPosition>().SetUndesignated();

			GameObject go = Instantiate(mRegItem);
			go.transform.parent = transform.FindChild("List").FindChild("Scroll View");
			go.transform.localPosition = new Vector3(0, height - (136f * i), 0);
			go.transform.localScale = new Vector3(1f, 1f, 1f);
			go.transform.FindChild("Label").GetComponent<UILabel>().text = (i+1)+"";
			go.transform.GetComponent<ItemPosition>().SetUndesignated();
		}
		transform.FindChild("List").FindChild("Scroll View").GetComponent<UIScrollView>().ResetPosition();
	}

	public void SetDesignated(PlayerInfo info){
		switch(transform.root.FindChild("SelectPlayer").GetComponent<SelectPlayer>().mSelectedNo){
		case 1: transform.FindChild("Ground").FindChild("BtnPosition")
			.FindChild("BtnP").GetComponent<BtnPosition>().SetDesignated(info);	break;
		case 2: transform.FindChild("Ground").FindChild("BtnPosition")
			.FindChild("BtnC").GetComponent<BtnPosition>().SetDesignated(info);	break;
		case 3: transform.FindChild("Ground").FindChild("BtnPosition")
			.FindChild("Btn1B").GetComponent<BtnPosition>().SetDesignated(info);	break;
		case 4: transform.FindChild("Ground").FindChild("BtnPosition")
			.FindChild("Btn2B").GetComponent<BtnPosition>().SetDesignated(info);	break;
		case 5: transform.FindChild("Ground").FindChild("BtnPosition")
			.FindChild("Btn3B").GetComponent<BtnPosition>().SetDesignated(info);	break;
		case 6: transform.FindChild("Ground").FindChild("BtnPosition")
			.FindChild("BtnSS").GetComponent<BtnPosition>().SetDesignated(info);	break;
		case 7: transform.FindChild("Ground").FindChild("BtnPosition")
			.FindChild("BtnLF").GetComponent<BtnPosition>().SetDesignated(info);	break;
		case 8: transform.FindChild("Ground").FindChild("BtnPosition")
			.FindChild("BtnCF").GetComponent<BtnPosition>().SetDesignated(info);	break;
		case 9: transform.FindChild("Ground").FindChild("BtnPosition")
			.FindChild("BtnRF").GetComponent<BtnPosition>().SetDesignated(info);	break;
		}

		for(int i = 0; i < transform.FindChild("List").FindChild("Scroll View").childCount; i++){
			int pos = int.Parse(transform.FindChild("List").FindChild("Scroll View")
			                    .GetChild(i).FindChild("Label").GetComponent<UILabel>().text);
			if(pos == transform.root.FindChild("SelectPlayer").GetComponent<SelectPlayer>().mSelectedNo){
				transform.FindChild("List").FindChild("Scroll View")
					.GetChild(i).GetComponent<ItemPosition>().SetDesignated(info);
				break;
			}
		}
	}
}
