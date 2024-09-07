using BepInEx;
using MoreSlugcats;
using UnityEngine;
using System.Security.Permissions;

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
            On.Player.Update += TakeCustomInput;
        }

        private void TakeCustomInput(On.Player.orig_Update orig, Player self, bool eu)
        {

            orig(self, eu);

            if (ModManager.MSC && self.SlugCatClass == MoreSlugcatsEnums.SlugcatStatsName.Spear)
            {
                if (self.input[0].pckp && self.input[0].thrw)
                {
                    var room = self.room;
                    var pos = self.mainBodyChunk.pos;
                    var color = self.ShortCutColor();
                    room.AddObject(new Explosion(room, self, pos, 7, 250f, 6.2f, 2f, 280f, 0.25f, self, 0.7f, 160f, 1f));
                    room.AddObject(new Explosion.ExplosionLight(pos, 280f, 1f, 7, color));
                    room.AddObject(new Explosion.ExplosionLight(pos, 230f, 1f, 3, new Color(1f, 1f, 1f)));
                    room.AddObject(new ExplosionSpikes(room, pos, 14, 30f, 9f, 7f, 170f, color));
                    room.AddObject(new ShockWave(pos, 330f, 0.045f, 5, false));

                    room.ScreenMovement(pos, default, 1.3f);
                    room.PlaySound(SoundID.Bomb_Explode, pos);
                    room.InGameNoise(new Noise.InGameNoise(pos, 9000f, self, 1f));
                }
            }

        }

    }
}
