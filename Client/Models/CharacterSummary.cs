using System;

namespace Client.Models
{
    public class CharacterSummary
    {
        public string Name { get; set; }

        public Races Race { get; set; }

        public Classes Class { get; set; }

        public int Level { get; set; }

        public bool IsValid => Validate();

        public CharacterSummary()
        {
        }

        private bool Validate()
        {
            Races tempRace;
            Classes tempClass;
            return !string.IsNullOrWhiteSpace(Name) && Enum.TryParse(Race.ToString(), out tempRace) && Enum.TryParse(Class.ToString(), out tempClass);
        }

        internal void Save()
        {
            throw new NotImplementedException();
        }
    }
}
