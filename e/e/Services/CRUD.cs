using e.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace e.Services
{
    public class CRUD
    {
        FirebaseClient firebase = new FirebaseClient("https://licoratta00-default-rtdb.firebaseio.com/");
        public async Task<bool> AddLoteFrutal(string lote,string sabor, string calda, string dosagem, string maceradoem, string DP, double valdvenda, double custo, double quantidade, double lucro )
        {
            if (await IsLotePExists(lote) == false && await IsLoteExists(lote, sabor)==false)
            {
                await firebase.Child("Produção").PostAsync(new Produto() { Lote = lote, Sabor = sabor, Calda = calda, Dosagem = dosagem, DMaceracao = maceradoem, DP=DP, ValdVenda = valdvenda, Custo = custo, Quantidade = quantidade, Lucro = lucro });
                await firebase.Child(sabor).PostAsync(new Produto() { Lote = lote, Sabor = sabor, Calda = calda, Dosagem = dosagem, DMaceracao = maceradoem, DP = DP, ValdVenda = valdvenda, Custo = custo, Quantidade = quantidade, Lucro = lucro });
                return true;
            }
            else
                return false;
        }
        public async Task<bool> AddLoteCremoso(string lote, string sabor, string calda, string dosagem, double valdvenda, double custo, double quantidade, double lucro)
        {
            if (await IsLoteEExists(lote) == false && await IsLoteExists(lote, sabor) == false)
            {
                await firebase.Child("Estoque").PostAsync(new Produto() { Lote = lote, Sabor = sabor, Calda = calda, Dosagem = dosagem, ValdVenda = valdvenda, Custo = custo, Quantidade = quantidade, Lucro = lucro });
                await firebase.Child(sabor).PostAsync(new Produto() { Lote = lote, Sabor = sabor, Calda = calda, Dosagem = dosagem, ValdVenda = valdvenda, Custo = custo, Quantidade = quantidade, Lucro = lucro });
                return true;
            }
            else
                return false;
        }
        public async Task<List<Produto>> GetProdutosporsaborP(string sabor)
        {
            return (await firebase.Child("Produção").Child(sabor).OnceAsync<Produto>()).Select(item => new Produto
            {
                Lote = item.Object.Lote,
                Sabor =item.Object.Sabor,
                Calda = item.Object.Calda,
                Dosagem = item.Object.Dosagem,
                DMaceracao = item.Object.DMaceracao,
                DP = item.Object.DP,
                ValdVenda = item.Object.ValdVenda,
                Custo = item.Object.Custo,
                Quantidade = item.Object.Quantidade,
                Lucro=item.Object.Lucro,
            }).ToList();
        }
        public async Task<List<Produto>> GetProdutosporsaborE(string sabor)
        {
            return (await firebase.Child("Estoque").Child(sabor).OnceAsync<Produto>()).Select(item => new Produto
            {
                Lote = item.Object.Lote,
                Sabor = item.Object.Sabor,
                Calda = item.Object.Calda,
                Dosagem = item.Object.Dosagem,
                ValdVenda = item.Object.ValdVenda,
                Custo = item.Object.Custo,
                Quantidade = item.Object.Quantidade,
                Lucro = item.Object.Lucro,
            }).ToList();
        }
        public async Task<List<Produto>> GetProdutosP()
        {
            return (await firebase.Child("Produção").OnceAsync<Produto>()).Select(item => new Produto
            {
                Lote = item.Object.Lote,
                Sabor = item.Object.Sabor,
                Calda = item.Object.Calda,
                Dosagem = item.Object.Dosagem,
                DMaceracao = item.Object.DMaceracao,
                DP = item.Object.DP,
                ValdVenda = item.Object.ValdVenda,
                Custo = item.Object.Custo,
                Quantidade = item.Object.Quantidade,
                Lucro = item.Object.Lucro,
            }).ToList();
        }
        public async Task<List<Produto>> GetProdutosE()
        {
            return (await firebase.Child("Estoque").OnceAsync<Produto>()).Select(item => new Produto
            {
                Lote = item.Object.Lote,
                Sabor = item.Object.Sabor,
                Calda = item.Object.Calda,
                Dosagem = item.Object.Dosagem,
                ValdVenda = item.Object.ValdVenda,
                DMaceracao=item.Object.DMaceracao,
                DP = item.Object.DP,
                Custo = item.Object.Custo,
                Quantidade = item.Object.Quantidade,
                Lucro = item.Object.Lucro,
            }).ToList();
        }
        public async Task<List<Produto>> GetProdutosaborP(string sabor)
        {
            return (await firebase.Child("Produção").OnceAsync<Produto>()).Select(item => new Produto
            {
                Lote = item.Object.Lote,
                Sabor = item.Object.Sabor,
                Calda = item.Object.Calda,
                Dosagem = item.Object.Dosagem,
                DMaceracao = item.Object.DMaceracao,
                DP = item.Object.DP,
                ValdVenda = item.Object.ValdVenda,
                Custo = item.Object.Custo,
                Quantidade = item.Object.Quantidade,
                Lucro = item.Object.Lucro,
            }).Where(a => a.Sabor == sabor).ToList();
        }
        public async Task<List<Produto>> GetProdutosaborE(string sabor)
        {
            return (await firebase.Child("Estoque").OnceAsync<Produto>()).Select(item => new Produto
            {
                Lote = item.Object.Lote,
                Sabor = item.Object.Sabor,
                Calda = item.Object.Calda,
                Dosagem = item.Object.Dosagem,
                ValdVenda = item.Object.ValdVenda,
                Custo = item.Object.Custo,
                Quantidade = item.Object.Quantidade,
                Lucro = item.Object.Lucro,
            }).Where(a => a.Sabor == sabor).ToList();
        }
        public async Task<List<Produto>> GetProdutodosagemP(string dosagem)
        {
            return (await firebase.Child("Produção").OnceAsync<Produto>()).Select(item => new Produto
            {
                Lote = item.Object.Lote,
                Sabor = item.Object.Sabor,
                Calda = item.Object.Calda,
                Dosagem = item.Object.Dosagem,
                DMaceracao = item.Object.DMaceracao,
                DP = item.Object.DP,
                ValdVenda = item.Object.ValdVenda,
                Custo = item.Object.Custo,
                Quantidade = item.Object.Quantidade,
                Lucro = item.Object.Lucro,
            }).Where(a => a.Dosagem == dosagem).ToList();
        }
        public async Task<List<Produto>> GetProdutodosagemE(string dosagem)
        {
            return (await firebase.Child("Estoque").OnceAsync<Produto>()).Select(item => new Produto
            {
                Lote = item.Object.Lote,
                Sabor = item.Object.Sabor,
                Calda = item.Object.Calda,
                Dosagem = item.Object.Dosagem,
                ValdVenda = item.Object.ValdVenda,
                Custo = item.Object.Custo,
                Quantidade = item.Object.Quantidade,
                Lucro = item.Object.Lucro,
            }).Where(a => a.Dosagem == dosagem).ToList();
        }
        public async Task<List<Produto>> GetProdutocaldaP(string calda)
        {
            return (await firebase.Child("Produção").OnceAsync<Produto>()).Select(item => new Produto
            {
                Lote = item.Object.Lote,
                Sabor = item.Object.Sabor,
                Calda = item.Object.Calda,
                Dosagem = item.Object.Dosagem,
                DMaceracao = item.Object.DMaceracao,
                DP = item.Object.DP,
                ValdVenda = item.Object.ValdVenda,
                Custo = item.Object.Custo,
                Quantidade = item.Object.Quantidade,
                Lucro = item.Object.Lucro,
            }).Where(a => a.Calda == calda).ToList();
        }
        public async Task<List<Produto>> GetProdutocaldaE(string calda)
        {
            return (await firebase.Child("Estoque").OnceAsync<Produto>()).Select(item => new Produto
            {
                Lote = item.Object.Lote,
                Sabor = item.Object.Sabor,
                Calda = item.Object.Calda,
                Dosagem = item.Object.Dosagem,
                ValdVenda = item.Object.ValdVenda,
                Custo = item.Object.Custo,
                Quantidade = item.Object.Quantidade,
                Lucro = item.Object.Lucro,
            }).Where(a => a.Calda == calda).ToList();
        }
        public async Task<Produto> GetProdutooP(string lote)
        {
            try
            {
                var produto = (await firebase.Child("Produção").OnceAsync<Produto>()).Where(a => a.Object.Lote == lote).FirstOrDefault();
                return await firebase.Child("Produção").Child(produto.Key).OnceSingleAsync<Produto>();
            }

            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Produto> GetProdutooE(string lote)
        {
            try
            {
                var produto = (await firebase.Child("Estoque").OnceAsync<Produto>()).Where(a => a.Object.Lote == lote).FirstOrDefault();
                return await firebase.Child("Estoque").Child(produto.Key).OnceSingleAsync<Produto>();
            }

            catch (Exception)
            {
                throw;
            }
        }
        public async Task UpdateProdutoP(string lote, string sabor, string calda, string dosagem, string maceradoem, string DP, double valdvenda, double custo, double quantidade, double lucro)
        {
            try
            {
                var updtproduto = (await firebase.Child("Produção").OnceAsync<Produto>()).Where(a => a.Object.Lote == lote).FirstOrDefault();
                await firebase.Child("Produção").Child(updtproduto.Key).PutAsync(new Produto() { Lote = lote, Sabor = sabor, Calda = calda, Dosagem = dosagem, DMaceracao = maceradoem, DP = DP, ValdVenda = valdvenda, Custo = custo, Quantidade = quantidade, Lucro = lucro});
                var updtprodutops = (await firebase.Child(sabor).OnceAsync<Produto>()).Where(a => a.Object.Lote == lote).FirstOrDefault();
                await firebase.Child(sabor).Child(updtprodutops.Key).PutAsync(new Produto() { Lote = lote, Sabor = sabor, Calda = calda, Dosagem = dosagem, DMaceracao = maceradoem, DP = DP, ValdVenda = valdvenda, Custo = custo, Quantidade = quantidade, Lucro = lucro });
            }

            catch (Exception ex)
            {
                DisplayAlert("Erro","Produto não encontrado","Ok");
            }
        }
        public async Task UpdateProdutoE(string lote, string sabor, string calda, string dosagem, string maceradoem, string DP, double valdvenda, double custo, double quantidade, double lucro)
        {
            try
            {
                var updtproduto = (await firebase.Child("Estoque").OnceAsync<Produto>()).Where(a => a.Object.Lote == lote).FirstOrDefault();
                await firebase.Child("Estoque").Child(updtproduto.Key).PutAsync(new Produto() { Lote = lote, Sabor = sabor, Calda = calda, Dosagem = dosagem, ValdVenda = valdvenda, Custo = custo, Quantidade = quantidade, Lucro = lucro });
                var updtprodutops = (await firebase.Child(sabor).OnceAsync<Produto>()).Where(a => a.Object.Lote == lote).FirstOrDefault();
                await firebase.Child(sabor).Child(updtprodutops.Key).PutAsync(new Produto() { Lote = lote, Sabor = sabor, Calda = calda, Dosagem = dosagem, ValdVenda = valdvenda, Custo = custo, Quantidade = quantidade, Lucro = lucro });
            }

            catch (Exception ex)
            {
                DisplayAlert("Erro", "Produto não encontrado", "Ok");
            }
        }
        private void DisplayAlert(string v1, string v2, string v3)
        {
            throw new NotImplementedException();
        }
        public async Task DeleteProdutoP(string lote, string sabor)
        {
            try
            {
                var deletproduto = (await firebase.Child("Produção").OnceAsync<Produto>()).Where(a => a.Object.Lote == lote).FirstOrDefault();
                await firebase.Child("Produção").Child(deletproduto.Key).DeleteAsync();
                var deletprodutops = (await firebase.Child(sabor).OnceAsync<Produto>()).Where(a => a.Object.Lote == lote).FirstOrDefault();
                await firebase.Child(sabor).Child(deletprodutops.Key).DeleteAsync();
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", "Produto não encontrado", "Ok");
            }
        }
        public async Task DeleteProdutoE(string lote, string sabor)
        {
            try
            {
                var deletproduto = (await firebase.Child("Estoque").OnceAsync<Produto>()).Where(a => a.Object.Lote == lote).FirstOrDefault();
                await firebase.Child("Estoque").Child(deletproduto.Key).DeleteAsync();
                var deletprodutops = (await firebase.Child(sabor).OnceAsync<Produto>()).Where(a => a.Object.Lote == lote).FirstOrDefault();
                await firebase.Child(sabor).Child(deletprodutops.Key).DeleteAsync();
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", "Produto não encontrado", "Ok");
            }
        }
        public async Task<bool> IsLotePExists(string lote)
        {
            var produto = (await firebase.Child("Produção").OnceAsync<Produto>()).Where(u => u.Object.Lote == lote).FirstOrDefault();
            return produto != null;
        }
        public async Task<bool> IsLoteEExists(string lote)
        {
            var produto = (await firebase.Child("Estoque").OnceAsync<Produto>()).Where(u => u.Object.Lote == lote).FirstOrDefault();
            return produto != null;
        }
        public async Task<bool> IsLoteExists(string lote, string sabor)
        {
            var produto = (await firebase.Child(sabor).OnceAsync<Produto>()).Where(u => u.Object.Lote == lote).FirstOrDefault();
            return produto != null;
        }
    }
}
