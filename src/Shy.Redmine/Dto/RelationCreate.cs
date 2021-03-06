﻿using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
	public class RelationCreate
	{
		[JsonProperty("issue_to_id")]
		public long IssueToId { get; set; }

		[JsonProperty("relation_type")]
		public string RelationType { get; set; }
	}
}