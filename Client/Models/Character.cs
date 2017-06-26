namespace Client.Models
{
    public class Character
    {
        public string Name { get; set; }
        public CharacterStats Stats { get; set; }

        public Races Race { get; set; }

        public Classes Class { get; set; }

        public Character()
        {
            Stats = new CharacterStats();
        }
    }
}
