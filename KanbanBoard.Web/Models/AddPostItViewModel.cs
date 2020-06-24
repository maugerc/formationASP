using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KanbanBoard.Web.Models
{
    public class AddPostItViewModel
    {
        [DisplayName("Titre")]
        [Required(ErrorMessage = "Le champ titre est requis.")]
        public string Title { get; set; }

        [DisplayName("Description")]
        [Required(ErrorMessage = "Le champ description est requis.")]
        public string Description { get; set; }
    }
}
