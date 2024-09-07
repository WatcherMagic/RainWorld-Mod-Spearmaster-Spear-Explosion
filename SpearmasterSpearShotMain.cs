using BepInEx;
using MoreSlugcats;
using UnityEngine;
using System.Security.Permissions;
using System.Drawing;

[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]

namespace Spearmaster_Spear_Shot
{
    [BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
    public class SpearmasterSpearShotMain : BaseUnityPlugin
    {
        public const string PLUGIN_GUID = "sm_spear_shot";
        public const string PLUGIN_NAME = "Spearmaster Spear Shot";
        public const string PLUGIN_VERSION = "0.1";

        private KeyCode abilityKey = KeyCode.RightControl;
        private float lastTapTime = 0.6f;
        private const float DOUBLETAP_THRESHOLD = 0.5f;

        private void OnEnable()
        {
            On.Player.Update += TakeCustomInput;
        }

        private void TakeCustomInput(On.Player.orig_Update orig, Player self, bool eu)
        {
            orig(self, eu);

            if (ModManager.MSC && self.SlugCatClass == MoreSlugcatsEnums.SlugcatStatsName.Spear) {

                if (Input.GetKeyDown(abilityKey))
                {
                    if (Time.captureDeltaTime - lastTapTime < DOUBLETAP_THRESHOLD)
                    {
                        
                        if (Input.GetKey(abilityKey))
                        {
                            PlayerGraphics.TailSpeckles tailspecks = (self.graphicsModule as PlayerGraphics).tailSpecks;
                            GrowSpears(tailspecks);
                        }
                    }

                    lastTapTime = Time.captureDeltaTime;
                }

            }
        }

        private bool tapPressed(Player self, int n)
        {
            if (n < 9)
            {
                for (int i = n; i < 10; i++)
                {
                    if (self.input[i].pckp)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void GrowSpears(PlayerGraphics.TailSpeckles speckles)
        {
            
        }

        private void SpawnSpears()
        {

        }

        private void fireSpears()
        {

        }

    }
}
