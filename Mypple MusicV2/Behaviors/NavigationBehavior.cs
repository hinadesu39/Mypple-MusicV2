using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Mypple_MusicV2.Behaviors
{
    public class NavigationBehavior : Behavior<TreeView>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.SelectedItemChanged += AssociatedObject_SelectedItemChanged;
        }


        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.SelectedItemChanged -= AssociatedObject_SelectedItemChanged;
        }

        private void AssociatedObject_SelectedItemChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<object> e)
        {
            var treeView = sender as TreeView;
            var item = treeView!.ItemContainerGenerator.ContainerFromItem(e.NewValue) as TreeViewItem;
            if (item != null && item.HasItems)
            {
                item.IsExpanded = !item.IsExpanded;
            }
        }

    }
}
