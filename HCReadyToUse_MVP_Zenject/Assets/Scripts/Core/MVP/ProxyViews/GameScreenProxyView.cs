using Core.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.MVP
{


    public class GameScreenProxyView : BaseProxyView<GameScreenView>
    {
        public GameScreenProxyView(UIManager uIManager) : base(uIManager)
        {
        }

        public override void Prepare()
        {
            View = _uIManager.GetView<GameScreenView>();
        }
    }
}