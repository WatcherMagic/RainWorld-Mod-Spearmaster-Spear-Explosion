using BepInEx;
using MoreSlugcats;
using UnityEngine;
using System.Security.Permissions;
using System.Drawing;

[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]

namespace Spearmaster_Spear_Explosion
{
    [BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
    public class SpearmasterSpearExplosionMain : BaseUnityPlugin
    {
        public const string PLUGIN_GUID = "sm_spear_explosion";
        public const string PLUGIN_NAME = "Spearmaster Spear Explosion";
        public const string PLUGIN_VERSION = "0.1";

        private void OnEnable()
        {
            On.Player.GrabUpdate += TakeCustomInput;
            On.PlayerGraphics.TailSpeckles.setSpearProgress += GrowSpears;
        }

        private void TakeCustomInput(On.Player.orig_GrabUpdate orig, Player self, bool eu)
        {

            if (ModManager.MSC && self.SlugCatClass == MoreSlugcatsEnums.SlugcatStatsName.Spear)
            {

                if (tapPressedOnce(self, 2) && !self.input[1].pckp) 
                {

                    if (self.input[0].pckp)
                    {
                        if (self.graphicsModule != null)
                        {
                            PlayerGraphics.TailSpeckles tailspecks = (self.graphicsModule as PlayerGraphics).tailSpecks;
                            var room = self.room;
                            var pos = self.mainBodyChunk.pos;
                            var color = self.ShortCutColor();
                            room.AddObject(new Explosion(room, self, pos, 7, 250f, 6.2f, 2f, 280f, 0.25f, self, 0.7f, 160f, 1f));
                            room.AddObject(new Explosion.ExplosionLight(pos, 280f, 1f, 7, color));
                            room.AddObject(new Explosion.ExplosionLight(pos, 230f, 1f, 3, new UnityEngine.Color(1f, 1f, 1f)));
                            room.AddObject(new ExplosionSpikes(room, pos, 14, 30f, 9f, 7f, 170f, color));
                            room.AddObject(new ShockWave(pos, 330f, 0.045f, 5, false));

                            room.ScreenMovement(pos, default, 1.3f);

                        }

                    }

                }
            }

            orig(self, eu);
        }

        private bool tapPressedOnce(Player self, int n)
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

        private void GrowSpears(On.PlayerGraphics.TailSpeckles.orig_setSpearProgress orig, PlayerGraphics.TailSpeckles self, float p)
        {
            
        }

    }
}
