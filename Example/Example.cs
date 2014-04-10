using System;
using System.Collections.Generic;
using System.Text;
using System.IO; 

using TLibCS.Protocol;
using TLibCS.Creation;

namespace Example
{
    class Example
    {
        static void TestCompact()
        {
            MemoryStream memsout = new MemoryStream();
            TCompactWriter compact_writer = new TCompactWriter(memsout);

            item_table item0 = new item_table();
            item_table item1 = new item_table();

            item0.ID = 1;
            item0.ItemName = "强化水晶";
            item0.ReplaceItem = 64389;
            item0.Medals = 1;
            item0.Value = 1;
            item0.ReserveMoneyFlag = 0;
            item0.Quality = 1;
            item0.ItemType = item_type.crystal;
            item0.UseSingTime = 0;
            item0.CanMoved = 1;
            item0.CanDeleted = 1;
            item0.CanTrade = 1;
            item0.CanSold = 1;
            item0.CanStored = 1;
            item0.CanLocked = 1;
            item0.IsExclusive = 0;
            item0.CanDrop = 1;
            item0.DecomposePackID = 0;
            item0.vec = new string[1];
            item0.vec[0] = "haha";



            item0.Write(compact_writer);
            byte[] bout = memsout.GetBuffer();
            MemoryStream memsin = new MemoryStream(bout);


            TCompactReader compact_reader = new TCompactReader(memsin);


            item1.Read(compact_reader);
        }
        
        static void Main(string[] args)
        {
            TestCompact();
        }
    }
}
