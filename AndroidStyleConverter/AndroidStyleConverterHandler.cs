using MonoDevelop.Components.Commands;
using MonoDevelop.Ide;
using System;
using System.Text;
using System.Text.RegularExpressions;
using Xwt;

namespace AndroidStyleConverter
{
    class AndroidStyleConverterHandler : CommandHandler
    {
		private static string pattern = "(\\w+:\\w+)=\"(.*)\"";

		protected override void Run()
		{
			var editor = IdeApp.Workbench.ActiveDocument.Editor;
			var date = DateTime.Now.ToString();

			var selection = editor.SelectionRegion;
			var segment = selection.GetSegment(editor);
			var selectionString = editor.GetTextAt(segment.Offset, segment.Length);

			var styles = selectionString.Split('\n');

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < styles.Length - 1; i++)
            {
				var style = styles[i].Trim();;
				var styleKey = style.Split('=')[0].Trim();;
				var styleValue = style.Split('=')[1].Replace("\"","").Trim();;

                sb.AppendFormat("<item name=\"{0}\">{1}</item>\n", styleKey, styleValue);
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