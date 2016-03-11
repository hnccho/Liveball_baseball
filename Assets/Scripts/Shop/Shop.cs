using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shop : MonoBehaviour {

	public enum TYPE{
		GOLD,
		TICKET,
		CARD,
		SKILL
	}
	List<ItemShopGoldInfo> mList;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void InitShop(string title, List<ItemShopGoldInfo> list, TYPE type){
		mList = list;
		transform.FindChild("Top").FindChild("LblShop").GetComponent<UILabel>().text = title;

		UIScrollView scrollview = transform.FindChild("Body").FindChild("Scroll View").GetComponent<UIScrollView>();
		foreach(ItemShopGoldInfo shopInfo in mList){
			int id = shopInfo.productId;
			if(type == TYPE.GOLD){

			} else if(type == TYPE.TICKET){

			} else if(type == TYPE.CARD){

			} else if(type == TYPE.SKILL){

			}
		}
	}
}
