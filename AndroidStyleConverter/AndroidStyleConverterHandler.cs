using MonoDevelop.Components.Commands;
using MonoDevelop.Components.Extensions;
using MonoDevelop.Ide;
using MonoDevelop.Ide.Gui;
using System;
using System.Text;
using System.Text.RegularExpressions;
using Xwt;

namespace AndroidStyleConverterCommands
{
    class AndroidStyleConverterHandler : CommandHandler
    {
		private static string pattern = "(\\w+:*\\w+)=\"(.*)\"";

		protected override void Run()
		{
			var editor = IdeApp.Workbench.ActiveDocument.Editor;
			var date = DateTime.Now.ToString();

			var selection = editor.SelectionRegion;
			var segment = selection.GetSegment(editor);
			var selectionString = editor.GetTextAt(segment.Offset, segment.Length);
  
			MatchCollection matches = Regex.Matches(selectionString, pattern);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < matches.Count - 1; i+=2)
            {
                sb.AppendFormat("<item name=\"{0}\">{1}</item>\n\t", matches[i].Value, matches[i + 1].Value);
            }

			Clipboard.SetText(sb.ToString());

			//editor.ReplaceText(segment.Offset, segment.Length, sb.ToString());
		}

        protected override void Update(CommandInfo info)
        {         
			info.Enabled = IdeApp.Workbench.ActiveDocument?.Editor != null;
        }
    }

	public enum AndroidStyleConverterCommands
    {
		ConvertToStyles
    }
}