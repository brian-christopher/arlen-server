using Arlen.Network;

namespace Arlen.Game.Entities;

public enum PlayerClass
{
    Mage,            //Mago
    Cleric,          //Clérigo
    Warrior,         //Guerrero
    Assassin,        //Asesino
    Thief,           //Ladrón
    Bard,            //Bardo
    Druid,           //Druida
    Paladin,         //Paladín
    Hunter,          //Cazador
    Pirate,           //Pirata
}

public enum PlayerGender
{
    Male,
    Female
}

public enum PlayerRace
{
    Human,
    Elf,
    Drow,
    Gnome,
    Dwarf
}

public enum EquipmentSlot
{
    Weapon,
    Armor,
    Shield,
    Helmet
}

public enum PlayerStatType
{
    Strength,
    Agility,
    Intellect,
    Charisma,
    Vitality,
    Level,
    Experience,
    ExperienceForNextLevel,
    MinHP,
    MaxHP,
    CurrentHP,
    MinMP,
    MaxMP,
    CurrentMP,
    MinHIT,
    MaxHIT,
    Gold
}

public class Player : AliveEntity
{
    public GameSession Session { get; init; }
    public PlayerClass Class { get; set; }
    public PlayerRace Race { get; set; }
    public PlayerGender Gender { get; set; }
    public Dictionary<PlayerStatType, int> Stats { get; private set; } = new();

    public Player(GameSession session, World world) : base(world)
    {
        Session = session;

        InitializeStats();
    }

    public int GetStat(PlayerStatType playerStatType)
    {
        return Stats.GetValueOrDefault(playerStatType, 0);
    }

    public void SetStat(PlayerStatType playerStatType, int value)
    {
        Stats[playerStatType] = value;
    }

    private void InitializeStats()
    {
        foreach (PlayerStatType statType in System.Enum.GetValues(typeof(PlayerStatType)))
        {
            Stats[statType] = 0;
        }
    }

    #region Network
    #endregion
}
