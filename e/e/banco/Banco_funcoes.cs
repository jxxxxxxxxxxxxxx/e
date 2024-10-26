using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Linq;
using System.Globalization;

namespace e.banco
{
    internal class Banco_funcoes
    {
        private SQLiteConnection conexao;
        string pasta = System.Environment.GetFolderPath
        (System.Environment.SpecialFolder.Personal);


        public void CriarBancoDeDados()
        {
            string dbPath = System.IO.Path.Combine
            (Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Expo.db3");
            conexao = new SQLiteConnection(dbPath);
            conexao.CreateTable<Expo>();
        }

        public void AddTarefas(string tarefa, string dia, string mes, string ano)
        {
            conexao.Query<Expo>("INSERT INTO expo (Tarefa,Dia,Mes,Ano, Concluida) " +
            "VALUES('" + tarefa + "','" + dia + "','" + mes + "'," + ano + ",0)");
        }

        private void DisplayAlert(string v1, string v2, string v3)
        {
            throw new NotImplementedException();
        }

        public List<Expo> GetTarefas(string dia, string mes, string ano)
        {
        return conexao.Query<Expo>("SELECT * FROM expo where Dia='"+dia+"' and Mes='"+mes+"' and Ano='"+ano+"'");
        }

        public void Excluirtarefa(string tarefa, string dia, string mes, string ano)
        {
            conexao.Query<Expo>("DELETE FROM expo WHERE Tarefa = '" + tarefa+"' and Dia='"+dia+"' and Mes='"+mes+"' and Ano='"+ano+"'");
        }

        public void EditarTarefa(string tarefa, string tarefaantes)
        {
           conexao.Query<Expo>("UPDATE expo SET Tarefa = '" + tarefa+"' WHERE Tarefa = '" + tarefaantes + "' ");
        }
         public List<Expo> PesquisarTarefa(string query)
        => conexao.Query<Expo>
        ("SELECT * FROM expo WHERE Tarefa like \"%" + query.Trim() + "%\"");
        public List<Expo> PesquisarTarefadia(string query)
        => conexao.Query<Expo>
        ("SELECT * FROM expo WHERE Dia like \"%" + query.Trim() + "%\"");
        public List<Expo> PesquisarTarefames(string query)
        => conexao.Query<Expo>
        ("SELECT * FROM expo WHERE Mes like \"%" + query.Trim() + "%\"");
        public List<Expo> PesquisarTarefaano(string query)
        => conexao.Query<Expo>
        ("SELECT * FROM expo WHERE Ano like \"%" + query.Trim() + "%\"");

    }


}

