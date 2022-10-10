using System;

public enum SkillType
{
    RangedCombat,
    BruteForce,
    Explosives,
    Survival,
    Paramedicine,
    Mechanics,
    Computers,
    Leadership
}

public static class SkillTypeExtension
{
    public static string Name(this SkillType skillType)
    {
        string result = "UNKNOWN";
        switch (skillType)
        {
            case SkillType.RangedCombat:
                result = "Ranged Combat";
                break;
            case SkillType.BruteForce:
                result = "Brute Force";
                break;
            case SkillType.Explosives:
                result = "Explosives";
                break;
            case SkillType.Survival:
                result = "Survival";
                break;
            case SkillType.Paramedicine:
                result = "Paramedicine";
                break;
            case SkillType.Mechanics:
                result = "Mechanics";
                break;
            case SkillType.Computers:
                result = "Computers";
                break;
            case SkillType.Leadership:
                result = "Leadership";
                break;
        }
        return result;
    }
}