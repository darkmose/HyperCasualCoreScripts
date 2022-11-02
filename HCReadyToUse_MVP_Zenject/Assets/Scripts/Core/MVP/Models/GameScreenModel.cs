using Core.PlayerModule;
using Core.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.MVP
{
    public class GameScreenModel : IModel
    {
        public IPropertyReadOnly<int> CurrentMoney { get; }
        public IPropertyReadOnly<int> CurrentLevel { get; }

        public GameScreenModel(IWallet wallet, ILevelProgression levelProgression)
        {
            CurrentMoney = wallet.GetMoneyProperty(MoneyType.Dollars);
            CurrentLevel = levelProgression.CurrentLevel;
        }
    }
}