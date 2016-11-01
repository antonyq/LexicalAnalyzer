using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;

namespace LexicalAnalyzer
{
	class Parser
	{
		public Dictionary<string, Tuple<Regex, Color>> Lexems = new Dictionary<string, Tuple<Regex, Color>>()
		{
			{ "numbers", new Tuple<Regex, Color>(
                new Regex(@"[^a-zA-Z0-9\.]([1-9]{1}[0-9]*\.[0-9]+|0x[0-9A-F]+|[1-9]{1}[0-9]*)", RegexOptions.Compiled), 
                Color.DarkMagenta) },
			{ "literals", new Tuple<Regex, Color>(
                new Regex("('.+?')|(\".+?\")", RegexOptions.Compiled), 
                Color.DarkSalmon)
            }, 
			{ "comments", new Tuple<Regex, Color>(
                new Regex(@"(/\*[\s\S]*?\*/|//.*\n)", RegexOptions.Compiled), 
                Color.SlateGray)
            }, 
			{ "keywords", new Tuple<Regex, Color>(
                new Regex(@"[\}\s\n\t;\{]{1}(break|case|catch|class|const|continue|debugger|default|delete|do|else|export|extends|finally|for|function|if|import|in|instanceof|new|return|super|switch|this|throw|try|typeof|var|void|while|with|yield)[\.\s\{\(;]{1}", RegexOptions.Compiled),
                Color.Aqua) 
            },
			{ "operators", new Tuple<Regex, Color>(
                new Regex(@"([-=/!<>/%:?\+\*\&\|]{1}|[-=\+\*\&\|]{2}|[-/%\+\*\!]{1}=|[!=]{1}==)", RegexOptions.Compiled),
                Color.Crimson)
            },
			{ "delimiters", new Tuple<Regex, Color>(
                new Regex(@"([,;\{\}\(\)]+)", RegexOptions.Compiled),
                Color.RoyalBlue)
            },
			{ "identificators", new Tuple<Regex, Color>(
				new Regex(@"(?:var|let|const|function)\s([a-zA-Z\$]{1}[a-zA-Z0-9\$]*)[;=\(\s]{1}", RegexOptions.Compiled),
 				Color.SpringGreen) 
			} 
		};
	}
}
