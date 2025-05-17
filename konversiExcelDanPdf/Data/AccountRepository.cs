using konversiExcelDanPdf.Models;
using System.Collections.Generic;
using System.Linq;

namespace konversiExcelDanPdf.Data {
  public class AccountRepository : IAccountRepository {
    private List<Account> accounts;
    public AccountRepository() {
      accounts = new List<Account> {
        new Account() {Id = 1, NomorRekening="YJ123", Nama="Yujin", Saldo=444000},
        new Account() {Id = 2, NomorRekening="GL234", Nama="Gaeul", Saldo=555000},
        new Account() {Id = 3, NomorRekening="RI345", Nama="Rei", Saldo=666000},
        new Account() {Id = 4, NomorRekening="WY456", Nama="Wonyoung", Saldo=777000},
        new Account() {Id = 5, NomorRekening="LZ567", Nama="Liz", Saldo=888000},
        new Account() {Id = 6, NomorRekening="LS678", Nama="Leeseo", Saldo=999000}
      };
    }
    public Account GetById(int id) {
      Account? artist = accounts.FirstOrDefault(x => x.Id == id);
      return artist;
    }
    public void SaldoChanges(Account updated) {
      //Account? account = accounts.FirstOrDefault(x => x.Id == updated.Id);
      //account.Saldo = updated.Saldo;
    }
  }
}
