using Client.Converters;
using System.ComponentModel;

namespace Client
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum Races
    {
        [Description("Half Orc")]
        HalfOrc = 1,
        [Description("Half Man")]
        HalfMan = 2,
        [Description("Half Halfing")]
        HalfHalfing = 3,
        [Description("DoubleHobbit")]
        DoubleHobbit = 4,
        [Description("Hob-Hobbit")]
        HobHobbit = 5,
        [Description("Low Elf")]
        LowElf = 6,
        [Description("Dung Elf")]
        DungElf = 7,
        [Description("Talking Pony")]
        TalkingPony = 8,
        [Description("Gyrognome")]
        Gyrognome = 9,
        [Description("Lesser Dwarf")]
        LesserDwarf = 10,
        [Description("Crested Dwarf")]
        CrestedDwarf = 11,
        [Description("Eel Man")]
        EelMan = 12,
        [Description("Panda Man")]
        PandaMan = 13,
        [Description("Trans-Kobold")]
        TransKobold = 14,
        [Description("Enchanted Motorcycle")]
        EnchantedMotorcycle = 15,
        [Description("Will o' the Wisp")]
        WillOTheWisp = 16,
        [Description("Battle-Finch")]
        BattleFinch = 17,
        [Description("Double Wookie")]
        DoubleWookie = 18,
        [Description("Skraeling")]
        Skraeling = 19,
        [Description("Demicanadian")]
        Demicanadian = 20,
        [Description("Land Squid")]
        LandSquid = 21
    }
}
