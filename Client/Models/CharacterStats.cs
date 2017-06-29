namespace Client.Models
{
    public class CharacterStats
    {
        public int Strength { get; set; }
        public int Constitution { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        public int HpMax { get; set; }
        public int MpMax { get; set; }

        public bool IsValid => Validate();

        private bool Validate()
        {
            return ValueFallsInRange(Strength)
                && ValueFallsInRange(Constitution)
                && ValueFallsInRange(Dexterity)
                && ValueFallsInRange(Intelligence)
                && ValueFallsInRange(Wisdom)
                && ValueFallsInRange(Charisma)
                && HpMax > 0
                && MpMax > 0;
        }

        private bool ValueFallsInRange(int value)
        {
            return value > 0 && value < 16;
        }
    }
}
