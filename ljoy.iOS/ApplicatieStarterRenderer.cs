using System;
using ljoy.applicatie;
using ljoy.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ApplicatieStarter), typeof(ApplicatieStarterRenderer))]
namespace ljoy.iOS
{
    public class ApplicatieStarterRenderer : TabbedRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            TabBar.TintColor = UIColor.Black;
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            if (TabBar.Items != null)
            {
                var items = TabBar.Items;
                for (int i = 0; i < items.Length; i++)
                {
                    items[i].Image = items[i].Image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
                    items[i].SetTitleTextAttributes(new UITextAttributes() { TextColor = UIColor.Black }, UIControlState.Normal);
                }
            }
        }
    }
}