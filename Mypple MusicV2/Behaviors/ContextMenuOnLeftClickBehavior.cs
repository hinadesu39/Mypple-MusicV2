
using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Mypple_MusicV2.Behaviors
{
    public class ContextMenuOnLeftClickBehavior : Behavior<Button>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Click += OnButtonClick;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.Click -= OnButtonClick;
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            ShowContextMenu();
        }


        private void ShowContextMenu()
        {
            if (AssociatedObject.ContextMenu != null)
            {
                //AssociatedObject.ContextMenu.PlacementTarget = AssociatedObject;
                //AssociatedObject.ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
                AssociatedObject.ContextMenu.IsOpen = true;
            }
        }
    }
}
