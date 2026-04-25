using HarmonyLib;
using Vintagestory.GameContent;

namespace AutoLayerClay
{
    [HarmonyPatch(typeof(BlockEntityClayForm), "OnCopyLayer")]
    public class AutoLayerClayVisualUpdatePatch
    {
        public static void Postfix(BlockEntityClayForm __instance, int layer)
        {
            if (__instance == null) return;

            // refresh visuel propre
            __instance.MarkDirty(true);
        }
    }
}