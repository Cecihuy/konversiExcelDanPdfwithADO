using Fingers10.ExcelExport.Attributes;

namespace konversiExcelDanPdf.ViewModels {
  public class AccountViewModel {
    [IncludeInReport]
    public int Id { get; set; }
    [IncludeInReport]
    public string NomorRekening { get; set; }
    [IncludeInReport]
    public string Nama { get; set; }
    [IncludeInReport]
    public int SaldoAwal { get; set; }
    [IncludeInReport]
    public int Transaksi { get; set; }
    [IncludeInReport]
    public int SaldoAkhir { get; set; }
  }
}