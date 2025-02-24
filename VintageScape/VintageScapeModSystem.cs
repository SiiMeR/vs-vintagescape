using HarmonyLib;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.GameContent;

namespace VintageScape;

public class VintageScapeModSystem : ModSystem
{

    public override void StartClientSide(ICoreClientAPI api)
    {
        var harmony = new Harmony(Mod.Info.ModID);

        var original =
            AccessTools.Method(typeof(GuiDialogBlockEntityRecipeSelector), "OnSlotClick");
        var patch = AccessTools.Method(typeof(SmithingRecipeSelectorPatches), nameof(SmithingRecipeSelectorPatches.OnSlotClickPatch));

        harmony.Patch(original, prefix: new HarmonyMethod(patch));
    }
}