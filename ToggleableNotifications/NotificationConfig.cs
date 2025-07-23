using PeterHan.PLib.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


namespace ToggleableNotifications
{
    [JsonObject(MemberSerialization.OptIn)]
    [ModInfo("Toggleable Notifications",
             "Silently suppress specific in‑game notifications.")]
    //RestartRequired] // optional, if changing these needs a game restart
    public sealed class NotificationConfig
    {
        [JsonProperty] // so PLib’s JSON reader will write/read 
        [Option("Cycle report ready", "Suppress the “Cycle Report Ready” notification.")]
        public bool suppressCycleReportReady { get; set; } = true;

        [JsonProperty]
        [Option("Attribute increase", "Suppress the “Attribute Increase” notification.")]
        public bool suppressAttributeIncrease { get; set; } = true;

        [JsonProperty]
        [Option("Duplicant idled", "Suppress the “Duplicant Idled” notification.")]
        public bool suppressDuplicantIdled { get; set; } = true;

        [JsonProperty]
        [Option("Long commutes", "Suppress the “Long Commutes” notification.")] 
        public bool suppressLongCommute { get; set; } = true;

        [JsonProperty]
        [Option("Building lacks resources", "Suppress the “Building lacks resources” notification.")] 
        public bool suppressBuildingResources { get; set; } = true;

        [JsonProperty]
        [Option("New Printables", "Suppress the “New Printables are available” notification.")] 
        public bool suppressNewPrintables { get; set; } = true;

        [JsonProperty]
        [Option("Exosuits Docks", "Suppress the “No Docks available” notification.")]
        public bool suppressNoDocksAvailable { get; set; } = true;

        [JsonProperty]
        [Option("Critter Starvation", "Suppress the “Critter Starvation” notification.")] 
        public bool suppressCritterStarvation { get; set; } = false;

        [JsonProperty]
        [Option("Flooding", "Suppress the “Flooding” notification.")] 
        public bool suppressFlooding { get; set; } = false;

        [JsonProperty]
        [Option("Building broken", "Suppress the “Building broken” notification.")]
        public bool suppressBuildingBroken { get; set; } = false;

        [JsonProperty]
        [Option("Overheated", "Suppress the “Damage: Overheated” notification.")]
        public bool suppressOverheated { get; set; } = false;
    }
}
