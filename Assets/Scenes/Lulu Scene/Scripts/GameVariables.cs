using UnityEngine;

public class GameVariables
{
    static public uint money = 10000;
    static public uint gov_opinion = 60;
    static public uint public_opinion = 30;
    static public uint shareholders_opinion = 65;
    static public uint death_count = 0;

    public enum Variables
    {
        MONEY,
        GOV_OPINION,
        PUBLIC_OPINION,
        SHAREHOLDERS_OPINION,
        DEATH_COUNT
    }

    static public uint getVariableFromEnum(Variables var)
    {
        switch (var)
        {
            case Variables.MONEY:
                return GameVariables.money;
            case Variables.GOV_OPINION:
                return GameVariables.gov_opinion;
            case Variables.PUBLIC_OPINION:
                return GameVariables.public_opinion;
            case Variables.SHAREHOLDERS_OPINION:
                return GameVariables.shareholders_opinion;
            case Variables.DEATH_COUNT:
                return GameVariables.death_count;
        }
        throw new System.Exception("Unknown variable");
    }

    static public void SetOpinion(ref uint opinion, uint value)
    {
        opinion = (uint)Mathf.Clamp(value, 0, 100);
    }
}
