﻿using System.Threading.Tasks;
using Xamarin.Forms.Xaml;
using XF.Material.Forms.UI.Dialogs.Configurations;

namespace XF.Material.Forms.UI.Dialogs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MaterialLoadingDialog : BaseMaterialModalPage
    {
        internal MaterialLoadingDialog(string message, MaterialLoadingDialogConfiguration configuration)
        {
            this.InitializeComponent();
            this.Configure(configuration);
            Message.Text = message;
        }

        public override bool Dismissable => false;

        internal static MaterialLoadingDialogConfiguration GlobalConfiguration { get; set; }

        internal static async Task<IMaterialModalPage> Loading(string message, MaterialLoadingDialogConfiguration configuration = null)
        {
            var dialog = new MaterialLoadingDialog(message, configuration);
            await dialog.ShowAsync();

            return dialog;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            LoadingImage.Play();
        }

        private void Configure(MaterialLoadingDialogConfiguration configuration)
        {
            var preferredConfig = configuration ?? GlobalConfiguration;

            if (preferredConfig != null)
            {
                this.BackgroundColor = preferredConfig.ScrimColor;
                Container.CornerRadius = preferredConfig.CornerRadius;
                Container.BackgroundColor = preferredConfig.BackgroundColor;
                Message.TextColor = preferredConfig.MessageTextColor;
                Message.FontFamily = preferredConfig.MessageFontFamily;
                LoadingImage.TintColor = preferredConfig.TintColor;
            }
        }


        public override void SetMessageText(string text)
        {
            Message.Text = text;
        }
    }
}