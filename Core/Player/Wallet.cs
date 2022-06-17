using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.PlayerModule
{
    public enum MoneyType
    {
        Coins,
        Gemstone
    }

    public interface IWallet
    {
        int GetMoneyCount(MoneyType type);
        void AddMoney(MoneyType type, int amount);
        bool TryToSpend(MoneyType type, int amount);
    }

    public class Wallet : IWallet
    {
        private Dictionary<MoneyType, int> _money = new Dictionary<MoneyType, int>();

        public Wallet()
        {
            _money[MoneyType.Coins] = 0;
            _money[MoneyType.Gemstone] = 0;
        }

        public Wallet(MoneyType moneyType, int amount):base()
        {
            _money[moneyType] = amount;
        }

        public void AddMoney(MoneyType type, int amount)
        {
            _money[type] += amount;
        }

        public int GetMoneyCount(MoneyType type)
        {
            return _money[type];
        }

        public bool TryToSpend(MoneyType type, int amount)
        {
            if (_money[type] > amount)
            {
                _money[type] -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}