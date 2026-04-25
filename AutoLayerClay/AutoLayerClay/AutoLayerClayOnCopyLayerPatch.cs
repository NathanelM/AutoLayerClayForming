using HarmonyLib;
using Vintagestory.API.MathTools;
using Vintagestory.GameContent;

namespace AutoLayerClay
{
    [HarmonyPatch(typeof(BlockEntityClayForm), "OnCopyLayer")]
    public class AutoLayerClayOnCopyLayerPatch
    {
        public static bool Prefix(BlockEntityClayForm __instance, ref bool __result, int layer)
        {
            if (__instance?.SelectedRecipe == null)
            {
                __result = false;
                return false;
            }

            if (layer < 0 || layer >= 16)
            {
                __result = false;
                return false;
            }

            var recipe = __instance.SelectedRecipe.Voxels;

            bool changed = false;
            int maxOps = 4; // limite vanilla

            for (int x = 0; x < 16; x++)
            {
                for (int z = 0; z < 16; z++)
                {
                    bool target = recipe[x, layer, z];

                    if (__instance.Voxels[x, layer, z] != target)
                    {
                        __instance.Voxels[x, layer, z] = target;

                        __instance.AvailableVoxels += target ? -1 : 1;

                        changed = true;
                        maxOps--;

                        if (maxOps <= 0)
                        {
                            __instance.MarkDirty(true);
                            __result = true;
                            return false;
                        }
                    }
                }
            }

            __instance.MarkDirty(true);
            __result = changed;
            return false;
        }
    }
}