using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GetItemShopGoldResponse : BaseResponse {
	List<ItemShopGoldInfo> _data;

	public List<ItemShopGoldInfo> data {
		get {
			return _data;
		}
		set {
			_data = value;
		}
	}
}
