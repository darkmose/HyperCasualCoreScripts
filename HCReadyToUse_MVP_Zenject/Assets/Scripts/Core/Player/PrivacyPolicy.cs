using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.PlayerModule
{
    public interface IPrivacyPolicy
    {
        string Name { get; }
        int Age { get; }
        string Country { get; }
        string Avater { get; }

        void SetName(string name);
        void SetAge(int age);
        void SetCountry(string country);
        void SetAvatar(string avatarName);

    }

    public class PrivacyPolicy : IPrivacyPolicy
    {
        public string Name => throw new System.NotImplementedException();

        public int Age => throw new System.NotImplementedException();

        public string Country => throw new System.NotImplementedException();

        public string Avater => throw new System.NotImplementedException();

        public void SetAge(int age)
        {
            throw new System.NotImplementedException();
        }

        public void SetAvatar(string avatarName)
        {
            throw new System.NotImplementedException();
        }

        public void SetCountry(string country)
        {
            throw new System.NotImplementedException();
        }

        public void SetName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}