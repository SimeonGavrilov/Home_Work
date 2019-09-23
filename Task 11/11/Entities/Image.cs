using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    class Image
    {
        public int ID { get; set; }
        public string FileName { get; set; }
        public string Title { get; set; }
        public byte[] Data { get; set; }
        public Image(int id, string fileName, string title, byte[] data)
        {
            
        }
    }
}
