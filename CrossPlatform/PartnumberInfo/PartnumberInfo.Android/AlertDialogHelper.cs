﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading;


namespace PartnumberInfo.Droid
{
    public class AlertDialogHelper : Java.Lang.Object, IDialogInterfaceOnDismissListener
    {
        Context context;
        ManualResetEvent waitHandle;
        string title;
        string message;
        string positiveButtonCaption;
        string negativeButtonCaption;
        bool dialogResult;

        public static async Task<bool> ShowAsync(Context context, string title, string message)
        {
            return await AlertDialogHelper.ShowAsync(context, title, message, "OK", "Cancel");
        }

        public static async Task<bool> ShowAsync(Context context, string title, string message, string positiveButton, string negativeButton)
        {
            return await new AlertDialogHelper(context, title, message, positiveButton, negativeButton).ShowAsync();
        }

        private AlertDialogHelper(Context context, string title, string message, string positiveButton, string negativeButton)
        {
            this.context = context;
            this.title = title;
            this.message = message;
            this.positiveButtonCaption = positiveButton;
            this.negativeButtonCaption = negativeButton;
        }

        private async Task<bool> ShowAsync()
        {
            this.waitHandle = new ManualResetEvent(false);
            var ad = new AlertDialog.Builder(this.context)
                .SetTitle(this.title)
                .SetMessage(this.message)
                .SetPositiveButton(this.positiveButtonCaption, OnPositiveClick)
                //
                .SetOnDismissListener(this);
            //.Show();
            if (negativeButtonCaption != "")
                ad.SetNegativeButton(this.negativeButtonCaption, OnNegativeClick);
            ((Activity)context).RunOnUiThread(() => ad.Show());
            Task<bool> dialogTask = new Task<bool>(() =>
            {
                this.waitHandle.WaitOne();
                return this.dialogResult;
            });
            dialogTask.Start();
            return await dialogTask;
        }

        private void OnPositiveClick(object sender, DialogClickEventArgs e)
        {
            this.dialogResult = true;
            this.waitHandle.Set();
        }

        private void OnNegativeClick(object sender, DialogClickEventArgs e)
        {
            this.dialogResult = false;
            this.waitHandle.Set();
        }

        public void OnDismiss(IDialogInterface dialog)
        {
            this.dialogResult = false;
            this.waitHandle.Set();
        }
    }
}