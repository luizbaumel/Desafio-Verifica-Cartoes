using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SiteCartoes.Services;

namespace SiteCartoes.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICardValidator _cardValidator;

        public string? CardBrand { get; private set; }
        public bool IsValid { get; private set; }

        [BindProperty]
        public string CardNumber { get; set; } = string.Empty;

        public IndexModel(ICardValidator cardValidator)
        {
            _cardValidator = cardValidator;
        }

        public void OnPost()
        {
            CardBrand = _cardValidator.IdentifyCardBrand(CardNumber);
            IsValid = _cardValidator.ValidateCardNumber(CardNumber);
        }
    }
}