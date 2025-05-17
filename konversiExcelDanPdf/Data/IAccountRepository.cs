using konversiExcelDanPdf.Models;

namespace konversiExcelDanPdf.Data {
  public interface IAccountRepository {
    Account GetById(int id);
    void SaldoChanges(Account updated);
  }
}
