using System.Globalization;

namespace Interface.Entities
{
    class Installments
    {
        public DateTime Date { get; set; }
        public double Amount { get; set; }

        public Installments(DateTime date, double amount)
        {
            Date = date;
            Amount = amount;
        }

        public override string ToString()
        {
            return Date.ToString("dd/MM/yyyy")
                + " - "
                + Amount.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}