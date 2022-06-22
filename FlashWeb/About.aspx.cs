using System;
using System.Reflection;
using System.Web.UI;

namespace FlashWeb
{
	public partial class About : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Label1.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();

		}
	}
}