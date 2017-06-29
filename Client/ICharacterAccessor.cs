using System.Collections.Generic;
using Client.Models;

namespace Client
{
    public interface ICharacterAccessor
    {
        void Save(Character character);
        List<CharacterSummary> GetSavedCharacterSummaries();
    }
}