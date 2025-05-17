using DocumentFormat.OpenXml.Office2010.Excel;
using konversiExcelDanPdf.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace konversiExcelDanPdf.Data {
  public class AccountSqlServerRepository : IAccountRepository {
    private string connectionString = "server=(localdb)\\MSSQLLocalDB;database=AegisPhaseTwo;Integrated Security=true";
  
    public Account GetById(int id) {
      Account account = new Account();
      using(SqlConnection sqlConnection = new SqlConnection(connectionString)) {
        SqlParameter sqlParameter = new SqlParameter();
        SqlCommand sqlCommand = new SqlCommand($"execute spGetById @id = {id}", sqlConnection);
        sqlConnection.Open();
        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
        sqlDataReader.Read();
        account.Id = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Id"));
        account.NomorRekening = sqlDataReader.GetString(sqlDataReader.GetOrdinal("NomorRekening"));
        account.Nama = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Nama"));
        account.Saldo = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Saldo"));
      }
      return account;
    }
    public void SaldoChanges(Account updated) {
      using(SqlConnection sqlConnection = new SqlConnection(connectionString)) {
        SqlParameter sqlParameter = new SqlParameter();
        SqlCommand sqlCommand = new SqlCommand($"execute spSaldoChanges @id = {updated.Id}, @updateSaldo = {updated.Saldo}", sqlConnection);
        sqlConnection.Open();
        sqlCommand.ExecuteNonQuery();
      }
    }
  }
}
