using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP1
{
    public class GraphicCard
    {
        private string rtf_file;
        private string image;
        private int cena;
        private DateTime time;
        private string name;

        public string Rtf_file { get => rtf_file; set => rtf_file = value; }
        public string Image { get => image; set => image = value; }
        public int Cena { get => cena; set => cena = value; }
        public DateTime Time { get => time; set => time = value; }
        public string Name { get => name; set => name = value; }

        public GraphicCard(string rtf_file, string image, int cena, DateTime time, string name)
        {
            this.Rtf_file = rtf_file;
            this.Image = image;
            this.Cena = cena;
            this.Time = time;
            this.Name = name;
        }

        public GraphicCard()
        {

        }
    }
}
