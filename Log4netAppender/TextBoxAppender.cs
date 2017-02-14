using log4net.Appender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Core;
using System.Windows.Forms;
using System.Drawing;

namespace idv.kuruwa.Log4netAppender
{
    public class TextBoxAppender : AppenderSkeleton
    {
        private RichTextBox _textBox;
        public string FormName { get; set; }
        public string TextBoxName { get; set; }

        protected override void Append(LoggingEvent loggingEvent)
        {
            if (_textBox == null)
                if (String.IsNullOrEmpty(FormName) ||
                    String.IsNullOrEmpty(TextBoxName))
                    return;

            Form form = Application.OpenForms[FormName];
            if (form == null)
                return;

            _textBox = FindControlRecursive(form, TextBoxName) as RichTextBox;
            if (_textBox == null)
                return;

            form.FormClosing += (s, e) => _textBox = null;

            if (_textBox.InvokeRequired)
            {
                _textBox.Invoke((MethodInvoker)(
                    () => { AppendText(loggingEvent); }));
            }
            else
            {
                AppendText(loggingEvent);
            }
        }

        private void AppendText(LoggingEvent loggingEvent)
        {
            if (loggingEvent.Level.Name == "ERROR" ||
                loggingEvent.Level.Name == "FATAL")
                _textBox.SelectionColor = Color.Red;
            else
                _textBox.SelectionColor = Color.Black;

            _textBox.AppendText(base.RenderLoggingEvent(loggingEvent));
            _textBox.ScrollToCaret();
        }

        private Control FindControlRecursive(Control root, string name)
        {
            if (root.Name == name) return root;
            foreach (Control c in root.Controls)
            {
                Control t = FindControlRecursive(c, name);
                if (t != null) return t;
            }
            return null;
        }
    }
}
