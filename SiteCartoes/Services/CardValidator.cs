using System.Text.RegularExpressions;
using System.Linq;

namespace SiteCartoes.Services
{
    public interface ICardValidator
    {
        string IdentifyCardBrand(string cardNumber);
        bool ValidateCardNumber(string cardNumber);
    }

    public class CardValidator : ICardValidator
    {
        public string IdentifyCardBrand(string cardNumber)
        {
            cardNumber = cardNumber.Replace(" ", "").Replace("-", "");

            if (Regex.IsMatch(cardNumber, "^4[0-9]{12}(?:[0-9]{3})?$"))
                return "Visa";
            if (Regex.IsMatch(cardNumber, "^5[1-5][0-9]{14}$"))
                return "MasterCard";
            if (Regex.IsMatch(cardNumber, "^3[47][0-9]{13}$"))
                return "American Express";
            if (Regex.IsMatch(cardNumber, "^6(?:011|5[0-9]{2})[0-9]{12}$"))
                return "Discover";
            if (Regex.IsMatch(cardNumber, "^3(0[0-5]|[68][0-9])[0-9]{11}$"))
            return "Diners Club";
            if (Regex.IsMatch(cardNumber, "^(2014|2149)[0-9]{11}$"))
             return "EnRoute";
             if (Regex.IsMatch(cardNumber, "^(?:2131|1800|35\\d{3})\\d{11}$"))
            return "JCB";
            if (Regex.IsMatch(cardNumber, "^8699[0-9]{11}$"))
            return "Voyager";
            if (Regex.IsMatch(cardNumber, "^50[0-9]{14}$"))
            return "Aura";
            if (Regex.IsMatch(cardNumber, "^(606282|3841)[0-9]{10,13}$"))
            return "Hipercard";


            return "Unknown";
        }

        public bool ValidateCardNumber(string cardNumber)
        {
            if (string.IsNullOrWhiteSpace(cardNumber))
                return false;

            cardNumber = cardNumber.Replace(" ", "").Replace("-", "");

            if (!cardNumber.All(char.IsDigit))
                return false;

            int sum = 0;
            bool alternate = false;

            for (int i = cardNumber.Length - 1; i >= 0; i--)
            {
                int n = cardNumber[i] - '0';

                if (alternate)
                {
                    n *= 2;
                    if (n > 9)
                        n -= 9;
                }

                sum += n;
                alternate = !alternate;
            }

            return sum % 10 == 0;
        }
    }
}
