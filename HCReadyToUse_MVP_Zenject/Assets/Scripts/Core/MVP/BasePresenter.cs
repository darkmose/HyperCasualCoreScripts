using Core.MVP;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core.UI
{
    public interface IView
    {
        bool IsOpen { get; }
        void Show();
        void Hide();
        void Init();
    }

    public interface IViewLinkWithGameObject
    {
        GameObject Link { get; }
    }

    public interface IPresenter: IView
    {

    }

    public interface IModel { }
    public interface IModel<TData>:IModel
    {
        TData Data { get; }
    }

    public interface IView<TPresenter>: IView where TPresenter : IPresenter
    {
        TPresenter Presenter { get; }
        void InitPresenter(TPresenter presenter);
    }

    public interface IProxyView<TView> where TView : IView
    {
        TView View { get; }
        bool IsPrepared { get; }
        void Prepare();
    }

    public interface IPresenter<TView> : IPresenter where TView : IView
    {
        TView View { get; }
    }

    public interface IPresenter<TProxyView, TView> : IPresenter 
        where TProxyView : IProxyView<TView> 
        where TView : IView
    { 
        TProxyView ProxyView { get; }

    }

    public interface IPresenter<TModel, TProxyView, TView> : IPresenter 
        where TModel : IModel 
        where TProxyView : IProxyView<TView> 
        where TView : IView
    {
        TModel Model { get; }
        TProxyView ProxyView { get; }
    }

    public interface IPresenterModel<TModel, TView> : IPresenter where TModel : IModel where TView : IView
    {
        TModel Model { get; }
        TView View { get; }
    }

    public interface IScreenView : IView
    {
        ScreenType Type { get; }
    }

    public interface IWindowView : IView
    {
        WindowType Type { get; }
    }

    public enum PopupType
    {
        DetailedInfo,
        ToolTip
        
    }

    public enum PanelType
    {
        Dialog,
        Inventory,
        Kitchen,
        Workshop,
        Museum,
        Library,
        Stock,
        GameButton,
        WorldMap,
        GameMenu,
        QuizAnswer,
        Quiz,
        Tutorial

    }

    public interface IPopupView : IView
    {
        PopupType Type { get; }
    }

    public interface IPanelView : IView
    {
        PanelType Type { get; }
    }

    public abstract class BasePopupView : BaseView, IPopupView
    {
        public abstract PopupType Type { get; }
    }

    public abstract class BasePanelView : BaseView, IPanelView
    {
        public abstract PanelType Type { get; }
    }


    public abstract class BasePresenter : IPresenter
    {
        protected bool _isInited = false;

        public abstract bool IsOpen { get; }

        public abstract void Hide();

        public abstract void Init();

        public abstract void Show();

        protected virtual void PrepareViewData() { }
    }

}