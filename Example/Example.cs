using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; 

using TLibCS.Protocol;
using TLibCS.Creation;

namespace Example
{
    class Example
    {
        static void Main(string[] args)
        {
            MemoryStream memsout = new MemoryStream();
            TCompactWriter compact_writer = new TCompactWriter(memsout);
            
            item_table_s item0 = new item_table_s();
            item_table_s item1 = new item_table_s();

            item0.id = 1;
            item0.name = "倚天剑";
            item0.type = item_type_e.e_crystal;
            item0.limit_list = new item_limit_u[2];
            item0.limit_list[0] = new item_limit_u();
            item0.limit_list[0].level = 123;
            item0.limit_list[1] = new item_limit_u();
            item0.limit_list[1].level = 321;



            item0.Write(compact_writer);
            byte[] bout = memsout.GetBuffer();
            MemoryStream memsin = new MemoryStream(bout);


            TCompactReader compact_reader = new TCompactReader(memsin);
            

            item1.Read(compact_reader);
        }
    }
}
