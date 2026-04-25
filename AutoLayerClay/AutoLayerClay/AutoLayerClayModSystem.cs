using HarmonyLib;
using Vintagestory.API.Client;
using Vintagestory.API.Server;
using Vintagestory.API.Config;
using Vintagestory.API.Common;

namespace AutoLayerClay;

public class AutoLayerClayModSystem : ModSystem
{
    private Harmony harmony;
    
    // Called on server and client
    // Useful for registering block/entity classes on both sides
    public override void Start(ICoreAPI api)
    {
        Mod.Logger.Notification("AutoLayerClay loading...");

        harmony = new Harmony("autolayerclay.patch");
        harmony.PatchAll(); // <<< TRÈS IMPORTANT
    }

    public override void Dispose()
    {
        harmony?.UnpatchAll("autolayerclay.patch");
    }

    public override void StartServerSide(ICoreServerAPI api)
    {
        Mod.Logger.Notification("Hello from template mod server side: " + Lang.Get("autolayerclay:hello"));
    }

    public override void StartClientSide(ICoreClientAPI api)
    {
        Mod.Logger.Notification("Hello from template mod client side: " + Lang.Get("autolayerclay:hello"));
    }
}