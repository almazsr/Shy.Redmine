﻿using System.Collections;
using System.Linq;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
    public class ProjectUpdate
	{
		[JsonProperty("Name")]
		public string Name { get; set; }

		[JsonProperty("identififier")]
		public string Identifier { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("homepage")]
		public string HomePage { get; set; }

		[JsonProperty("is_public")]
		public string IsPublic { get; set; }

		[JsonProperty("parent_id")]
		public string ParentId { get; set; }

		[JsonProperty("inherit_members")]
		public string InheritMemebers { get; set; }

		[JsonProperty("tracker_ids")]
		public long[] TrackerIds { get; set; }

		[JsonProperty("enabled_module_names")]
		public string[] EnabledModuleNames { get; set; }

		[JsonProperty("issue_custom_field_ids")]
		public long[] CustomFieldIds { get; set; }
	}
}