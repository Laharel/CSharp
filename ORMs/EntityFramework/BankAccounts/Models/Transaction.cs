using System;

namespace BankAccounts.Models
{
    public class Transaction
    {
        public int TransactionId {get;set;}

        public decimal Amount {get;set;}
        public int UserId {get;set;}
        public User TheUser {get;set;}
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}