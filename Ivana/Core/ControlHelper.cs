using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace Ivana.Core
{
    public static class ControlHelper
    {
        static public void ForEachVisual(this Visual control, Action<Visual> action)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(control); i++)
            {
                Visual childVisual = (Visual)VisualTreeHelper.GetChild(control, i);

                action(childVisual);

                ForEachVisual(childVisual, action);
            }
        }

        static public void FindControlByName(this Visual visual, string controlName, Action<Visual> action)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(visual); i++)
            {
                Visual childVisual = (Visual)VisualTreeHelper.GetChild(visual, i);

                if (childVisual is Control ctrl)
                {
                    if (ctrl.Name == controlName)
                    {
                        action(ctrl);
                        return;
                    }
                }
                
                if (childVisual is ContentControl contentCtrl)
                {
                    if(contentCtrl.Content is Control _ctrl)
                    {
                        if (_ctrl.Name == controlName)
                        {
                            action(_ctrl);
                            return;
                        }
                    }
                }

                FindControlByName(childVisual, controlName, action);
            }
        }
    }
}
