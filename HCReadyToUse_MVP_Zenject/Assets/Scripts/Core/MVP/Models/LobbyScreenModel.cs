using Core.PlayerModule;
using Core.UI;

namespace Core.MVP
{
    public class LobbyScreenModel : IModel
    {
        public IPropertyReadOnly<int> CurrentLevel { get; }

        public LobbyScreenModel(ILevelProgression levelProgression)
        {
            CurrentLevel = levelProgression.CurrentLevel;
        }
    }
}