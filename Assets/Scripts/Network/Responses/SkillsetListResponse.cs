using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkillsetListResponse : BaseResponse {
	List<SkillsetInfo> _data;

	public List<SkillsetInfo> data
	{
		get{ return _data;}
		set{ _data = value;}
	}
}
