using System;
using System.Collections.Generic;
using MySqlConnector;

namespace PROJ_MASSINHA.Models
{

public class opiniaoRepository
{
private const string DadosdeConexao = "Database=amantesf1; Data Source=127.0.0.1; User ID=root;";

 public void testeconexao()
    {
        MySqlConnection Conexao = new MySqlConnection(DadosdeConexao);
        Conexao.Open();
        //Codigo para conexão com o banco de dados para usar o crud
        Console.WriteLine("Uhuu Conseguimos Logar");

        Conexao.Close(); //usado para fechar a conexão 
    }

    public void inserir(opiniao o) // inserir um usuario
    {
     MySqlConnection Conexao = new MySqlConnection(DadosdeConexao);
        Conexao.Open();
        string Query = "INSERT INTO opiniao (nomeUsuario, mensagemdoUsuario) VALUES (@nomeUsuario, @mensagemdoUsuario)";
        MySqlCommand Comando = new MySqlCommand(Query, Conexao);

        Comando.Parameters.AddWithValue("@nomeUsuario", o.nomeUsuario);
        Comando.Parameters.AddWithValue("@mensagemdoUsuario", o.mensagemdoUsuario);

        Comando.ExecuteNonQuery();
        Conexao.Close();
    }
    public List<opiniao> Query()
    {
    MySqlConnection conexao = new MySqlConnection(DadosdeConexao);
    conexao.Open();
    string sql = "SELECT * FROM opiniao ORDER BY nomeUsuario";
    MySqlCommand comandoQuery = new MySqlCommand(sql, conexao);
    MySqlDataReader reader = comandoQuery.ExecuteReader();
    List<opiniao> lista = new List<opiniao>();
    
    while (reader.Read())
    {
      opiniao osr = new opiniao();  
        osr.nomeUsuario = reader.GetString("nomeUsuario");
       
        if(!reader.IsDBNull(reader.GetOrdinal("nomeUsuario")))
            osr.nomeUsuario = reader.GetString("nomeUsuario");

        if(!reader.IsDBNull(reader.GetOrdinal("mensagemdoUsuario")))
            osr.mensagemdoUsuario = reader.GetString("mensagemdoUsuario");
     
        lista.Add(osr);
    }
    conexao.Close();
    return lista;
}
}
}
