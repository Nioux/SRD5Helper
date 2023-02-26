using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SRD5Helper.Tools;

public static class Helpers
{
    public static TView Trigger<TView>(this TView view, TriggerBase trigger) where TView : View
    {
        view.Triggers.Add(trigger);
        return view;
    }

    public static string NameOf<T>(Expression<Func<T>> pathExpr)
    {
        var members = new Stack<string>();
        for (var memberExpr = pathExpr.Body as MemberExpression; memberExpr != null; memberExpr = memberExpr.Expression as MemberExpression)
        {
            members.Push(memberExpr.Member.Name);
        }
        return string.Join(".", members);
    }


}
