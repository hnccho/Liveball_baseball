using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GetInvenItemResponse : BaseResponse {
	List<InvenItemInfo> _data = new List<InvenItemInfo> ();

	public List<InvenItemInfo> data
	{
		get{ return _data;}
		set{ _data = value;}
	}
}
