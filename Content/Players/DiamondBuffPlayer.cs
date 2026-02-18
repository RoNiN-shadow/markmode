using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;


namespace MarkMode.Content.Players
{
  public class DiamondBuffPlayer : ModPlayer
  {
    private int timer = 0;
    private int typeProjectile = ModContent.ProjectileType<Projectiles.MarkProjectile>();

        public override void PostUpdate()
            {
              if(Player.HasBuff<Buffs.DiamondBuff>())
              {
                timer++;
                if(timer >= 480)
                {
                  SpawnDamnProjectile(10f, 8);
                  
                  timer = 0;

                }
              }
            }
        private void SpawnDamnProjectile(float radius, int count = 10)
        {
          for(int i = 0; i < count; i++)
          {
            float angle = MathHelper.TwoPi / count * i;

            float x = (float)Math.Cos(angle);
            float y = (float)Math.Sin(angle);
            Vector2 offset = new Vector2(x, y) * radius;

            Vector2 spawnPos = Player.Center + offset;

            Vector2 velocity = (spawnPos - Player.Center).SafeNormalize(Vector2.Zero);
            Projectile.NewProjectile(
                Player.GetSource_FromThis(),
                spawnPos,
                velocity,
                typeProjectile,
                10,
                2,
                Player.whoAmI
                );
          }
        }
  }
}
