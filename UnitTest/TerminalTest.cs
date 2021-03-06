﻿using System;
using System.Windows.Controls;
using CmdHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.STAExtensions;

namespace UnitTest
{
	//[TestClass]
	[STATestClass]
	public class TerminalTest
	{
		private TerminalContentMgr t;

		[TestInitialize]
		public void Init()
		{
			t = new TerminalContentMgr(new TextBoxMock());
		}

		[TestMethod]
		public void TestAppendOutput()
		{
			string msg = "Windows [version 10]\n2017\nc:\\>";
			t.AppendOutput(msg);

			Assert.AreEqual(msg.Length, t.DataLen);
			Assert.AreEqual(msg.Length, t.CaretIndex);
		}

		[TestMethod]
		public void AppendTextTest()
		{
			string msg = "Windows [version 10]\n2017\nc:\\>";
			t.AppendOutput(msg);

			string input = "net user";
			t.AppendText(input);

			Assert.AreEqual(msg.Length, t.DataLen);
			Assert.AreEqual(input, t.GetCmd());
		}

		[TestMethod]
		public void SetInputTest()
		{
			string msg = "Windows [version 10]\n2017\nc:\\>";
			t.AppendOutput(msg);

			t.AppendText("extra");
			string input = "net user";
			t.SetInput(input);

			Assert.AreEqual(msg.Length, t.DataLen);
			Assert.AreEqual(msg + input, t.Text);
		}
	}
}
