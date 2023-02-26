using Ordering.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Core.Entities
{
    public class Order : Entity
    {
        public string UserName { get; set; }
        public decimal TotalPrice { get; set; }

        // BillingAddress
        [AllowNull]
        public string FirstName { get; set; }

        [AllowNull]
        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        [AllowNull]
        public string AddressLine { get; set; }

        [AllowNull]
        public string Country { get; set; }

        [AllowNull]
        public string State { get; set; }

        [AllowNull]
        public string ZipCode { get; set; }

        // Payment
        [AllowNull]
        public string CardName { get; set; }

        [AllowNull]
        public string CardNumber { get; set; }

        [AllowNull]
        public string Expiration { get; set; }

        [AllowNull]
        public string CVV { get; set; }

        [AllowNull]
        public int PaymentMethod { get; set; }
    }
}