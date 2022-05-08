using Bluestone.Mobile.Presentation.Animations.Base;
using Xamarin.Forms;

namespace Bluestone.Mobile.Presentation.Triggers
{
    public class BeginAnimation : TriggerAction<VisualElement>
    {
        public AnimationBase Animation { get; set; }

        protected override async void Invoke(VisualElement sender)
        {
            if (Animation != null)
                await Animation.Begin();
        }
    }
}