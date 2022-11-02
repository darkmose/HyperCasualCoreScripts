using System.Collections;
using UnityEngine;

namespace Core.MVP
{
    public interface IView
    {
        void Show();
        void Hide();
        void Init();
        void Destroy();
    }

    public interface IProxyView<TView> where TView : IView
    {
        TView View { get; }
        bool IsPrepared { get; }
        void Prepare();
    }

    public interface IPresenter : IView
    {
    }

    public interface IPresenter<TModel, TProxyView, TView> : IPresenter
    where TModel : IModel
    where TProxyView : IProxyView<TView>
    where TView : IView
    {
        TModel Model { get; }
        TProxyView ProxyView { get; }
    }

    public interface IModel { }

}