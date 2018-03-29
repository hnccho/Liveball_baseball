using UnityEngine;
using System.Collections;

public class RTDirectionBtns : MonoBehaviour 
{

	public void OnClick()
	{
		ItemRT itemrt = Com.FindParent<ItemRT>(transform);
		string[] arr = itemrt.name.Split('_');
		int index = int.Parse(arr[1]);

		if(RTLobby.sRTLobby.page > 0 && RTLobby.sRTLobby.page == index + 1)
		{
/*
			transform.parent.parent.parent.GetComponent<UICenterOnChild>().enabled = true;
	//		transform.parent.parent.parent.GetComponent<UICenterOnChild>().onFinished = OnFinished;
			if(name.Equals("BtnLeft")){
				Vector3 ori = transform.parent.parent.parent.localPosition;
				transform.parent.parent.parent.localPosition = new Vector3(ori.x + 720f, ori.y, ori.z);
				Vector2 offset = transform.parent.parent.parent.GetComponent<UIPanel>().clipOffset;
				transform.parent.parent.parent.GetComponent<UIPanel>().clipOffset = new Vector2(offset.x - 720f, offset.y);
			} else if(name.Equals("BtnRight")){
				Vector3 ori = transform.parent.parent.parent.localPosition;
				transform.parent.parent.parent.localPosition = new Vector3(ori.x - 720f, ori.y, ori.z);
				Vector2 offset = transform.parent.parent.parent.GetComponent<UIPanel>().clipOffset;
				transform.parent.parent.parent.GetComponent<UIPanel>().clipOffset = new Vector2(offset.x + 720f, offset.y);
			}
			transform.parent.parent.parent.GetComponent<UICenterOnChild>().Recenter();
*/


			SpringPanel spring = Com.FindParent<SpringPanel>(transform);
			if(name.Equals("BtnLeft"))
				spring.target = new Vector3((RTLobby.sRTLobby.page-2) * -720f, spring.target.y, spring.target.z);
			else if(name.Equals("BtnRight"))
				spring.target = new Vector3((RTLobby.sRTLobby.page) * -720f, spring.target.y, spring.target.z);
			spring.onFinished = OnFinished_spring;				// insert delegate
			spring.strength = 20;								// default:8
			spring.enabled = true;

		}
	}

//	void OnFinished(){
//		transform.parent.parent.parent.GetComponent<UICenterOnChild>().enabled = false;
//	}


	void OnFinished_spring()
	{
		transform.parent.parent.parent.GetComponent<UICenterOnChild>().Recenter();
	}
}
