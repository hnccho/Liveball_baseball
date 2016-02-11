using UnityEngine;
using System.Collections;
using System.Text;

public class GetEventsRequest : BaseNanooRequest {

	public GetEventsRequest(API_TYPE apiType)
	{
		mType = apiType;
//		mParam = Constants.QUERY_SERVER_NANOO + "/v1/news/event?";
		mParam = Constants.QUERY_SERVER_NANOO + "/v1/news/event";
	}
}
