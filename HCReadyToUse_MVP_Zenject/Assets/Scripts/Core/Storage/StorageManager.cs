using UnityEngine;
using System.IO;
using System.Threading.Tasks;


namespace Core.PlayerModule
{
    public class StorageManager
    {
        private SavingPlace _savingPlace;
        public StorageManager(SavingPlace place = SavingPlace.PlayerPrefs)
        {
            _savingPlace = place;
        }

        public void Save(string filePath, string data)
        {
            Save(filePath, data, _savingPlace);
        }

        public void Save(string filePath, string data, SavingPlace place)
        {
            switch (place)
            {
                case SavingPlace.File:

                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        writer.Write(data);
                        Debug.Log("Saving complete");
                    }
                    break;

                case SavingPlace.PlayerPrefs:

                    PlayerPrefs.SetString(filePath, data);
                    break;
            }
        }

        public string Load(string filePath, System.Action<string> onComplete)
        {
            return Load(filePath, _savingPlace, onComplete);
        }

        public string Load(string filePath, SavingPlace place, System.Action<string> onComplete)
        {
            switch (place)
            {
                case SavingPlace.File:
                    LoadData(filePath, onComplete);
                    return "";


                case SavingPlace.PlayerPrefs:

                    return PlayerPrefs.GetString(filePath);
            }

            return "";
        }

        private void LoadData(string filePath, System.Action<string> onComplete)
        {
            Task.FromResult(LoadDataAsync(filePath, onComplete));
        }

        private async Task LoadDataAsync(string filePath, System.Action<string> onComplete)
        {
            var result = "";
            using (StreamReader reader = new StreamReader(filePath))
            {
                Debug.Log($"[{GetType().Name}][LoadDataAsync] Open file");
                result = await reader.ReadToEndAsync();
                onComplete?.Invoke(result);
            }
        }

        public bool Exists(string filePath)
        {
            return Exists(filePath, _savingPlace);
        }

        public bool Exists(string filePath, SavingPlace place)
        {
            switch (place)
            {
                case SavingPlace.File:

                    return File.Exists(filePath);

                case SavingPlace.PlayerPrefs:

                    return PlayerPrefs.HasKey(filePath);
            }

            return false;
        }
    }

    public enum SavingPlace
    {
        File,
        PlayerPrefs
    }

}
