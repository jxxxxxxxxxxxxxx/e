using e.Models;
using e.Views;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace e.Services
{
    public class CRUD
    {
        FirebaseClient firebase = new FirebaseClient("https://licoratta00-default-rtdb.firebaseio.com/");
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
        public async Task UpdateProdutoP(string lote, string sabor, string calda, string dosagem, string maceradoem, string DP, double valdvenda, double custo, double quantidade, double lucro)
        {
            try
            {
                var updtproduto = (await firebase.Child("Produção").OnceAsync<Produto>()).Where(a => a.Object.Lote == lote).FirstOrDefault();
                await firebase.Child("Produção").Child(updtproduto.Key).PutAsync(new Produto() { Lote = lote, Sabor = sabor, Calda = calda, Dosagem = dosagem, DMaceracao = maceradoem, DP = DP, ValdVenda = valdvenda, Custo = custo, Quantidade = quantidade, Lucro = lucro });
                var updtprodutops = (await firebase.Child(sabor).OnceAsync<Produto>()).Where(a => a.Object.Lote == lote).FirstOrDefault();
                await firebase.Child(sabor).Child(updtprodutops.Key).PutAsync(new Produto() { Lote = lote, Sabor = sabor, Calda = calda, Dosagem = dosagem, DMaceracao = maceradoem, DP = DP, ValdVenda = valdvenda, Custo = custo, Quantidade = quantidade, Lucro = lucro });
            }

            catch (Exception ex)
            {
                DisplayAlert("Erro", "Produto não encontrado", "Ok");
            }
        }
        public async Task<Baba> Getbaba(double quantidade)
        {
            if ((await firebase.Child("LGBT").OnceAsync<Baba>()).Where(a => a.Object.Qtdbaba >= quantidade).FirstOrDefault() != null)
            {
                try
                {  
                    var produto = (await firebase.Child("LGBT").OnceAsync<Baba>()).Where(a => a.Object.Qtdbaba >=quantidade).FirstOrDefault();
                    return await firebase.Child("LGBT").Child(produto.Key).OnceSingleAsync<Baba>();
                }

                catch (Exception)
                {
                    throw;
                }
            }
            else if((await firebase.Child("LGBT").OnceAsync<Baba>()).Where(a => a.Object.Qtdbaba <= quantidade).FirstOrDefault() != null)
            {
                try
                {
                    var produto = (await firebase.Child("LGBT").OnceAsync<Baba>()).Where(a => a.Object.Qtdbaba <= quantidade).FirstOrDefault();
                    return await firebase.Child("LGBT").Child(produto.Key).OnceSingleAsync<Baba>();
                }

                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }
        public async Task updtbaba(double quantidade)
        {
            var p = await Getbaba(quantidade);
            if (p != null)
            {
                double qtdbd = p.Qtdbaba;
                if (qtdbd >= quantidade)
                {
                    try
                    {
                        var updtbaba = (await firebase.Child("LGBT").OnceAsync<Baba>()).Where(a => a.Object.Qtdbaba == qtdbd).FirstOrDefault();
                        double qtd = qtdbd - quantidade;
                        await firebase.Child("LGBT").Child(updtbaba.Key).PutAsync(new Baba() { Qtdbaba = qtd });
                    }
                    catch (Exception ex)
                    {
                        DisplayAlert("Erro", "Erro ao diminuir o numero de baba, o processo de criação de lote não será interrompido, mas a quantidade de baba não será reduzida", "Ok");
                    }
                }
                else
                {
                    DisplayAlert("Erro", "Valor no Banco de dados é inferior ao que deve ser retirado, o processo de criação de lote não será interrompido, mas a quantidade de baba não será reduzida", "ok");
                }
            }
            else
            {
                DisplayAlert("Erro", "Valor no Banco de dados é inferior ao que deve ser retirado, o processo de criação de lote não será interrompido, mas a quantidade de baba não será reduzida", "ok");
            }
        }
        public async Task<Rótulos> GetrotuloF1(double quantidade, string sabor)
        {
            if ((await firebase.Child("Rótulos").Child(sabor).OnceAsync<Rótulos>()).Where(a => a.Object.QtdF1 >= quantidade).FirstOrDefault() != null)
            {
                try
                {
                    var produto = (await firebase.Child("Rótulos").Child(sabor).OnceAsync<Rótulos>()).Where(a => a.Object.QtdF1 >= quantidade).FirstOrDefault();
                    return await firebase.Child("Rótulos").Child(sabor).Child(produto.Key).OnceSingleAsync<Rótulos>();
                }

                catch (Exception)
                {
                    throw;
                }
            }
            else if ((await firebase.Child("Rótulos").Child(sabor).OnceAsync<Rótulos>()).Where(a => a.Object.QtdF1 <= quantidade).FirstOrDefault() != null)
            {
                try
                {
                    var produto = (await firebase.Child("Rótulos").Child(sabor).OnceAsync<Rótulos>()).Where(a => a.Object.QtdF1 >= quantidade).FirstOrDefault();
                    return await firebase.Child("Rótulos").Child(sabor).Child(produto.Key).OnceSingleAsync<Rótulos>();
                }

                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }
        public async Task<Rótulos> GetrotuloV1(double quantidade, string sabor)
        {
            if ((await firebase.Child("Rótulos").Child(sabor).OnceAsync<Rótulos>()).Where(a => a.Object.QtdV1 >= quantidade).FirstOrDefault() != null)
            {
                try
                {
                    var produto = (await firebase.Child("Rótulos").Child(sabor).OnceAsync<Rótulos>()).Where(a => a.Object.QtdV1 >= quantidade).FirstOrDefault();
                    return await firebase.Child("Rótulos").Child(sabor).Child(produto.Key).OnceSingleAsync<Rótulos>();
                }

                catch (Exception)
                {
                    throw;
                }
            }
            else if ((await firebase.Child("Rótulos").Child(sabor).OnceAsync<Rótulos>()).Where(a => a.Object.QtdV1 <= quantidade).FirstOrDefault() != null)
            {
                try
                {
                    var produto = (await firebase.Child("Rótulos").Child(sabor).OnceAsync<Rótulos>()).Where(a => a.Object.QtdV1 >= quantidade).FirstOrDefault();
                    return await firebase.Child("Rótulos").Child(sabor).Child(produto.Key).OnceSingleAsync<Rótulos>();
                }

                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }
        public async Task updrotulo1(double quantidade, string sabor)
        {
            var p = await GetrotuloV1(quantidade, sabor);
            var p1 = await GetrotuloF1(quantidade, sabor);
            if (p != null || p1 != null)
            {
                double qtdbdF = p1.QtdF1;
                double qtdbdV = p.QtdV1;
                if (qtdbdF >= quantidade && qtdbdV >= quantidade)
                {
                    try
                    {
                        var updt = (await firebase.Child("Rótulos").Child(sabor).OnceAsync<Rótulos>()).Where(a => a.Object.QtdV1 == qtdbdV).FirstOrDefault();
                        double qtd = qtdbdV - quantidade;
                        double qtd2 = qtdbdF - quantidade;
                        await firebase.Child("Rótulos").Child(sabor).Child(updt.Key).PutAsync(new Rótulos() { QtdV1 = qtd, QtdF1 = qtd2 });
                    }
                    catch (Exception ex)
                    {
                        DisplayAlert("Erro", "Erro ao diminuir o numero de garrafas, o processo de criação de lote não será interrompido, mas a quantidade de garrafas não será reduzida", "Ok");
                    }
                }
                else
                {
                    DisplayAlert("Erro", "Valor no Banco de dados é inferior ao que deve ser retirado, o processo de criação de lote não será interrompido, mas a quantidade de garrafas não será reduzida", "ok");
                }
            }
            else
            {
                DisplayAlert("Erro", "Valor no Banco de dados é inferior ao que deve ser retirado, o processo de criação de lote não será interrompido, mas a quantidade de garrafas não será reduzida", "ok");
            }
        }
        public async Task<Rótulos> GetrotuloF50(double quantidade, string sabor)
        {
            if ((await firebase.Child("Rótulos").Child(sabor).OnceAsync<Rótulos>()).Where(a => a.Object.QtdF50 >= quantidade).FirstOrDefault() != null)
            {
                try
                {
                    var produto = (await firebase.Child("Rótulos").Child(sabor).OnceAsync<Rótulos>()).Where(a => a.Object.QtdF50 >= quantidade).FirstOrDefault();
                    return await firebase.Child("Rótulos").Child(sabor).Child(produto.Key).OnceSingleAsync<Rótulos>();
                }

                catch (Exception)
                {
                    throw;
                }
            }
            else if ((await firebase.Child("Rótulos").Child(sabor).OnceAsync<Rótulos>()).Where(a => a.Object.QtdF50 <= quantidade).FirstOrDefault() != null)
            {
                try
                {
                    var produto = (await firebase.Child("Rótulos").Child(sabor).OnceAsync<Rótulos>()).Where(a => a.Object.QtdF50 >= quantidade).FirstOrDefault();
                    return await firebase.Child("Rótulos").Child(sabor).Child(produto.Key).OnceSingleAsync<Rótulos>();
                }

                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }
        public async Task<Rótulos> GetrotuloV50(double quantidade, string sabor)
        {
            if ((await firebase.Child("Rótulos").Child(sabor).OnceAsync<Rótulos>()).Where(a => a.Object.QtdV50 >= quantidade).FirstOrDefault() != null)
            {
                try
                {
                    var produto = (await firebase.Child("Rótulos").Child(sabor).OnceAsync<Rótulos>()).Where(a => a.Object.QtdV50 >= quantidade).FirstOrDefault();
                    return await firebase.Child("Rótulos").Child(sabor).Child(produto.Key).OnceSingleAsync<Rótulos>();
                }

                catch (Exception)
                {
                    throw;
                }
            }
            else if ((await firebase.Child("Rótulos").Child(sabor).OnceAsync<Rótulos>()).Where(a => a.Object.QtdV50 <= quantidade).FirstOrDefault() != null)
            {
                try
                {
                    var produto = (await firebase.Child("Rótulos").Child(sabor).OnceAsync<Rótulos>()).Where(a => a.Object.QtdV50 >= quantidade).FirstOrDefault();
                    return await firebase.Child("Rótulos").Child(sabor).Child(produto.Key).OnceSingleAsync<Rótulos>();
                }

                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }
        public async Task updrotulo50(double quantidade, string sabor)
        {
            var p = await GetrotuloV50(quantidade, sabor);
            var p1 = await GetrotuloF50(quantidade, sabor);
            if (p != null || p1 != null)
            {
                double qtdbdF = p1.QtdF50;
                double qtdbdV = p.QtdV50;
                if (qtdbdF >= quantidade && qtdbdV >= quantidade)
                {
                    try
                    {
                        var updt = (await firebase.Child("Rótulos").Child(sabor).OnceAsync<Rótulos>()).Where(a => a.Object.QtdV50 == qtdbdV).FirstOrDefault();
                        double qtd = qtdbdV - quantidade;
                        double qtd2 = qtdbdF - quantidade;
                        await firebase.Child("Rótulos").Child(sabor).Child(updt.Key).PutAsync(new Rótulos() { QtdV50 = qtd, QtdF50 = qtd2 });
                    }
                    catch (Exception ex)
                    {
                        DisplayAlert("Erro", "Erro ao diminuir o numero de garrafas, o processo de criação de lote não será interrompido, mas a quantidade de garrafas não será reduzida", "Ok");
                    }
                }
                else
                {
                    DisplayAlert("Erro", "Valor no Banco de dados é inferior ao que deve ser retirado, o processo de criação de lote não será interrompido, mas a quantidade de garrafas não será reduzida", "ok");
                }
            }
            else
            {
                DisplayAlert("Erro", "Valor no Banco de dados é inferior ao que deve ser retirado, o processo de criação de lote não será interrompido, mas a quantidade de garrafas não será reduzida", "ok");
            }
        }
        public async Task<Rótulos> GetrotuloF250(double quantidade, string sabor)
        {
            if ((await firebase.Child("Rótulos").Child(sabor).OnceAsync<Rótulos>()).Where(a => a.Object.QtdF250 >= quantidade).FirstOrDefault() != null)
            {
                try
                {
                    var produto = (await firebase.Child("Rótulos").Child(sabor).OnceAsync<Rótulos>()).Where(a => a.Object.QtdF250 >= quantidade).FirstOrDefault();
                    return await firebase.Child("Rótulos").Child(sabor).Child(produto.Key).OnceSingleAsync<Rótulos>();
                }

                catch (Exception)
                {
                    throw;
                }
            }
            else if ((await firebase.Child("Rótulos").Child(sabor).OnceAsync<Rótulos>()).Where(a => a.Object.QtdF250 <= quantidade).FirstOrDefault() != null)
            {
                try
                {
                    var produto = (await firebase.Child("Rótulos").Child(sabor).OnceAsync<Rótulos>()).Where(a => a.Object.QtdF250 >= quantidade).FirstOrDefault();
                    return await firebase.Child("Rótulos").Child(sabor).Child(produto.Key).OnceSingleAsync<Rótulos>();
                }

                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }
        public async Task<Rótulos> GetrotuloV250(double quantidade, string sabor)
        {
            if ((await firebase.Child("Rótulos").Child(sabor).OnceAsync<Rótulos>()).Where(a => a.Object.QtdV250 >= quantidade).FirstOrDefault() != null)
            {
                try
                {
                    var produto = (await firebase.Child("Rótulos").Child(sabor).OnceAsync<Rótulos>()).Where(a => a.Object.QtdV250 >= quantidade).FirstOrDefault();
                    return await firebase.Child("Rótulos").Child(sabor).Child(produto.Key).OnceSingleAsync<Rótulos>();
                }

                catch (Exception)
                {
                    throw;
                }
            }
            else if ((await firebase.Child("Rótulos").Child(sabor).OnceAsync<Rótulos>()).Where(a => a.Object.QtdV250 <= quantidade).FirstOrDefault() != null)
            {
                try
                {
                    var produto = (await firebase.Child("Rótulos").Child(sabor).OnceAsync<Rótulos>()).Where(a => a.Object.QtdV250 <= quantidade).FirstOrDefault();
                    return await firebase.Child("Rótulos").Child(sabor).Child(produto.Key).OnceSingleAsync<Rótulos>();
                }

                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }
        public async Task updrotulo250(double quantidade, string sabor)
        {
            var p = await GetrotuloV250(quantidade, sabor);
            var p1 = await GetrotuloF250(quantidade, sabor);
            if (p != null || p1!=null)
            {
                double qtdbdF = p1.QtdF250;
                double qtdbdV = p.QtdV250;
                if (qtdbdF >= quantidade && qtdbdV>=quantidade)
                {
                    try
                    {
                        var updt = (await firebase.Child("Rótulos").Child(sabor).OnceAsync<Rótulos>()).Where(a => a.Object.QtdV250 == qtdbdV).FirstOrDefault();
                        double qtd = qtdbdV - quantidade;
                        double qtd2 = qtdbdF - quantidade;
                        await firebase.Child("Rótulos").Child(sabor).Child(updt.Key).PutAsync(new Rótulos() { QtdV250 = qtd, QtdF250=qtd2});
                    }
                    catch (Exception ex)
                    {
                        DisplayAlert("Erro", "Erro ao diminuir o numero de garrafas, o processo de criação de lote não será interrompido, mas a quantidade de garrafas não será reduzida", "Ok");
                    }
                }
                else
                {
                    DisplayAlert("Erro", "Valor no Banco de dados é inferior ao que deve ser retirado, o processo de criação de lote não será interrompido, mas a quantidade de garrafas não será reduzida", "ok");
                }
            }
            else
            {
                DisplayAlert("Erro", "Valor no Banco de dados é inferior ao que deve ser retirado, o processo de criação de lote não será interrompido, mas a quantidade de garrafas não será reduzida", "ok");
            }
        }
        public async Task<Rótulos> GetrotuloF500(double quantidade, string sabor)
        {
            if ((await firebase.Child("Rótulos").Child(sabor).OnceAsync<Rótulos>()).Where(a => a.Object.QtdF500 >= quantidade).FirstOrDefault() != null)
            {
                try
                {
                    var produto = (await firebase.Child("Rótulos").Child(sabor).OnceAsync<Rótulos>()).Where(a => a.Object.QtdF500 >= quantidade).FirstOrDefault();
                    return await firebase.Child("Rótulos").Child(sabor).Child(produto.Key).OnceSingleAsync<Rótulos>();
                }

                catch (Exception)
                {
                    throw;
                }
            }
            else if ((await firebase.Child("Rótulos").Child(sabor).OnceAsync<Rótulos>()).Where(a => a.Object.QtdF500 <= quantidade).FirstOrDefault() != null)
            {
                try
                {
                    var produto = (await firebase.Child("Rótulos").Child(sabor).OnceAsync<Rótulos>()).Where(a => a.Object.QtdF500 >= quantidade).FirstOrDefault();
                    return await firebase.Child("Rótulos").Child(sabor).Child(produto.Key).OnceSingleAsync<Rótulos>();
                }

                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }
        public async Task<Rótulos> GetrotuloV500(double quantidade, string sabor)
        {
            if ((await firebase.Child("Rótulos").Child(sabor).OnceAsync<Rótulos>()).Where(a => a.Object.QtdV500 >= quantidade).FirstOrDefault() != null)
            {
                try
                {
                    var produto = (await firebase.Child("Rótulos").Child(sabor).OnceAsync<Rótulos>()).Where(a => a.Object.QtdV500 >= quantidade).FirstOrDefault();
                    return await firebase.Child("Rótulos").Child(sabor).Child(produto.Key).OnceSingleAsync<Rótulos>();
                }

                catch (Exception)
                {
                    throw;
                }
            }
            else if ((await firebase.Child("Rótulos").Child(sabor).OnceAsync<Rótulos>()).Where(a => a.Object.QtdV500 <= quantidade).FirstOrDefault() != null)
            {
                try
                {
                    var produto = (await firebase.Child("Rótulos").Child(sabor).OnceAsync<Rótulos>()).Where(a => a.Object.QtdV500 >= quantidade).FirstOrDefault();
                    return await firebase.Child("Rótulos").Child(sabor).Child(produto.Key).OnceSingleAsync<Rótulos>();
                }

                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }
        public async Task updrotulo500(double quantidade, string sabor)
        {
            var p = await GetrotuloV500(quantidade, sabor);
            var p1 = await GetrotuloF500(quantidade, sabor);
            if (p != null || p1 != null)
            {
                double qtdbdF = p1.QtdF500;
                double qtdbdV = p.QtdV500;
                if (qtdbdF >= quantidade && qtdbdV >= quantidade)
                {
                    try
                    {
                        var updt = (await firebase.Child("Rótulos").Child(sabor).OnceAsync<Rótulos>()).Where(a => a.Object.QtdV500 == qtdbdV).FirstOrDefault();
                        double qtd = qtdbdV - quantidade;
                        double qtd2 = qtdbdF - quantidade;
                        await firebase.Child("Rótulos").Child(sabor).Child(updt.Key).PutAsync(new Rótulos() { QtdV500 = qtd, QtdF500 = qtd2 });
                    }
                    catch (Exception ex)
                    {
                        DisplayAlert("Erro", "Erro ao diminuir o numero de garrafas, o processo de criação de lote não será interrompido, mas a quantidade de garrafas não será reduzida", "Ok");
                    }
                }
                else
                {
                    DisplayAlert("Erro", "Valor no Banco de dados é inferior ao que deve ser retirado, o processo de criação de lote não será interrompido, mas a quantidade de garrafas não será reduzida", "ok");
                }
            }
            else
            {
                DisplayAlert("Erro", "Valor no Banco de dados é inferior ao que deve ser retirado, o processo de criação de lote não será interrompido, mas a quantidade de garrafas não será reduzida", "ok");
            }
        }
        public async Task<Papelaria> GetEB(double quantidade)
        {
            if ((await firebase.Child("Papelaria").OnceAsync<Papelaria>()).Where(a => a.Object.QtdEB >= quantidade).FirstOrDefault() != null)
            {
                try
                {
                    var produto = (await firebase.Child("Papelaria").OnceAsync<Papelaria>()).Where(a => a.Object.QtdEB >= quantidade).FirstOrDefault();
                    return await firebase.Child("Papelaria").Child(produto.Key).OnceSingleAsync<Papelaria>();
                }

                catch (Exception)
                {
                    throw;
                }
            }
            else if ((await firebase.Child("Papelaria").OnceAsync<Papelaria>()).Where(a => a.Object.QtdEB <= quantidade).FirstOrDefault() != null)
            {
                try
                {
                    var produto = (await firebase.Child("Papelaria").OnceAsync<Papelaria>()).Where(a => a.Object.QtdEB <= quantidade).FirstOrDefault();
                    return await firebase.Child("Papelaria").Child(produto.Key).OnceSingleAsync<Papelaria>();
                }

                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }
        public async Task updEB(double quantidade)
        {
            var p = await GetEB(quantidade);
            if (p != null)
            {
                double qtdbd = p.QtdEB;
                if (qtdbd >= quantidade)
                {
                    try
                    {
                        var updt = (await firebase.Child("Papelaria").OnceAsync<Papelaria>()).Where(a => a.Object.QtdEB == qtdbd).FirstOrDefault();
                        double qtd = qtdbd - quantidade;
                        await firebase.Child("Papelaria").Child(updt.Key).PutAsync(new Papelaria() { QtdEB = qtd });
                    }
                    catch (Exception ex)
                    {
                        DisplayAlert("Erro", "Erro ao diminuir o numero de garrafas, o processo de criação de lote não será interrompido, mas a quantidade de garrafas não será reduzida", "Ok");
                    }
                }
                else
                {
                    DisplayAlert("Erro", "Valor no Banco de dados é inferior ao que deve ser retirado, o processo de criação de lote não será interrompido, mas a quantidade de garrafas não será reduzida", "ok");
                }
            }
            else
            {
                DisplayAlert("Erro", "Valor no Banco de dados é inferior ao que deve ser retirado, o processo de criação de lote não será interrompido, mas a quantidade de garrafas não será reduzida", "ok");
            }
        }
        public async Task<Lacres> Getlacres50ml(double quantidade)
        {
            if ((await firebase.Child("LGBT").Child("Lacres").OnceAsync<Lacres>()).Where(a => a.Object.QtdL50 >= quantidade).FirstOrDefault() != null)
            {
                try
                {
                    var produto = (await firebase.Child("LGBT").Child("Lacres").OnceAsync<Lacres>()).Where(a => a.Object.QtdL50 >= quantidade).FirstOrDefault();
                    return await firebase.Child("LGBT").Child("Lacres").Child(produto.Key).OnceSingleAsync<Lacres>();
                }

                catch (Exception)
                {
                    throw;
                }
            }
            else if ((await firebase.Child("LGBT").Child("Lacres").OnceAsync<Lacres>()).Where(a => a.Object.QtdL50 <= quantidade).FirstOrDefault() != null)
            {
                try
                {
                    var produto = (await firebase.Child("LGBT").Child("Lacres").OnceAsync<Lacres>()).Where(a => a.Object.QtdL50 <= quantidade).FirstOrDefault();
                    return await firebase.Child("LGBT").Child("Lacres").Child(produto.Key).OnceSingleAsync<Lacres>();
                }

                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }
        public async Task updlacres50ml(double quantidade)
        {
            var p = await Getlacres50ml(quantidade);
            if (p != null)
            {
                double qtdbd = p.QtdL50;
                if (qtdbd >= quantidade)
                {
                    try
                    {
                        var updt = (await firebase.Child("LGBT").Child("Lacres").OnceAsync<Lacres>()).Where(a => a.Object.QtdL50 == qtdbd).FirstOrDefault();
                        double qtd = qtdbd - quantidade;
                        await firebase.Child("LGBT").Child("Lacres").Child(updt.Key).PutAsync(new Lacres() { QtdL50 = qtd });
                    }
                    catch (Exception ex)
                    {
                        DisplayAlert("Erro", "Erro ao diminuir o numero de garrafas, o processo de criação de lote não será interrompido, mas a quantidade de garrafas não será reduzida", "Ok");
                    }
                }
                else
                {
                    DisplayAlert("Erro", "Valor no Banco de dados é inferior ao que deve ser retirado, o processo de criação de lote não será interrompido, mas a quantidade de garrafas não será reduzida", "ok");
                }
            }
            else
            {
                DisplayAlert("Erro", "Valor no Banco de dados é inferior ao que deve ser retirado, o processo de criação de lote não será interrompido, mas a quantidade de garrafas não será reduzida", "ok");
            }
        }
        public async Task<Lacres> Getlacres250ou500ml(double quantidade)
        {
            if ((await firebase.Child("LGBT").Child("Lacres").OnceAsync<Lacres>()).Where(a => a.Object.QtdL250ou500 >= quantidade).FirstOrDefault() != null)
            {
                try
                {
                    var produto = (await firebase.Child("LGBT").Child("Lacres").OnceAsync<Lacres>()).Where(a => a.Object.QtdL250ou500 >= quantidade).FirstOrDefault();
                    return await firebase.Child("LGBT").Child("Lacres").Child(produto.Key).OnceSingleAsync<Lacres>();
                }

                catch (Exception)
                {
                    throw;
                }
            }
            else if ((await firebase.Child("LGBT").Child("Lacres").OnceAsync<Lacres>()).Where(a => a.Object.QtdL250ou500 <= quantidade).FirstOrDefault() != null)
            {
                try
                {
                    var produto = (await firebase.Child("LGBT").Child("Lacres").OnceAsync<Lacres>()).Where(a => a.Object.QtdL250ou500 <= quantidade).FirstOrDefault();
                    return await firebase.Child("LGBT").Child("Lacres").Child(produto.Key).OnceSingleAsync<Lacres>();
                }

                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }
        public async Task updlacres250ou500ml(double quantidade)
        {
            var p = await Getlacres250ou500ml(quantidade);
            if (p != null)
            {
                double qtdbd = p.QtdL250ou500;
                if (qtdbd >= quantidade)
                {
                    try
                    {
                        var updt = (await firebase.Child("LGBT").Child("Lacres").OnceAsync<Lacres>()).Where(a => a.Object.QtdL250ou500 == qtdbd).FirstOrDefault();
                        double qtd = qtdbd - quantidade;
                        await firebase.Child("LGBT").Child("Lacres").Child(updt.Key).PutAsync(new Lacres() { QtdL250ou500 = qtd });
                    }
                    catch (Exception ex)
                    {
                        DisplayAlert("Erro", "Erro ao diminuir o numero de garrafas, o processo de criação de lote não será interrompido, mas a quantidade de garrafas não será reduzida", "Ok");
                    }
                }
                else
                {
                    DisplayAlert("Erro", "Valor no Banco de dados é inferior ao que deve ser retirado, o processo de criação de lote não será interrompido, mas a quantidade de garrafas não será reduzida", "ok");
                }
            }
            else
            {
                DisplayAlert("Erro", "Valor no Banco de dados é inferior ao que deve ser retirado, o processo de criação de lote não será interrompido, mas a quantidade de garrafas não será reduzida", "ok");
            }
        }
        public async Task<Garrafas> Getgarrafas1L(double quantidade)
        {
            if ((await firebase.Child("LGBT").Child("Garrafas").OnceAsync<Garrafas>()).Where(a => a.Object.QtdG1 >= quantidade).FirstOrDefault() != null)
            {
                try
                {
                    var produto = (await firebase.Child("LGBT").Child("Garrafas").OnceAsync<Garrafas>()).Where(a => a.Object.QtdG1 >= quantidade).FirstOrDefault();
                    return await firebase.Child("LGBT").Child("Garrafas").Child(produto.Key).OnceSingleAsync<Garrafas>();
                }

                catch (Exception)
                {
                    throw;
                }
            }
            else if ((await firebase.Child("LGBT").Child("Garrafas").OnceAsync<Garrafas>()).Where(a => a.Object.QtdG1 <= quantidade).FirstOrDefault() != null)
            {
                try
                {
                    var produto = (await firebase.Child("LGBT").Child("Garrafas").OnceAsync<Garrafas>()).Where(a => a.Object.QtdG1 <= quantidade).FirstOrDefault();
                    return await firebase.Child("LGBT").Child("Garrafas").Child(produto.Key).OnceSingleAsync<Garrafas>();
                }

                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }
        public async Task updgarrafas1L(double quantidade)
        {
            var p = await Getgarrafas1L(quantidade);
            if (p != null)
            {
                double qtdbd = p.QtdG1;
                if (qtdbd >= quantidade)
                {
                    try
                    {
                        var updt = (await firebase.Child("LGBT").Child("Garrafas").OnceAsync<Garrafas>()).Where(a => a.Object.QtdG1 == qtdbd).FirstOrDefault();
                        double qtd = qtdbd - quantidade;
                        await firebase.Child("LGBT").Child("Garrafas").Child(updt.Key).PutAsync(new Garrafas() { QtdG1 = qtd });
                    }
                    catch (Exception ex)
                    {
                        DisplayAlert("Erro", "Erro ao diminuir o numero de garrafas, o processo de criação de lote não será interrompido, mas a quantidade de garrafas não será reduzida", "Ok");
                    }
                }
                else
                {
                    DisplayAlert("Erro", "Valor no Banco de dados é inferior ao que deve ser retirado, o processo de criação de lote não será interrompido, mas a quantidade de garrafas não será reduzida", "ok");
                }
            }
            else
            {
                DisplayAlert("Erro", "Valor no Banco de dados é inferior ao que deve ser retirado, o processo de criação de lote não será interrompido, mas a quantidade de garrafas não será reduzida", "ok");
            }
        }
        public async Task<Garrafas> Getgarrafas50ml(double quantidade)
        {
            if ((await firebase.Child("LGBT").Child("Garrafas").OnceAsync<Garrafas>()).Where(a => a.Object.QtdG50 >= quantidade).FirstOrDefault() != null)
            {
                try
                {
                    var produto = (await firebase.Child("LGBT").Child("Garrafas").OnceAsync<Garrafas>()).Where(a => a.Object.QtdG50 >= quantidade).FirstOrDefault();
                    return await firebase.Child("LGBT").Child("Garrafas").Child(produto.Key).OnceSingleAsync<Garrafas>();
                }

                catch (Exception)
                {
                    throw;
                }
            }
            else if ((await firebase.Child("LGBT").Child("Garrafas").OnceAsync<Garrafas>()).Where(a => a.Object.QtdG50 <= quantidade).FirstOrDefault() != null)
            {
                try
                {
                    var produto = (await firebase.Child("LGBT").Child("Garrafas").OnceAsync<Garrafas>()).Where(a => a.Object.QtdG50 <= quantidade).FirstOrDefault();
                    return await firebase.Child("LGBT").Child("Garrafas").Child(produto.Key).OnceSingleAsync<Garrafas>();
                }

                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }
        public async Task updgarrafas50ml(double quantidade)
        {
            var p = await Getgarrafas50ml(quantidade);
            if (p != null)
            {
                double qtdbd = p.QtdG50;
                if (qtdbd >= quantidade)
                {
                    try
                    {
                        var updt = (await firebase.Child("LGBT").Child("Garrafas").OnceAsync<Garrafas>()).Where(a => a.Object.QtdG50 == qtdbd).FirstOrDefault();
                        double qtd = qtdbd - quantidade;
                        await firebase.Child("LGBT").Child("Garrafas").Child(updt.Key).PutAsync(new Garrafas() { QtdG50 = qtd });
                    }
                    catch (Exception ex)
                    {
                        DisplayAlert("Erro", "Erro ao diminuir o numero de garrafas, o processo de criação de lote não será interrompido, mas a quantidade de garrafas não será reduzida", "Ok");
                    }
                }
                else
                {
                    DisplayAlert("Erro", "Valor no Banco de dados é inferior ao que deve ser retirado, o processo de criação de lote não será interrompido, mas a quantidade de garrafas não será reduzida", "ok");
                }
            }
            else
            {
                DisplayAlert("Erro", "Valor no Banco de dados é inferior ao que deve ser retirado, o processo de criação de lote não será interrompido, mas a quantidade de garrafas não será reduzida", "ok");
            }
        }
        public async Task<Garrafas> Getgarrafas250ml(double quantidade)
        {
            if ((await firebase.Child("LGBT").Child("Garrafas").OnceAsync<Garrafas>()).Where(a => a.Object.QtdG250 >= quantidade).FirstOrDefault() != null)
            {
                try
                {
                    var produto = (await firebase.Child("LGBT").Child("Garrafas").OnceAsync<Garrafas>()).Where(a => a.Object.QtdG250 >= quantidade).FirstOrDefault();
                    return await firebase.Child("LGBT").Child("Garrafas").Child(produto.Key).OnceSingleAsync<Garrafas>();
                }

                catch (Exception)
                {
                    throw;
                }
            }
            else if ((await firebase.Child("LGBT").Child("Garrafas").OnceAsync<Garrafas>()).Where(a => a.Object.QtdG250 <= quantidade).FirstOrDefault() != null)
            {
                try
                {
                    var produto = (await firebase.Child("LGBT").Child("Garrafas").OnceAsync<Garrafas>()).Where(a => a.Object.QtdG250 <= quantidade).FirstOrDefault();
                    return await firebase.Child("LGBT").Child("Garrafas").Child(produto.Key).OnceSingleAsync<Garrafas>();
                }

                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }
        public async Task updgarrafas250ml(double quantidade)
        {
            var p = await Getgarrafas250ml(quantidade);
            if (p != null)
            {
                double qtdbd = p.QtdG250;
                if (qtdbd >= quantidade)
                {
                    try
                    {
                        var updt = (await firebase.Child("LGBT").Child("Garrafas").OnceAsync<Garrafas>()).Where(a => a.Object.QtdG250 == qtdbd).FirstOrDefault();
                        double qtd = qtdbd - quantidade;
                        await firebase.Child("LGBT").Child("Garrafas").Child(updt.Key).PutAsync(new Garrafas() { QtdG250 = qtd });
                    }
                    catch (Exception ex)
                    {
                        DisplayAlert("Erro", "Erro ao diminuir o numero de garrafas, o processo de criação de lote não será interrompido, mas a quantidade de garrafas não será reduzida", "Ok");
                    }
                }
                else
                {
                    DisplayAlert("Erro", "Valor no Banco de dados é inferior ao que deve ser retirado, o processo de criação de lote não será interrompido, mas a quantidade de garrafas não será reduzida", "ok");
                }
            }
            else
            {
                DisplayAlert("Erro", "Valor no Banco de dados é inferior ao que deve ser retirado, o processo de criação de lote não será interrompido, mas a quantidade de garrafas não será reduzida", "ok");
            }
        }
        public async Task<Garrafas> Getgarrafas500ml(double quantidade)
        {
            if ((await firebase.Child("LGBT").Child("Garrafas").OnceAsync<Garrafas>()).Where(a => a.Object.QtdG500 >= quantidade).FirstOrDefault() != null)
            {
                try
                {
                    var produto = (await firebase.Child("LGBT").Child("Garrafas").OnceAsync<Garrafas>()).Where(a => a.Object.QtdG500 >= quantidade).FirstOrDefault();
                    return await firebase.Child("LGBT").Child("Garrafas").Child(produto.Key).OnceSingleAsync<Garrafas>();
                }

                catch (Exception)
                {
                    throw;
                }
            }
            else if ((await firebase.Child("LGBT").Child("Garrafas").OnceAsync<Garrafas>()).Where(a => a.Object.QtdG500 <= quantidade).FirstOrDefault() != null)
            {
                try
                {
                    var produto = (await firebase.Child("LGBT").Child("Garrafas").OnceAsync<Garrafas>()).Where(a => a.Object.QtdG500 <= quantidade).FirstOrDefault();
                    return await firebase.Child("LGBT").Child("Garrafas").Child(produto.Key).OnceSingleAsync<Garrafas>();
                }

                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }
        public async Task updgarrafas500ml(double quantidade)
        {
            var p = await Getgarrafas500ml(quantidade);
            if (p != null)
            {
                double qtdbd = p.QtdG500;
                if (qtdbd >= quantidade)
                {
                    try
                    {
                        var updt = (await firebase.Child("LGBT").Child("Garrafas").OnceAsync<Garrafas>()).Where(a => a.Object.QtdG500 == qtdbd).FirstOrDefault();
                        double qtd = qtdbd - quantidade;
                        await firebase.Child("LGBT").Child("Garrafas").Child(updt.Key).PutAsync(new Garrafas() { QtdG500 = qtd });
                    }
                    catch (Exception ex)
                    {
                        DisplayAlert("Erro", "Erro ao diminuir o numero de garrafas, o processo de criação de lote não será interrompido, mas a quantidade de garrafas não será reduzida", "Ok");
                    }
                }
                else
                {
                    DisplayAlert("Erro", "Valor no Banco de dados é inferior ao que deve ser retirado, o processo de criação de lote não será interrompido, mas a quantidade de garrafas não será reduzida", "ok");
                }
            }
            else
            {
                DisplayAlert("Erro", "Valor no Banco de dados é inferior ao que deve ser retirado, o processo de criação de lote não será interrompido, mas a quantidade de garrafas não será reduzida", "ok");
            }
        }
        public async Task<Tampas> Gettampas1L(double quantidade)
        {
            if ((await firebase.Child("LGBT").Child("Tampas").OnceAsync<Tampas>()).Where(a => a.Object.QtdT1 >= quantidade).FirstOrDefault() != null)
            {
                try
                {
                    var produto = (await firebase.Child("LGBT").Child("Tampas").OnceAsync<Tampas>()).Where(a => a.Object.QtdT1 >= quantidade).FirstOrDefault();
                    return await firebase.Child("LGBT").Child("Tampas").Child(produto.Key).OnceSingleAsync<Tampas>();
                }

                catch (Exception)
                {
                    throw;
                }
            }
            else if ((await firebase.Child("LGBT").Child("Tampas").OnceAsync<Tampas>()).Where(a => a.Object.QtdT1 <= quantidade).FirstOrDefault() != null)
            {
                try
                {
                    var produto = (await firebase.Child("LGBT").Child("Tampas").OnceAsync<Tampas>()).Where(a => a.Object.QtdT1 <= quantidade).FirstOrDefault();
                    return await firebase.Child("LGBT").Child("Tampas").Child(produto.Key).OnceSingleAsync<Tampas>();
                }

                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }
        public async Task updtampas1L(double quantidade)
        {
            var p = await Gettampas1L(quantidade);
            if (p != null)
            {
                double qtdbd = p.QtdT1;
                if (qtdbd >= quantidade)
                {
                    try
                    {
                        var updt = (await firebase.Child("LGBT").Child("Tampas").OnceAsync<Tampas>()).Where(a => a.Object.QtdT1 == qtdbd).FirstOrDefault();
                        double qtd = qtdbd - quantidade;
                        await firebase.Child("LGBT").Child("Tampas").Child(updt.Key).PutAsync(new Tampas() { QtdT1 = qtd });
                    }
                    catch (Exception ex)
                    {
                        DisplayAlert("Erro", "Erro ao diminuir o numero de tampas, o processo de criação de lote não será interrompido, mas a quantidade de tampas não será reduzida", "Ok");
                    }
                }
                else
                {
                    DisplayAlert("Erro", "Valor no Banco de dados é inferior ao que deve ser retirado, o processo de criação de lote não será interrompido, mas a quantidade de tampas não será reduzida", "ok");
                }
            }
            else
            {
                DisplayAlert("Erro", "Valor no Banco de dados é inferior ao que deve ser retirado, o processo de criação de lote não será interrompido, mas a quantidade de tampas não será reduzida", "ok");
            }
        }
        public async Task<Tampas> Gettampas50ml(double quantidade)
        {
            if ((await firebase.Child("LGBT").Child("Tampas").OnceAsync<Tampas>()).Where(a => a.Object.QtdT50 >= quantidade).FirstOrDefault() != null)
            {
                try
                {
                    var produto = (await firebase.Child("LGBT").Child("Tampas").OnceAsync<Tampas>()).Where(a => a.Object.QtdT50 >= quantidade).FirstOrDefault();
                    return await firebase.Child("LGBT").Child("Tampas").Child(produto.Key).OnceSingleAsync<Tampas>();
                }

                catch (Exception)
                {
                    throw;
                }
            }
            else if ((await firebase.Child("LGBT").Child("Tampas").OnceAsync<Tampas>()).Where(a => a.Object.QtdT50 <= quantidade).FirstOrDefault() != null)
            {
                try
                {
                    var produto = (await firebase.Child("LGBT").Child("Tampas").OnceAsync<Tampas>()).Where(a => a.Object.QtdT50 <= quantidade).FirstOrDefault();
                    return await firebase.Child("LGBT").Child("Tampas").Child(produto.Key).OnceSingleAsync<Tampas>();
                }

                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }
        public async Task updtampas50ml(double quantidade)
        {
            var p = await Gettampas50ml(quantidade);
            if (p != null)
            {
                double qtdbd = p.QtdT50;
                if (qtdbd >= quantidade)
                {
                    try
                    {
                        var updt = (await firebase.Child("LGBT").Child("Tampas").OnceAsync<Tampas>()).Where(a => a.Object.QtdT50 == qtdbd).FirstOrDefault();
                        double qtd = qtdbd - quantidade;
                        await firebase.Child("LGBT").Child("Tampas").Child(updt.Key).PutAsync(new Tampas() { QtdT50 = qtd });
                    }
                    catch (Exception ex)
                    {
                        DisplayAlert("Erro", "Erro ao diminuir o numero de tampas, o processo de criação de lote não será interrompido, mas a quantidade de tampas não será reduzida", "Ok");
                    }
                }
                else
                {
                    DisplayAlert("Erro", "Valor no Banco de dados é inferior ao que deve ser retirado, o processo de criação de lote não será interrompido, mas a quantidade de tampas não será reduzida", "ok");
                }
            }
            else
            {
                DisplayAlert("Erro", "Valor no Banco de dados é inferior ao que deve ser retirado, o processo de criação de lote não será interrompido, mas a quantidade de tampas não será reduzida", "ok");
            }
        }
        public async Task<Tampas> Gettampas250ml(double quantidade)
        {
            if ((await firebase.Child("LGBT").Child("Tampas").OnceAsync<Tampas>()).Where(a => a.Object.QtdT250 >= quantidade).FirstOrDefault() != null)
            {
                try
                {
                    var produto = (await firebase.Child("LGBT").Child("Tampas").OnceAsync<Tampas>()).Where(a => a.Object.QtdT250 >= quantidade).FirstOrDefault();
                    return await firebase.Child("LGBT").Child("Tampas").Child(produto.Key).OnceSingleAsync<Tampas>();
                }

                catch (Exception)
                {
                    throw;
                }
            }
            else if ((await firebase.Child("LGBT").Child("Tampas").OnceAsync<Tampas>()).Where(a => a.Object.QtdT250 <= quantidade).FirstOrDefault() != null)
            {
                try
                {
                    var produto = (await firebase.Child("LGBT").Child("Tampas").OnceAsync<Tampas>()).Where(a => a.Object.QtdT250 <= quantidade).FirstOrDefault();
                    return await firebase.Child("LGBT").Child("Tampas").Child(produto.Key).OnceSingleAsync<Tampas>();
                }

                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }
        public async Task updtampas250ml(double quantidade)
        {
            var p = await Gettampas250ml(quantidade);
            if (p != null)
            {
                double qtdbd = p.QtdT250;
                if (qtdbd >= quantidade)
                {
                    try
                    {
                        var updt = (await firebase.Child("LGBT").Child("Tampas").OnceAsync<Tampas>()).Where(a => a.Object.QtdT250 == qtdbd).FirstOrDefault();
                        double qtd = qtdbd - quantidade;
                        await firebase.Child("LGBT").Child("Tampas").Child(updt.Key).PutAsync(new Tampas() { QtdT250 = qtd });
                    }
                    catch (Exception ex)
                    {
                        DisplayAlert("Erro", "Erro ao diminuir o numero de tampas, o processo de criação de lote não será interrompido, mas a quantidade de tampas não será reduzida", "Ok");
                    }
                }
                else
                {
                    DisplayAlert("Erro", "Valor no Banco de dados é inferior ao que deve ser retirado, o processo de criação de lote não será interrompido, mas a quantidade de tampas não será reduzida", "ok");
                }
            }
            else
            {
                DisplayAlert("Erro", "Valor no Banco de dados é inferior ao que deve ser retirado, o processo de criação de lote não será interrompido, mas a quantidade de tampas não será reduzida", "ok");
            }
        }
        public async Task<Tampas> Gettampas500ml(double quantidade)
        {
            if ((await firebase.Child("LGBT").Child("Tampas").OnceAsync<Tampas>()).Where(a => a.Object.QtdT500 >= quantidade).FirstOrDefault() != null)
            {
                try
                {
                    var produto = (await firebase.Child("LGBT").Child("Tampas").OnceAsync<Tampas>()).Where(a => a.Object.QtdT500 >= quantidade).FirstOrDefault();
                    return await firebase.Child("LGBT").Child("Tampas").Child(produto.Key).OnceSingleAsync<Tampas>();
                }

                catch (Exception)
                {
                    throw;
                }
            }
            else if ((await firebase.Child("LGBT").Child("Tampas").OnceAsync<Tampas>()).Where(a => a.Object.QtdT500 <= quantidade).FirstOrDefault() != null)
            {
                try
                {
                    var produto = (await firebase.Child("LGBT").Child("Tampas").OnceAsync<Tampas>()).Where(a => a.Object.QtdT500 <= quantidade).FirstOrDefault();
                    return await firebase.Child("LGBT").Child("Tampas").Child(produto.Key).OnceSingleAsync<Tampas>();
                }

                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }
        public async Task updtampas500ml(double quantidade)
        {
            var p = await Gettampas500ml(quantidade);
            if (p != null)
            {
                double qtdbd = p.QtdT500;
                if (qtdbd >= quantidade)
                {
                    try
                    {
                        var updt = (await firebase.Child("LGBT").Child("Tampas").OnceAsync<Tampas>()).Where(a => a.Object.QtdT500 == qtdbd).FirstOrDefault();
                        double qtd = qtdbd - quantidade;
                        await firebase.Child("LGBT").Child("Tampas").Child(updt.Key).PutAsync(new Tampas() { QtdT500 = qtd });
                    }
                    catch (Exception ex)
                    {
                        DisplayAlert("Erro", "Erro ao diminuir o numero de tampas, o processo de criação de lote não será interrompido, mas a quantidade de tampas não será reduzida", "Ok");
                    }
                }
                else
                {
                    DisplayAlert("Erro", "Valor no Banco de dados é inferior ao que deve ser retirado, o processo de criação de lote não será interrompido, mas a quantidade de tampas não será reduzida", "ok");
                }
            }
            else
            {
                DisplayAlert("Erro", "Valor no Banco de dados é inferior ao que deve ser retirado, o processo de criação de lote não será interrompido, mas a quantidade de tampas não será reduzida", "ok");
            }
        }
        public async Task<Tampas> Gettampasvm(double quantidade)
        {
            if ((await firebase.Child("LGBT").Child("Tampas").OnceAsync<Tampas>()).Where(a => a.Object.QtdTVM >= quantidade).FirstOrDefault() != null)
            {
                try
                {
                    var produto = (await firebase.Child("LGBT").Child("Tampas").OnceAsync<Tampas>()).Where(a => a.Object.QtdTVM >= quantidade).FirstOrDefault();
                    return await firebase.Child("LGBT").Child("Tampas").Child(produto.Key).OnceSingleAsync<Tampas>();
                }

                catch (Exception)
                {
                    throw;
                }
            }
            else if ((await firebase.Child("LGBT").Child("Tampas").OnceAsync<Tampas>()).Where(a => a.Object.QtdTVM <= quantidade).FirstOrDefault() != null)
            {
                try
                {
                    var produto = (await firebase.Child("LGBT").Child("Tampas").OnceAsync<Tampas>()).Where(a => a.Object.QtdTVM <= quantidade).FirstOrDefault();
                    return await firebase.Child("LGBT").Child("Tampas").Child(produto.Key).OnceSingleAsync<Tampas>();
                }

                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }
        public async Task updtampasvm(double quantidade)
        {
            var p = await Gettampasvm(quantidade);
            if (p != null)
            {
                double qtdbd = p.QtdTVM;
                if (qtdbd >= quantidade)
                {
                    try
                    {
                        var updt = (await firebase.Child("LGBT").Child("Tampas").OnceAsync<Tampas>()).Where(a => a.Object.QtdTVM == qtdbd).FirstOrDefault();
                        double qtd = qtdbd - quantidade;
                        await firebase.Child("LGBT").Child("Tampas").Child(updt.Key).PutAsync(new Tampas() { QtdTVM = qtd });
                    }
                    catch (Exception ex)
                    {
                        DisplayAlert("Erro", "Erro ao diminuir o numero de tampas, o processo de criação de lote não será interrompido, mas a quantidade de tampas não será reduzida", "Ok");
                    }
                }
                else
                {
                    DisplayAlert("Erro", "Valor no Banco de dados é inferior ao que deve ser retirado, o processo de criação de lote não será interrompido, mas a quantidade de tampas não será reduzida", "ok");
                }
            }
            else
            {
                DisplayAlert("Erro", "Valor no Banco de dados é inferior ao que deve ser retirado, o processo de criação de lote não será interrompido, mas a quantidade de tampas não será reduzida", "ok");
            }
        }
        public async Task<bool> AddLoteFrutal(string lote,string sabor, string calda, string dosagem, string maceradoem, string DP, double valdvenda, double custo, double quantidade, double lucro )
        {
            if (await IsLotePExists(lote) == false && await IsLoteExists(lote, sabor)==false)
            {
                await firebase.Child("Produção").PostAsync(new Produto() { Lote = lote, Sabor = sabor, Calda = calda, Dosagem = dosagem, DMaceracao = maceradoem, DP=DP, ValdVenda = valdvenda, Custo = custo, Quantidade = quantidade, Lucro = lucro });
                await firebase.Child(sabor).PostAsync(new Produto() { Lote = lote, Sabor = sabor, Calda = calda, Dosagem = dosagem, DMaceracao = maceradoem, DP = DP, ValdVenda = valdvenda, Custo = custo, Quantidade = quantidade, Lucro = lucro });

                await updtampasvm(quantidade);

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
                var updtprodutops = (await firebase.Child(sabor).OnceAsync<Produto>()).Where(a => a.Object.Lote == lote).FirstOrDefault();
                await firebase.Child(sabor).Child(updtprodutops.Key).PutAsync(new Produto() { Lote = lote, Sabor = sabor, Calda = calda, Dosagem = dosagem, ValdVenda = valdvenda, Custo = custo, Quantidade = quantidade, Lucro = lucro });

                if (dosagem=="50ml")
                {
                    await updtampas50ml(quantidade);
                    await updlacres50ml(quantidade);
                    await updgarrafas50ml(quantidade);
                    await updrotulo50(quantidade, sabor);
                }
                else if (dosagem == "250ml")
                {
                    await updtampas250ml(quantidade);
                    await updlacres250ou500ml(quantidade);
                    await updgarrafas250ml(quantidade);
                    await updrotulo250(quantidade, sabor);
                }
                else if (dosagem == "500ml")
                {
                    await updtampas500ml(quantidade);
                    await updlacres250ou500ml(quantidade);
                    await updgarrafas500ml(quantidade);
                    await updrotulo500(quantidade, sabor);
                }
                else if (dosagem == "1L")
                {
                    await updtampas1L(quantidade);
                    await updgarrafas1L(quantidade);
                    await updrotulo1(quantidade, sabor);
                }

                await updEB(quantidade);

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
        public async Task<List<Tampas>> GetTampas()
        {
            try
            {
                return (await firebase.Child("LGBT").Child("Tampas").OnceAsync<Tampas>()).Where(a=>a.Object.Lista==1).Select(item => new Tampas
                {
                    QtdT1 = item.Object.QtdT1,
                    QtdT250 = item.Object.QtdT250,
                    QtdT500 = item.Object.QtdT500,
                    QtdT50 = item.Object.QtdT50,
                    QtdTVM = item.Object.QtdTVM,
                }).ToList();

            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<Lacres>> GetLacres()
        {
            try
            {
                return (await firebase.Child("LGBT").Child("Lacres").OnceAsync<Lacres>()).Where(a => a.Object.Lista == 1).Select(item => new Lacres
                {
                    QtdL250ou500 = item.Object.QtdL250ou500,
                    QtdL50 = item.Object.QtdL50,
                }).ToList();

            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<Garrafas>> GetGarrafas()
        {
            try
            {
                return (await firebase.Child("LGBT").Child("Garrafas").OnceAsync<Garrafas>()).Where(a => a.Object.Lista == 1).Select(item => new Garrafas
                {
                    QtdG1 = item.Object.QtdG1,
                    QtdG250 = item.Object.QtdG250,
                    QtdG500 = item.Object.QtdG500,
                    QtdG50 = item.Object.QtdG50,
                }).ToList();

            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<Papelaria>> GetPapelaria()
        {
            return (await firebase.Child("Papelaria").OnceAsync<Papelaria>()).Select(item => new Papelaria
            {
                QtdEB=item.Object.QtdEB,
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