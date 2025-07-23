using HarmonyLib;
using KMod;
using PeterHan.PLib.Core;
using PeterHan.PLib.Options;


namespace ToggleableNotifications
{
    public class ModLoader : UserMod2
    {
        public override void OnLoad(Harmony harmony)
        {
            base.OnLoad(harmony);

            // Initialize PLib
            PUtil.InitLibrary();

            // Register your settings class with PLib.
            // PLib will generate an "Options" screen entry for you
            // under Mods → Options.
            new POptions().RegisterOptions(this, typeof(NotificationConfig));

            // Patch your harmony patches as usual
            harmony.PatchAll();
        }
    }
}
