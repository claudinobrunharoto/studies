namespace Interface.Services {
    class PaypalService : IOnlinePaymentService {

        private const double FeePercentage = 0.02;
        private const double MonthlyInterest = 0.01;

        public double Interest(double value, int months) {
            return value * MonthlyInterest * months;
        }

        public double PaymentFee(double value) {
            return value * FeePercentage;
        }
    }
}