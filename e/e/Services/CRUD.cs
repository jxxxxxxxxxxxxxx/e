using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace e.Services
{
    public class CRUD
    {
        FirebaseClient firebase = new FirebaseClient("https://licoratta00-default-rtdb.firebaseio.com/");
        public async Task AddLote(string lote, string sabor, string maceradoem, string apartirde)
        {

        }
        //public async Task<List<Producaogeral>> GetProdutos()
        //{

        //}
        //public async Task<Producaogeral>GetProduto(string nome)
        //{

        //}
        public async Task UpdateProduto(string nome)
        {

        }
        public async Task DeleteProduto(string nome)
        {

        }
    }
}
