using ProbnoRS2_Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProbnoRS2_Mobile
{
    public static class CartService
    {
        public static Dictionary<int, ProizvodDetaljiVM> Cart { get; set; } = new Dictionary<int, ProizvodDetaljiVM>();
    }
}
