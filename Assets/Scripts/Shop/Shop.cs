using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shop : MonoBehaviour {

//	public enum TYPE{
//		GOLD,
//		TICKET,
//		CARD,
//		SKILL
//	}
	public GameObject mItemShop;
	public GameObject mItemCard;
	public static int GOLD = 5;
	public static int TICKET = 4;
	public static int CARD = 2;
	public static int SKILL = 3;
	int mCategory;

	List<ItemShopGoldInfo> mList;
	GetItemShopGoldEvent mGoldEvent;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void InitShop(string title, int category){
		transform.FindChild("Top").FindChild("LblShop").GetComponent<UILabel>().text = title;
		mCategory = category;
		UtilMgr.ClearList(transform.FindChild("Body").FindChild("Scroll View"));

		if(category == GOLD){

		} else{
			mGoldEvent = new GetItemShopGoldEvent(ReceiveShop);
			NetMgr.GetItemShopList(category, mGoldEvent);
		}

	}

	void ReceiveShop(){
		mList = mGoldEvent.Response.data;

		float height = 0;
		UIScrollView scrollview = transform.FindChild("Body").FindChild("Scroll View").GetComponent<UIScrollView>();
		for(int i = 0; i < mList.Count; i++){
			ItemShopGoldInfo shopInfo = mList[i];
			GameObject go = null;
			if(mCategory == Shop.CARD){
				go = Instantiate(mItemCard);
				height = -172f;
			} else{
				go = Instantiate(mItemShop);
				height = -136f;
			}
			go.transform.parent = scrollview.transform;
			go.transform.localScale = new Vector3(1f, 1f, 1f);
			go.transform.localPosition = new Vector3(0, height*i, 0);
			go.transform.FindChild("LblTitle").GetComponent<UILabel>().text = shopInfo.productName;
			go.transform.FindChild("LblDesc").GetComponent<UILabel>().text = shopInfo.productDesc;
			if(shopInfo.productDesc.IndexOf("BONUS") > -1)
				go.transform.FindChild("BtnPhoto").FindChild("Bonus").gameObject.SetActive(true);
			else
				go.transform.FindChild("BtnPhoto").FindChild("Bonus").gameObject.SetActive(false);
			go.transform.FindChild("LblPrice").GetComponent<UILabel>().text
				= UtilMgr.AddsThousandsSeparator(shopInfo.price);
			int width = go.transform.FindChild("LblPrice").GetComponent<UILabel>().width;
			Vector3 oriVec = go.transform.FindChild("LblPrice").FindChild("Sprite").localPosition;
			go.transform.FindChild("LblPrice").FindChild("Sprite").localPosition
				= new Vector3(width + 5f, oriVec.y);

			go.transform.FindChild("BtnRight").GetComponent<ShopItemBtns>().mInfo = shopInfo;
		}
		scrollview.ResetPosition();
	}
}
