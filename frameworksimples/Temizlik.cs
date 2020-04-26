using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frameworksimples
{
    public class Temizlik
    {
        public int Id { get; set; }
        public string Urunisim { get; set; }
        public double Urunfiyat { get; set; }
        public int Stokadet { get; set; }
        public bool Satistami { get; set; }
        public string Kategori { get; set; }
        public string Altkategori { get; set; }
    }
}
