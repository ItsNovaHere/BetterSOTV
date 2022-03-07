using System.Reflection;
using EntityStates.Railgunner.Weapon;
using HarmonyLib;
using RoR2;
using Console = System.Console;

namespace BetterSOTV.HarmonyPatches; 

[HarmonyPatch(typeof(BaseFireSnipe), nameof(BaseFireSnipe.OnEnter))]
public class BaseFireSnipeOnEnter {

	private static readonly MethodInfo GetCharacterBody = AccessTools.PropertyGetter(typeof(BaseFireSnipe), "characterBody");
	
	private static bool Prefix(BaseFireSnipe __instance) {
		var characterBody = GetCharacterBody.Invoke(__instance, null) as CharacterBody;
		
		if (characterBody != null) {
			if (characterBody.inventory.GetItemCount(DLC1Content.Items.ConvertCritChanceToCritDamage) == 0) {
				characterBody.inventory.GiveItem(DLC1Content.Items.ConvertCritChanceToCritDamage);
			}
		}

		return true;
	}

}