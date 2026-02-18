using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ObjectData;
using Terraria.Localization;

namespace MarkMode.Content.Tiles.Furniture
{
    public class MinecraftCraftTable : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileTable[Type] = true; //considerated as table
            Main.tileSolidTop[Type] = true; //can go down through that tile
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true; //will be destroyed by lava
            Main.tileFrameImportant[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true; //help to not miss-click right click
            TileID.Sets.IgnoredByNpcStepUp[Type] = true; //cannot ignore town NPC collision

            DustType = DustID.WoodFurniture;
            AdjTiles = [TileID.WorkBenches];

            //Placement
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
            TileObjectData.newTile.CoordinateHeights = [18];
            TileObjectData.addTile(Type);

            //Add to important arrays that Tile
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);

            AddMapEntry(new Color(161, 76, 31), Language.GetText("Crafting Table"));

        }
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
    }
}