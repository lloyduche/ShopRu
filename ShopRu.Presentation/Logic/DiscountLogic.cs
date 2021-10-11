using ShopRu.Application.Invoices.Model;
using ShopRu.Application.Invoices.Queries;
using ShopRu.Domain;
using ShopRu.Domain.Invoice;
using ShopRu.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRu.Application.Logic
{
    public class DiscountLogic: IDiscountLogic
    {
        private readonly IShopRuDbContext _shopRuContext;

        public DiscountLogic(IShopRuDbContext shopRuContext)
        {
            _shopRuContext = shopRuContext;
        }

        public async Task<InvoiceDto> CalculateDiscount(GenerateInvoiceQuery model, string type)
        {
            decimal TotalDiscount = 0;
            decimal nonPercentageDiscount = 0;
            decimal percentageDiscount = 0;

            //get the total amount on the bill

            var totalBill = model.CreateInvoiceDto.TotalPriceOfItems();

            //perform non-percentage discount on the total bill
            nonPercentageDiscount = NonPercentageDiscount(totalBill);


            // split invoice item into groceries and non-groceries
            var Nongroceries = new List<InvoiceItemDto>();
            decimal totalBillOfNonGroceries = 0;
            foreach (var item in model.CreateInvoiceDto.Items)
            {
                if(item.item.Type != "Groceries")
                {
                     Nongroceries.Add(item);

                    totalBillOfNonGroceries += item.PriceOfEachItem();
                }
            }

            //perform a percentage discount on the bill
            var rate = _shopRuContext.Discounts.FirstOrDefault(x => x.Type == type);
            percentageDiscount = PercentageDiscount(totalBillOfNonGroceries, rate.Rate);


            // total discount 
            TotalDiscount = nonPercentageDiscount + percentageDiscount;


            // formaqt invoice
            var result = await FormatInvoice(model, TotalDiscount);

            return result;
        }




        /// <summary>
        /// Format Invoice
        /// </summary>
        /// <param name="model"></param>
        /// <param name="discount"></param>
        /// <returns></returns>
        private async Task<InvoiceDto> FormatInvoice(GenerateInvoiceQuery model, decimal discount)
        {
            
            // get customer info 
            var info = _shopRuContext.Customers.FirstOrDefault(x => x.Id == model.CreateInvoiceDto.CustomerId);
            var totalAmount = model.CreateInvoiceDto.TotalPriceOfItems();

            var cstInfo = new CustomerInfo
            {
                FirstName = info.FirstName,
                LastName = info.LastName,
                Email = info.Email

            };

            
            var newItem = new List<InvoiceItem>();
            foreach (var item in model.CreateInvoiceDto.Items)
            {

                var invItem = new Item
                {
                    Type = item.item.Type,
                    Amount = item.item.Amount,
                    ItemName = item.item.ItemName
                   
                 };

                var newInv = new InvoiceItem
                {
                    Quantity = item.Quantity,
                    ItemId = item.ItemId
                   
                };
                newItem.Add(newInv);

            }


            var invoice = new Invoice
            {
                CustomerId = model.CreateInvoiceDto.CustomerId,
                Discount = discount,
                TotalAmount = totalAmount,
                SubTotal = totalAmount - discount,
                Items = newItem,

            };
           
            var res = new InvoiceDto
            {
                Discount = discount,
                TotalAmount = totalAmount,
                SubTotal = totalAmount - discount,
                Customer = cstInfo,      
                ItemsPurchased = model.CreateInvoiceDto.Items,
                InvoiceId = invoice.InvoiceId

            };

            await _shopRuContext.Invoices.AddAsync(invoice);
            await _shopRuContext.SaveChangesAsync();

            return res;
        }


        private static decimal NonPercentageDiscount(decimal bill)
        {
            var discount = (bill / 100) * 5;
            return discount;
        }

        private static decimal PercentageDiscount(decimal bill, decimal rate)
        {
            var discount = bill * rate;
            return discount;
        }




    }
}
