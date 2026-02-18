using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using MarkMode.Content.Rarities;

namespace MarkMode.Content.Items.Weapons
{
    public class DiamondSword : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 50;
            Item.height = 50;
            Item.scale = 1.5f;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 14;
            Item.useAnimation = 14;
            Item.autoReuse = true;

            Item.UseSound = SoundID.Item1;
            Item.DamageType = DamageClass.Melee;
            Item.damage = 60;
            Item.knockBack = 8f;
            Item.crit = 10;

            Item.value = Item.buyPrice(gold: 30);
            Item.rare = ModContent.RarityType<DiamondRarity>();

        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(3))
            {
                Lighting.AddLight(new Vector2(hitbox.Width, hitbox.Height), new Vector3(66, 191, 245));
            }
        }
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.Weak, 60 * 12);
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<MinecraftDiamondItem>(2)
                .AddIngredient(ItemID.Wood, 1)
                .AddTile<Tiles.Furniture.MinecraftCraftTable>()
                .Register();
        }

    }
}