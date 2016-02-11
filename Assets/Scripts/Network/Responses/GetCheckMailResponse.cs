using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GetCheckMailResponse : BaseResponse {
	CheckMailbox _data;

	public CheckMailbox data
	{
		get{ return _data;}
		set{ _data = value;}
	}
}
