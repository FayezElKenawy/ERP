using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.baseData;
using Domain.Models;

namespace Domain.ViewModels
{
    public class SalesItems : BaseDataClass
    {
        public int ProductId { get; set; }
        public List< Product>  Products { get; set; }
    }
}
