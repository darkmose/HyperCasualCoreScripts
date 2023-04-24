using Core.UI;

namespace Core.MVP
{
    public abstract class BaseProxyView<TView> : IProxyView<TView> where TView : IView
    {
        protected readonly IUIManager _uIManager;

        public BaseProxyView(IUIManager uIManager)
        {
            _uIManager = uIManager;
        }

        public TView View { get; protected set; }

        public bool IsPrepared => !System.Object.ReferenceEquals(View, null);

        public abstract void Prepare();
    }
}