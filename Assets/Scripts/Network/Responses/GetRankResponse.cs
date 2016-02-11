using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GetRankResponse : BaseResponse {
	List<ContestRankingInfo> _data;
	
	public List<ContestRankingInfo> data
	{
		get{ return _data;}
		set{ _data = value;}
	}
//	Rankinfo _data;
//
//	public Rankinfo data
//	{
//		get{ return _data;}
//		set{ _data = value;}
//	}
}
