using UnityEngine;
using System.Collections;

public class TopCard : MonoBehaviour 
{
	public PlayerInfo mPlayerInfo;

	void OnClick()
	{
		if(mPlayerInfo == null) return;

		Com.LOOG("OnClick", transform.name);
		transform.root.FindChild("PlayerCard").GetComponent<PlayerCard>()
		.Init(mPlayerInfo, Com.FindTransform(transform, "Texture").GetComponent<UITexture>().mainTexture);
	}
}
