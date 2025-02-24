using XLib.XLeveling;

namespace VintageScape;

public class SmithingRecipeSelectorPatches
{
    public static bool OnSlotClickPatch(int num)
    {
        var xskills = XSkills.XSkills.Instance.XLeveling;
        if (xskills == null)
        {
            return true;
        }

        var player = xskills.Api.World.AllPlayers[0];
        
        var skillid = xskills.GetSkill("metalworking").Id;
        var playerSkill = xskills.IXLevelingAPI?.GetPlayerSkillSet(player).PlayerSkills[skillid];
        if (playerSkill == null)
        {
            return true;
        }

        if (playerSkill.Level < 5)
        {
            return false;
        }

        return true;
    }
}