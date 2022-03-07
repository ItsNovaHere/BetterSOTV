using System.Reflection;
using EntityStates.Railgunner.Weapon;
using HarmonyLib;
using RoR2;
using Console = System.Console;

namespace BetterSOTV.HarmonyPatches; 

[HarmonyPatch(typeof(FirePistol), nameof(FirePistol.OnEnter))]
public class FirePistolOnEnter {

	private static readonly MethodInfo GetCharacterBody = AccessTools.PropertyGetter(typeof(FirePistol), "characterBody");
	
	private static bool Prefix(FirePistol __instance) {
		var characterBody = GetCharacterBody.Invoke(__instance, null) as CharacterBody;
		
		if (characterBody != null) {
			characterBody.inventory.ResetItem(DLC1Content.Items.ConvertCritChanceToCritDamage);
		}

		return true;
	}

}