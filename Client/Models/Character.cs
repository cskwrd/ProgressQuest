namespace Client.Models
{
    public class Character
    {
        private CharacterSummary _summary = new CharacterSummary();
        private ICharacterAccessor _characterAccessor;

        public Character(ICharacterAccessor characterAccessor)
        {
            _characterAccessor = characterAccessor;
        }

        public string Name
        {
            get => _summary.Name;
            set
            {
                _summary.Name = value;
            }
        }

        public Races Race
        {
            get => _summary.Race;
            set
            {
                _summary.Race = value;
            }
        }

        public Classes Class
        {
            get => _summary.Class;
            set
            {
                _summary.Class = value;
            }
        }

        public int Level
        {
            get => _summary.Level;
            set
            {
                _summary.Level = value;
            }
        }

        public CharacterStats Stats { get; set; }

        public bool IsValid => Validate();

        public Character()
        {
            Stats = new CharacterStats();
        }

        private bool Validate()
        {
            return _summary.IsValid && Stats.IsValid;
        }

        internal void Save()
        {
            _characterAccessor.Save(this);
        }
    }
}
