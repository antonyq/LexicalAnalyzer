using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace LexicalAnalyzer
{
	static class Program
	{
		[STAThread]
		static void Main()
		{
            string defaultText = "";
            try
            {
                WebClient webClient = new WebClient();
                Stream response = webClient.OpenRead("http://javascriptbook.com/code/c03/js/object-literal.js");
                StreamReader reader = new StreamReader(response);
                defaultText = reader.ReadToEnd();
            }
            finally
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                LexForm myForm = new LexForm(defaultText);
                Application.Run(myForm);
            }
		}
	}
}
