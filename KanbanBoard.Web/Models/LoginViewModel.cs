using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KanbanBoard.Web.Models
{
    public class LoginViewModel
    {
        [DisplayName("Identifiant")]
        [Required(ErrorMessage = "Le champs identifiant est requis")]
        public string UserName { get; set; }

        [DisplayName("Mot de passe")]
        [Required(ErrorMessage = "Le champs mot de passe est requis")]
        public string Password { get; set; }
    }
}