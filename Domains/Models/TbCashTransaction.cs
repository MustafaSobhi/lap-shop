using System;
using System.Collections.Generic;

namespace LapStore.Models;

public partial class TbCashTransaction
{
    public int CashTransactionid { get; set; }

    public DateTime CashDate { get; set; }

    public decimal CashValue { get; set; }
}
