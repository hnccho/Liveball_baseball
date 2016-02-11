using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GetMailResponse : BaseResponse {
	List<Mailinfo> _data = new List<Mailinfo> ();

	public List<Mailinfo> data
	{
		get{ return _data;}
		set{ _data = value;}
	}
}
