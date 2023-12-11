using System;

namespace BusinessObjects.Models
{
    public class ViewInvoices
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int ProductId { get; set; }
        public string CustName { get; set; }
        public string Adress { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TotalItbis { get; set; }
        public decimal Total { get; set; }
        public DateTime FechaCreado { get; set; }

    }

}
