using HarmonyLib;
using PeterHan.PLib.Options;


namespace ToggleableNotifications
{
    [HarmonyPatch(typeof(Notifier))]
    [HarmonyPatch("Add")]
    public static class NotifierPatch
    {
        // grab the live settings from PLib
        private static readonly NotificationConfig config =
          POptions.ReadSettings<NotificationConfig>();

        public static bool Prefix(Notification notification, string suffix)
        {
            var title = notification.titleText?.ToLowerInvariant() ?? "";
            if (config.suppressCycleReportReady && title.Contains("report ready"))
                return false;
            if (config.suppressAttributeIncrease && title.Contains("attribute increase"))
                return false;
            if (config.suppressDuplicantIdled && title.Contains("idled"))
                return false;
            if (config.suppressLongCommute && title.Contains("commute"))
                return false;
            if (config.suppressBuildingResources && title.Contains("building lacks"))
                return false;
            if (config.suppressNewPrintables && title.Contains("new printables"))
                return false;
            if (config.suppressNoDocksAvailable && title.Contains("no docks available"))
                return false;
            if (config.suppressCritterStarvation && title.Contains("critter starvation"))
                return false;
            if (config.suppressFlooding && title.Contains("flooding"))
                return false;
            if (config.suppressBuildingBroken && title.Contains("building broken"))
                return false;
            if (config.suppressOverheated && title.Contains("overheated"))
                return false;
            //if (config.suppress && title.Contains("new"))
            //    return false;
            return true;
        }
    }
}