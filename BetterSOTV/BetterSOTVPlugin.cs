using BepInEx;
using HarmonyLib;

namespace BetterSOTV;

[BepInPlugin("moe.itsnova.bettersotv", PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
public class BetterSOTVPlugin : BaseUnityPlugin {

	public void Awake() {
		var harmony = new Harmony(PluginInfo.PLUGIN_GUID);
		harmony.PatchAll();
		
		Logger.LogInfo("Hello world!");
	}

}