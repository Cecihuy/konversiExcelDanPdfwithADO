using System.Collections.Generic;
using Fingers10.ExcelExport.ActionResults;
using konversiExcelDanPdf.Data;
using konversiExcelDanPdf.Models;
using konversiExcelDanPdf.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;

namespace konversiExcelDanPdf.Controllers {
  public class HomeController : Controller {
    private readonly IAccountRepository accountRepository;
    public HomeController(IAccountRepository accountRepository) {
      this.accountRepository=accountRepository;
    }
    [HttpGet]
    public IActionResult Index(int id = 4) {
      Account account = accountRepository.GetById(id);
      AccountViewModel accountViewModel = new AccountViewModel() {
        Id = account.Id,
        NomorRekening = account.NomorRekening,
        Nama = account.Nama,
        SaldoAwal = account.Saldo,
        Transaksi = 0,
        SaldoAkhir = 0
      };
      return View(accountViewModel);
    }
    [HttpPost]
    public IActionResult Index(AccountViewModel model) {
      int withdraw =0;
      if(ModelState.IsValid) {
        Account account = accountRepository.GetById(model.Id);
        withdraw = model.Transaksi;
        int result = account.Saldo - withdraw;
        model.SaldoAkhir = result;
        if(result >= 0) {
          return View("Konfirmasi", model);
        }
        ModelState.AddModelError(string.Empty, "Terjadi kesalahan pada input Penarikan");
      }
      return View(model);
    }
    [HttpGet]
    public IActionResult GetPdf(AccountViewModel model) {
      return new ViewAsPdf(model);
    }
    [HttpGet]
    public IActionResult GetExcel(AccountViewModel model) {
      List<AccountViewModel> data = new List<AccountViewModel>();
      data.Add(model);
      return new ExcelResult<AccountViewModel>(data, "Terimakasih", "ForAegis");
    }
  }
}
