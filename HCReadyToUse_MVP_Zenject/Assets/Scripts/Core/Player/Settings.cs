using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.PlayerModule
{
    public interface ISettings
    {
        bool SoundFXOn { get; }
        bool MusicOn { get; }
        bool VibroOn { get; }

        void SetSound(bool isOn);
        void SetMusic(bool isOn);
        void SetVibro(bool isOn);

    }

    public class Settings : ISettings
    {
        public bool SoundFXOn { get; private set; }

        public bool MusicOn { get; private set; }

        public bool VibroOn { get; private set; }

        public void SetMusic(bool isOn)
        {
            MusicOn = isOn;
        }

        public void SetSound(bool isOn)
        {
            SoundFXOn = isOn;
        }

        public void SetVibro(bool isOn)
        {
            VibroOn = isOn;
        }
    }
}