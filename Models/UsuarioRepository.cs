using System;
using System.Collections.Generic;
using MySqlConnector;

namespace PROJ_MASSINHA.Models
{

public class UsuarioRepository
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

    public void inserir(Usuario u) // inserir um usuario
    {
     MySqlConnection Conexao = new MySqlConnection(DadosdeConexao);
        Conexao.Open();
        string Query = "INSERT INTO usuarios (nomeUsuario, emailUsuario, loginUsuario, senhaUsuario, datadenascimentoUsuario, sexodoUsuario, mensagemdoUsuario) VALUES (@nomeUsuario, @emailUsuario, @loginUsuario, @senhaUsuario, @datadenascimentoUsuario, @sexodoUsuario, @mensagemdoUsuario)";
        MySqlCommand Comando = new MySqlCommand(Query, Conexao);

        Comando.Parameters.AddWithValue("@nomeUsuario", u.nomeUsuario);
        Comando.Parameters.AddWithValue("@emailUsuario", u.emailUsuario);
        Comando.Parameters.AddWithValue("@loginUsuario", u.loginUsuario);
        Comando.Parameters.AddWithValue("@senhaUsuario", u.senhaUsuario);
        Comando.Parameters.AddWithValue("@DatadeNascimentoUsuario", u.datadenascimentoUsuario);
        Comando.Parameters.AddWithValue("@sexodoUsuario", u.sexodoUsuario);
        Comando.Parameters.AddWithValue("@mensagemdoUsuario", u.mensagemdoUsuario);
        Comando.ExecuteNonQuery();
        Conexao.Close();
    }

        public List<Usuario> Query()
{
    MySqlConnection conexao = new MySqlConnection(DadosdeConexao);
    conexao.Open();
    string sql = "SELECT * FROM usuarios ORDER BY nomeUsuario";
    MySqlCommand comandoQuery = new MySqlCommand(sql, conexao);
    MySqlDataReader reader = comandoQuery.ExecuteReader();
    List<Usuario> lista = new List<Usuario>();
    
    while (reader.Read())
    {
      Usuario usr = new Usuario();  
        usr.IdUsuario = reader.GetInt32("IdUsuario");
       
        if(!reader.IsDBNull(reader.GetOrdinal("nomeUsuario")))
            usr.nomeUsuario = reader.GetString("nomeUsuario");
       
        if(!reader.IsDBNull(reader.GetOrdinal("emailUsuario")))
            usr.emailUsuario = reader.GetString("emailUsuario");

        if(!reader.IsDBNull(reader.GetOrdinal("loginUsuario")))
            usr.loginUsuario = reader.GetString("loginUsuario");

        if(!reader.IsDBNull(reader.GetOrdinal("senhaUsuario")))
            usr.senhaUsuario = reader.GetString("senhaUsuario");

        if(!reader.IsDBNull(reader.GetOrdinal("datadenascimentoUsuario")))
            usr.datadenascimentoUsuario = reader.GetDateTime("datadenascimentoUsuario");

        if(!reader.IsDBNull(reader.GetOrdinal("sexodoUsuario")))
            usr.sexodoUsuario = reader.GetChar("sexodoUsuario");

        if(!reader.IsDBNull(reader.GetOrdinal("mensagemdoUsuario")))
            usr.mensagemdoUsuario = reader.GetString("mensagemdoUsuario");
     
        lista.Add(usr);
    }
    conexao.Close();
    return lista;
}    

 public Usuario buscarporID (int IdUsuario)
 {
    MySqlConnection Conexao = new MySqlConnection(DadosdeConexao);
    Conexao.Open();
    String Query = "SELECT * FROM usuarios WHERE  IdUsuario = @IdUsuario";
    MySqlCommand Comando = new MySqlCommand(Query, Conexao);
    Comando.Parameters.AddWithValue("@IdUsuario",IdUsuario);
    MySqlDataReader reader = Comando.ExecuteReader();
    Usuario usr = new Usuario();
    while (reader.Read())
    {
        
     usr.IdUsuario = reader.GetInt32("IdUsuario");
       
        if(!reader.IsDBNull(reader.GetOrdinal("nomeUsuario")))
            usr.nomeUsuario = reader.GetString("nomeUsuario");
       
        if(!reader.IsDBNull(reader.GetOrdinal("emailUsuario")))
            usr.emailUsuario = reader.GetString("emailUsuario");

        if(!reader.IsDBNull(reader.GetOrdinal("loginUsuario")))
            usr.loginUsuario = reader.GetString("loginUsuario");

        if(!reader.IsDBNull(reader.GetOrdinal("senhaUsuario")))
            usr.senhaUsuario = reader.GetString("senhaUsuario");

        if(!reader.IsDBNull(reader.GetOrdinal("datadenascimentoUsuario")))
            usr.datadenascimentoUsuario = reader.GetDateTime("datadenascimentoUsuario");

        if(!reader.IsDBNull(reader.GetOrdinal("sexodoUsuario")))
            usr.sexodoUsuario = reader.GetChar("sexodoUsuario");

        if(!reader.IsDBNull(reader.GetOrdinal("mensagemdoUsuario")))
            usr.mensagemdoUsuario = reader.GetString("mensagemdoUsuario");
     
    }
    Conexao.Close();
    return usr;
 }

 public void deletar(int IdUsuario)
 {
    MySqlConnection Conexao = new MySqlConnection(DadosdeConexao);
    Conexao.Open();
    String Query = "DELETE FROM usuarios Where IdUsuario = @IdUsuario";
    MySqlCommand Comando = new MySqlCommand(Query, Conexao);
    Comando.Parameters.AddWithValue("@IdUsuario", IdUsuario);
    Comando.ExecuteNonQuery();
    Conexao.Close();
 }

  public void editar(Usuario u)
  {
        MySqlConnection Conexao = new MySqlConnection(DadosdeConexao);
        Conexao.Open();
        string Query = "UPDATE usuarios SET nomeUsuario = @nomeUsuario, emailUsuario = @emailUsuario, loginUsuario = @loginUsuario, senhaUsuario = @senhaUsuario, datadenascimentoUsuario = @datadenascimentoUsuario, sexodoUsuario = @sexodoUsuario, mensagemdoUsuario = @mensagemdoUsuario WHERE IdUsuario=@IdUsuario";
        MySqlCommand Comando = new MySqlCommand(Query, Conexao);

        Comando.Parameters.AddWithValue("@IdUsuario", u.IdUsuario);
        Comando.Parameters.AddWithValue("@nomeUsuario", u.nomeUsuario);
        Comando.Parameters.AddWithValue("@emailUsuario", u.emailUsuario);
        Comando.Parameters.AddWithValue("@loginUsuario", u.loginUsuario);
        Comando.Parameters.AddWithValue("@senhaUsuario", u.senhaUsuario);
        Comando.Parameters.AddWithValue("@datadenascimentoUsuario", u.datadenascimentoUsuario);
        Comando.Parameters.AddWithValue("@sexodoUsuario", u.sexodoUsuario);
        Comando.Parameters.AddWithValue("@mensagemdoUsuario", u.mensagemdoUsuario);
        Comando.ExecuteNonQuery();
        Conexao.Close();

  }

  public Usuario QueryLogin(Usuario u)
{
    MySqlConnection conexao = new MySqlConnection(DadosdeConexao);
    conexao.Open();
    string sql = "SELECT * FROM usuarios WHERE loginUsuario = @loginUsuario AND senhaUsuario = @senhaUsuario";
    MySqlCommand comandoQuery = new MySqlCommand(sql, conexao);
    comandoQuery.Parameters.AddWithValue("@nomeUsuario", u.nomeUsuario);
    comandoQuery.Parameters.AddWithValue("@loginUsuario", u.loginUsuario);
    comandoQuery.Parameters.AddWithValue("@senhaUsuario", u.senhaUsuario);
    MySqlDataReader reader = comandoQuery.ExecuteReader();
    Usuario usr = null;
    if(reader.Read())
    {
        usr = new Usuario();
        usr.IdUsuario = reader.GetInt32("IdUsuario");
       if(!reader.IsDBNull(reader.GetOrdinal("nomeUsuario")))
            usr.nomeUsuario = reader.GetString("nomeUsuario");
        if(!reader.IsDBNull(reader.GetOrdinal("loginUsuario")))
            usr.loginUsuario = reader.GetString("loginUsuario");
        if(!reader.IsDBNull(reader.GetOrdinal("senhaUsuario")))
            usr.senhaUsuario = reader.GetString("senhaUsuario");
    }
   
    conexao.Close();
    return usr;
}
}
}


