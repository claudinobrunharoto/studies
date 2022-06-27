namespace Interface.Entities
{
    class Contract
    {
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }
        public List<Installments> Items { get; set; } = new List<Installments>(); // ou colocar no constructor

        public Contract(int number, DateTime date, double value)
        {
            Number = number;
            Date = date;
            Value = value;
        }

        public void AddInstallment(Installments installments)
        {
            Items.Add(installments);
        }
    }
}