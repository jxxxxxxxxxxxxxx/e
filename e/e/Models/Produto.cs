using System;
using System.Collections.Generic;
using System.Text;

namespace e.Models
{
    public class Produto
    {
        public string Lote { get; set; }
        public string Sabor { get; set; }
        public string Calda { get; set; }
        public string Dosagem { get; set; }
        public string DMaceracao { get; set; }
        public double ValdVenda { get; set; }
        public double Custo { get; set; }
        public double Quantidade { get; set; }
        public double Lucro { get; set; }
    }
}
