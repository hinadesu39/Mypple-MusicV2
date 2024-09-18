using Microsoft.Extensions.DependencyInjection;
namespace Common
{
    public class NavigationService : INavigationService
    {
        private IServiceProvider serviceProvider;
        private Stack<BaseViewModel> history = new Stack<BaseViewModel>();
        private Stack<BaseViewModel> forwardHistory = new Stack<BaseViewModel>();

        private BaseViewModel currentViewModel;

        public BaseViewModel CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                currentViewModel?.OnNavigationFrom();
                currentViewModel = value;
                CurrentViewModelChanged.Invoke();
            }
        }

        public event Action CurrentViewModelChanged;

        public NavigationService(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void NavigationTo<T>(Dictionary<string, object>? parameters = null)
            where T : BaseViewModel
        {
            CurrentViewModel = serviceProvider.GetService<T>()!;

            if (CurrentViewModel != null)
            {
                history.Push(CurrentViewModel);
                CurrentViewModel!.OnNavigationTo(parameters);
            }

            forwardHistory.Clear();
        }

        public void NavigationTo(Type ViewModeltype, Dictionary<string, object>? parameters = null)
        {
            CurrentViewModel = (BaseViewModel)serviceProvider.GetService(ViewModeltype)!;

            if (CurrentViewModel != null)
            {
                history.Push(CurrentViewModel);
                CurrentViewModel!.OnNavigationTo(parameters);
            }

            forwardHistory.Clear();
        }

        public bool CanNavigateBack() => history.Count > 1;

        public bool CanNavigateForward() => forwardHistory.Count > 0;

        public void NavigateBack()
        {
            if (history.Count > 1)
            {
                forwardHistory.Push(CurrentViewModel);
                history.Pop();
                CurrentViewModel = history.First();
            }
        }

        public void NavigateForward()
        {
            if (forwardHistory.Count > 0)
            {
                CurrentViewModel = forwardHistory.First();
                history.Push(CurrentViewModel);
                forwardHistory.Pop();
            }
        }
    }
}
