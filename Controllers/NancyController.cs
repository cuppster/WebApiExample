﻿using System;

namespace ApiRazors
{
	public class SampleModule : Nancy.NancyModule
	{
		public SampleModule()
		{
			Get["/"] = _ => "Hello World!";
		}
	}
}

