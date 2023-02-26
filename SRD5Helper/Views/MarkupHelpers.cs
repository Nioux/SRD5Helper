using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRD5Helper.Views;

public static class MarkupHelpers
{
    public class InlineTriggerAction<T> : TriggerAction<T> where T : BindableObject
    {
        public Action<T> OnInvoke;
        protected override void Invoke(T sender)
        {
            OnInvoke?.Invoke(sender);
        }
    }

    public static TriggerBase GetEventActionTrigger<TBindableObject>(string eventTrigger, Action<TBindableObject> onInvoke) where TBindableObject : View
    {
        var trigger = new EventTrigger()
        {
            Event = eventTrigger,
        };
        trigger.Actions.Add(new InlineTriggerAction<TBindableObject>
        {
            OnInvoke = onInvoke
        });
        return trigger;
    }

    public static Button ShadowClickEffect(this Button button)
    {
        //(button.Parent as View).Shadow = new Shadow { Brush = Brush.White, Opacity = 0.5f, Offset = new Point(10, 10), };
        button.Pressed += (sender, e) =>
        {
            var border = (sender as Element).Parent as VisualElement;
            border.TranslateTo(5, 5, 100);
            border.Animate("Out", new Animation((d) => border.Shadow.Offset = new Point(0 + d, 0 + d)), 1, 10);
            //border.TranslationX = 5;
            //border.TranslationY = 5;
            //border.Shadow.Offset = new Point(5, 5);
        };
        button.Released += (sender, e) =>
        {
            var border = (sender as Element).Parent as VisualElement;
            border.TranslateTo(0, 0, 100);
            border.Animate("In", new Animation((d) => border.Shadow.Offset = new Point(10 - d, 10 - d)), 1, 10);
            //border.TranslationX = 0;
            //border.TranslationY = 0;
            //border.Shadow.Offset = new Point(10, 10);
        };
        return button;
    }
    public static ImageButton ShadowClickEffect(this ImageButton button)
    {
        //(button.Parent as View).Shadow = new Shadow { Brush = Brush.White, Opacity = 0.5f, Offset = new Point(10, 10), };
        button.Pressed += (sender, e) =>
        {
            var border = (sender as Element).Parent as VisualElement;
            border.TranslateTo(5, 5, 500);
            //border.TranslationX = 5;
            //border.TranslationY = 5;
            border.Shadow.Offset = new Point(5, 5);
        };
        button.Released += (sender, e) =>
        {
            var border = (sender as Element).Parent as VisualElement;
            border.TranslateTo(0, 0, 500);
            //border.TranslationX = 0;
            //border.TranslationY = 0;
            border.Shadow.Offset = new Point(10, 10);
        };
        return button;
    }
    public static Label ShadowClickEffectTest(this Label label)
    {
        label.GestureRecognizers.Add(new GestureRecognizer() {  });
        return label;
    }
}