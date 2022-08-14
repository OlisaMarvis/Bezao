using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using System.Collections.Generic;

namespace Portfolio.Controllers
{
    public class WalletController : Controller
    {

        public WalletController()
        {

        }

        [HttpGet]
        public IActionResult WalletIndex(WalletResponse response)
        {

            return View(response);
        }

        [HttpGet]
        public IActionResult WalletBalance()
        {

            return View();
        }

        //Service
        public decimal ConvertStock(decimal stockValue, int stockType)
        { 
            if(stockType == 1)//Eth to usdt
            {
                return stockValue * 1989;

            }else if(stockType == 2) // Luna to usdt
            {
                return stockValue * 2;
            }else if(stockType == 3) //Microsoft to usdt
            {
                return stockValue * 291;
            }else if (stockType == 4)//Tesla to usdt
            {
                return stockValue * 900;
            }


            return 0;
        }


        [HttpPost]
        public IActionResult WalletBalance(string customerName, decimal microsoft, decimal etherium, decimal luna, decimal tesla)
        {
            if (microsoft != null && etherium != null && luna != null && tesla != null && customerName != "")
            {
                var msConvertedValue = ConvertStock(microsoft, 1);
                var ethConvertedValue = ConvertStock(etherium, 2);
                var LunaConvertedValue = ConvertStock(luna, 3);
                var teslaConvertedValue = ConvertStock(tesla, 4);

                var walletBalance = msConvertedValue + ethConvertedValue + LunaConvertedValue + teslaConvertedValue;
                
                var stocks = new List<Stocks>();

                Wallet wallet = new Wallet()
                {
                    CustomerName = customerName,
                    WalletValue = (double)walletBalance
                };





                WalletResponse response = new WalletResponse()
                {
                    Message = "Conversion Successful",
                    Code = "00",
                    Wallet = wallet.WalletValue,
                    CustomerName = wallet.CustomerName
                };

                return RedirectToAction("WalletIndex",  response );
            }
            //else
            //{
            //    WalletResponse response = new WalletResponse()
            //    {
            //        Message = "All stock require a value",
            //        Code = "99",
            //        Wallet = null
            //    };
            //    return RedirectToAction("WalletBalance", response);

            //}
            return null;
        }
    }
}
