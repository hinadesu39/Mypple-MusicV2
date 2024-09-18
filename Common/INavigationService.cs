
namespace Common
{
    public interface INavigationService
    {
        BaseViewModel CurrentViewModel { get; set; }

        event Action CurrentViewModelChanged;

        bool CanNavigateBack();
        bool CanNavigateForward();
        void NavigateBack();
        void NavigateForward();
        void NavigationTo<T>(Dictionary<string, object>? parameters = null) where T : BaseViewModel;
        void NavigationTo(Type viewModelType, Dictionary<string, object>? parameters = null);
    }
}