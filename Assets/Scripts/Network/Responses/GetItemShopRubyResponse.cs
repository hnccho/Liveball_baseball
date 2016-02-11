using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GetItemShopRubyResponse : BaseResponse {
	List<ItemShopRubyInfo> _data;

	public List<ItemShopRubyInfo> data {
		get {
			return _data;
		}
		set {
			_data = value;
		}
	}
}
