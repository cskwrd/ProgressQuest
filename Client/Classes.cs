using Client.Converters;
using System.ComponentModel;

namespace Client
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum Classes
    {
        [Description("Ur-Paladin")]
        UrPaladin = 1, //Ur-Paladin
        [Description("Voodoo Princess")]
        VoodooPrincess = 2,
        [Description("Robot Monk")]
        RobotMonk = 3,
        [Description("Mu-Fu Monk")]
        MuFuMonk = 4, //Mu-Fu Monk
        [Description("Mage Illusioner")]
        MageIllusioner = 5,
        [Description("Shiv-Knight")]
        ShivKnight = 6, // Shiv-Knight
        [Description("Inner Mason")]
        InnerMason = 7,
        [Description("Fighter/Organist")]
        FighterOrganist = 8, //Fighter/Organist
        [Description("Puma Burgular")]
        PumaBurgular = 9,
        [Description("Runeloremaster")]
        Runeloremaster = 10,
        [Description("Hunter Strangler")]
        HunterStrangler = 11,
        [Description("Battle-Felon")]
        BattleFelon = 12, //Battle-Felon
        [Description("Tickle-Mimic")]
        TickleMimic = 13, //Tickle-Mimic
        [Description("Slow Poisoner")]
        SlowPoisoner = 14,
        [Description("Bastard Lunatic")]
        BastardLunatic = 15,
        [Description("Lowling")]
        Lowling = 16,
        [Description("Birdrider")]
        Birdrider = 17,
        [Description("Vermineer")]
        Vermineer = 18
    }
}
