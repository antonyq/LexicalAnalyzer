using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LexicalAnalyzer
{
	public partial class LexForm : Form
	{
        private Parser parser;
        private DateTime lastUpdateTime;


		public LexForm()
		{
			InitializeComponent();
            parser = new Parser();
		}

        public LexForm (string text)
		{
			InitializeComponent();
            parser = new Parser();
            richTextBox1.Text = text;
		}

		private void richTextBox1_TextChanged(object sender, EventArgs e)
		{
			ColorString(richTextBox1.Text, richTextBox1.ForeColor);
			PaintLexems();
		}

        private void ColorString (string word, Color color, int startIndex = 0)
        {
            if (word.Length == 0) return;
            if (richTextBox1.Text.Contains(word))
            {
                int index = -1;
                int selectStart = richTextBox1.SelectionStart;

                while ((index = richTextBox1.Text.IndexOf(word, (index + 1))) != -1)
                {
                    richTextBox1.Select((index + startIndex), word.Length);
                    richTextBox1.SelectionColor = color;
                    richTextBox1.Select(selectStart, 0);
                }
            }
        }

        private void ColorLexem (string lexem)
        {
            var tuple = parser.Lexems[lexem];
            ColorMatchCollection(tuple.Item1.Matches(richTextBox1.Text), tuple.Item2);
        }

        private void ColorMatchCollection (MatchCollection matchCollection, Color color)
        {
            foreach (Match match in matchCollection)
            {
                if (match.Groups[1].Value != "")
                    ColorString(match.Groups[1].Value, color);
                else if (match.Groups[0].Value != "")
                    ColorString(match.Groups[0].Value, color);
            }
        }

		private void PaintLexems ()
        {
            ColorLexem("delimiters");
            ColorLexem("numbers");
            ColorLexem("operators");
			ColorLexem("identificators");

			ColorLexem("keywords");

            ColorLexem("literals");
            
            ColorLexem("comments");
            
        }
	}
}
