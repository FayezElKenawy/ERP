using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class CustomerReadViewModel
    {
        public string CustID { get; set; }
        public string CustArName { get; set; }
        public string CustEnName { get; set; }
        public string CustMobileNo { get; set; }
        public string CustAdress { get; set; }
        public double CustBalance { get; set; }
        public double CustOpenBalance { get; set; }
        public int AccountNo { get; set; }
    }
}
