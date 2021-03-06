﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonTools;
using System.Windows.Forms;
using System.Drawing;

namespace CommonToolsWin
{
    public static class CTWin
    {
        public enum eCloseFormsMethod { ALL, ALLEXCEPT, LIST };

        public static DialogResult InputBox(string title, string promptText, ref string value, bool Password = false)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            if (Password)
            {
                textBox.PasswordChar = '·';
            }

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }


        public static void MsgError(string pMsg)
        {
            MessageBox.Show(pMsg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void CloseFormsByName(eCloseFormsMethod eClose = eCloseFormsMethod.ALL, string pFormNames = "")
        {
            if (pFormNames != "")
                pFormNames = pFormNames + (pFormNames.Substring(pFormNames.Length - 1, 1) != "|" ? "|" : "");

            Form[] forms = Application.OpenForms.Cast<Form>().ToArray();
            foreach (Form thisForm in forms)
            {
                if (eClose == eCloseFormsMethod.ALL || eClose == eCloseFormsMethod.ALLEXCEPT && pFormNames.IndexOf(thisForm.Name+"|")==-1 || eClose == eCloseFormsMethod.LIST && pFormNames.IndexOf(thisForm.Name + "|") != -1)
                    thisForm.Close();
            }
        }
    }

}
