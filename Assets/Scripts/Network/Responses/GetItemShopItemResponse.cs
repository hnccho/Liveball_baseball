using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GetItemShopItemResponse : BaseResponse {
	List<ItemShopItemInfo> _data;

	public List<ItemShopItemInfo> data {
		get {
			return _data;
		}
		set {
			_data = value;
		}
	}
}
