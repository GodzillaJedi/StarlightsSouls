using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ModLoader;
using ssm.Content.NPCs;

namespace ssm.Content.Projectiles.Shtuxibus
{
    public class MutantReticle : ModProjectile
    {
        public override void SetStaticDefaults()
        {
        }

        public override void SetDefaults()
        {
            Projectile.width = 110;
            Projectile.height = 110;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.aiStyle = -1;
            Projectile.penetrate = -1;
            Projectile.hostile = true;
            Projectile.alpha = 255;
            Projectile.timeLeft = 120;
        }

        public override bool? CanDamage()
        {
            return false;
        }

        public override void AI()
        {
            if (ShtunUtils.BossIsAlive(ref ShtunNpcs.Shtuxibus, ModContent.NPCType<NPCs.Shtuxibus.Shtuxibus>())
                && !Main.npc[ShtunNpcs.Shtuxibus].dontTakeDamage)
            {
                if (Projectile.localAI[0] == 0)
                {
                    Projectile.localAI[0] = Main.rand.NextBool() ? -1 : 1;
                    Projectile.rotation = Main.rand.NextFloat((float)System.Math.PI * 2);
                }

                int modifier = Math.Min(60, 90 - Projectile.timeLeft);

                Projectile.scale = 1.5f - 0.5f / 60f * modifier;

                Projectile.velocity = Vector2.Zero;
                Projectile.rotation += MathHelper.ToRadians(6) * Projectile.localAI[0];
            }
            else
            {
                Projectile.Kill();
            }

            if (Projectile.timeLeft < 15)
                Projectile.alpha += 17;

            else
            {
                Projectile.alpha -= 4;
                if (Projectile.alpha < 0)
                    Projectile.alpha = 0;
            }
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB, 128) * (1f - Projectile.alpha / 255f);
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture2D13 = Terraria.GameContent.TextureAssets.Projectile[Projectile.type].Value;
            int num156 = Terraria.GameContent.TextureAssets.Projectile[Projectile.type].Value.Height / Main.projFrames[Projectile.type]; //ypos of lower right corner of sprite to draw
            int y3 = num156 * Projectile.frame; //ypos of upper left corner of sprite to draw
            Rectangle rectangle = new Rectangle(0, y3, texture2D13.Width, num156);
            Vector2 origin2 = rectangle.Size() / 2f;
            Main.EntitySpriteDraw(texture2D13, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), Projectile.GetAlpha(lightColor), Projectile.rotation, origin2, Projectile.scale, SpriteEffects.None, 0);
            return false;
        }
    }
}