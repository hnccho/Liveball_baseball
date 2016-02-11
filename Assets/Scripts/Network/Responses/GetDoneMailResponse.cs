using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GetDoneMailResponse : BaseResponse {
	DoneMailinfo _data;

	public DoneMailinfo data
	{
		get{ return _data;}
		set{ _data = value;}
	}
}
