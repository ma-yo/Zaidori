using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaidori.Datas
{
    public class OutputData
    {
        public List<decimal> SizeList { get; set; }
        public decimal Budomari { get; set; }
        public decimal MaterialSize { get; set; }

        public OutputData() {
            SizeList = new List<decimal>();
        }

    }
}
